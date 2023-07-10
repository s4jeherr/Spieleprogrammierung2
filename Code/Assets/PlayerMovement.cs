using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float centerOfMassOffset = -2.5f;
    private Rigidbody rb;
    private Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation; // Store the original rotation
    }

    void FixedUpdate()
    {
        // Reset the rotation to the original rotation
        transform.rotation = originalRotation;

        // Get input axes
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
        }

        // Calculate new Center of Mass
        Vector3 newCenterOfMass = Vector3.zero;

        if (moveHorizontal != 0f || moveVertical != 0f)
        {
            newCenterOfMass = new Vector3(moveHorizontal, 0f, moveVertical).normalized * centerOfMassOffset;
        }

        rb.centerOfMass = newCenterOfMass;
    }
}
