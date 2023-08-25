using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightHat : MonoBehaviour
{    
    public float rotationSpeedFloat = 5;      

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        // use this line for instant-rotation
        transform.rotation = targetRotation;

        // use this line for rotation over time
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeedFloat);
    }

}
