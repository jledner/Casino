using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPCamera : MonoBehaviour
{
    // The camera attached to the player
    public Camera playerCamera;

    // container variables for the mouse delta values each frame
    public float deltaX;
    public float deltaY;

    //container variables for the players rotation around X and Y axes
    public float xRot; //rotation around X axis in degrees
    public float yRot; //rotation around Y axis in degrees

    // Adjust the mouseSensitivity
    public float mouseSensitivity = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main; //set player camera
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep track of the player's x and y rotation
        yRot += deltaX;
        xRot -= deltaY;

        // Keep the player's x rotation clamped to [-90, 90] degrees
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // camera movement smoothing

        // rotate the camera around the x-axis
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    // OnCameraLook event handler

    public void OnCameraLook(InputValue value)
    {
        // reading the mouse deltas as a vector 2 (deltaX is the x component and deltaY is the y component)
        Vector2 inputVector = value.Get<Vector2>();
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}
