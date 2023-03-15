using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public Transform rotatingPart;
    public float rotSpeed = 100;
    public float wheelForce = 30;
    Rigidbody parentRB;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            rotatingPart.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

            if (parentRB != null)
                parentRB.AddForce(rotatingPart.forward * wheelForce);
        }
    }

    public void GetParentRB(Rigidbody rb)
    {
        parentRB = rb;
    }
}
