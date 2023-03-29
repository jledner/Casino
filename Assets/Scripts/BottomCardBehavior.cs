using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCardBehavior : MonoBehaviour
{
    public GameObject bottomCard;

    private bool isPlayerNearby;
    public float count;
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
        if (isPlayerNearby && count == 0)
        {
            // Rotate the rouletteSpinner child component
            bottomCard.transform.Rotate(180f, 0f, 0f);
            Debug.Log("flipping card");
            count++;
        }

    }
}