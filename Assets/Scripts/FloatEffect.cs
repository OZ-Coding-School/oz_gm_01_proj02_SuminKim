using System;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float Amplitude = 0.5f; // The height of the float effect
    public float Frequency = 1f; // The speed of the float effect

    private Vector3 posOffset = new Vector3(); // Store the starting position of the object
    private Vector3 tempPos = new Vector3(); // Temporary position variable

    void Start()
    {
        // Store the starting position of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Float up and down using a sine function wave 
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Frequency) * Amplitude;
        // We only want to modify the y position of the object
        // Time times Radius and frequency to create a angle.
        // If frequency is higher, the angle changes faster. => faster movement.

        transform.position = new Vector3(transform.position.x, tempPos.y, transform.position.z);
    }
}
