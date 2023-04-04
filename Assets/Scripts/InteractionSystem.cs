using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    // The object that the raycast is currently hitting
    public GameObject focusedObject;

    public GameObject pickupSlot;

    public float interactDistance;

    public bool holding;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (holding)
            return;

        // Compute the player's forward direction
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        // hit var to store results
        RaycastHit hit;

        // Ray originating from the camera
        Ray ray = new Ray(transform.position, fwd);
        Debug.DrawRay(transform.position, ray.direction * 1000, Color.white);

        // conduct raycast
        if (Physics.Raycast(ray, out hit))
        {
            focusedObject = hit.collider.gameObject;
            Debug.DrawRay(transform.position, ray.direction * hit.distance, Color.yellow);
        }
        else
        {
            focusedObject = null;
        }
    }

    public void OnInteract()
    {
        if (holding)
        {
            // Drop what we're holding
            focusedObject.transform.parent = null;
            focusedObject.GetComponent<Rigidbody>().isKinematic = false;
            holding = false;
        }
        else if (focusedObject.CompareTag("Interactable"))
        {
            // Pick up the item
            focusedObject.transform.parent = pickupSlot.transform;
            focusedObject.transform.position = pickupSlot.transform.position;
            focusedObject.GetComponent<Rigidbody>().isKinematic = true;
            holding = true;
        }
    }

}
