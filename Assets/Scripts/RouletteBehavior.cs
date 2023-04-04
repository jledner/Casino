using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RouletteBehavior : MonoBehaviour
{
    public GameObject rouletteSpinner;
    public float rotationSpeed = 10f;
    public GameObject rouletteTable;

    private bool isPlayerNearby;

    private Light pointLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("spinning");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            BroadcastMessage("Interact");
            BroadcastMessage("TurnOnLight");
        }
    }

    private void Update()
    {
        if (isPlayerNearby)
        {
            // Rotate the rouletteSpinner child component
            rouletteSpinner.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            
        }
    }

    public void Interact()
    {
        Debug.Log("Player interacted with " + gameObject.name);
        // do something in response to the interaction

    }
}

