using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBehavior : MonoBehaviour
{
    public GameObject rouletteSpinner;
    public float rotationSpeed = 10f;

    private bool isPlayerNearby;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby)
        {
            // Rotate the rouletteSpinner child component
            rouletteSpinner.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            Debug.Log("spinning");
        }
    }
}

