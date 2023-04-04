using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    public Light pointLight;

    public void TurnOnLight()
    {
        Debug.Log("Message received");
        pointLight.intensity = 10;
    }
}
