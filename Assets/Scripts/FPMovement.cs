using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPMovement : MonoBehaviour
{
    // Player's movement parameters
    public Vector3 direction;
    public float speed;

    // Player's rigidbody
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // All physics calculations happen in Fixed Update
    void FixedUpdate()
    {
        // make world direction into local direction
        Vector3 localDirection = transform.TransformDirection(direction);

        //move using physics
        rb.MovePosition(rb.position + (localDirection * speed * Time.deltaTime));
        //transform.Translate(direction * speed * Time.deltaTime);
    }

    // OnPlayerMove event handler
    public void OnPlayerMove(InputValue value)
    {
        // A vector with x and y componenets corresponding to the player's WASD and arrow inputs
        // both components are in the range [-1, 1]
        Vector2 inputVector = value.Get<Vector2>();
        //direction = new Vector3(inputVector.x, 0, inputVector.y);

        //move in the XZ plane
        direction.x = inputVector.x;
        direction.z = inputVector.y;
        direction.y = 0f;
    }
}
