using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBall : MonoBehaviour
{
    public float startHeight = 5f;   // initial height of the ball
    public float rollForce = 10f;    // force applied to the ball to make it roll

    private bool isRolling = false;  // flag to track if the ball is rolling

    void Start()
    {
        // set the initial position of the ball above the table
        transform.position = new Vector3(0f, 0f, startHeight);
    }

    void Update()
    {
        if (!isRolling && Input.GetKeyDown(KeyCode.Space))
        {
            // start rolling the ball when the space key is pressed
            GetComponent<Rigidbody>().AddForce(-transform.up * rollForce, ForceMode.Impulse);
            isRolling = true;
        }
    }
}

