using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public float thrustPower = 1000f;
    public float rot = 100f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }


    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed Space");
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed D");
            ApplyRotate(-rot);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed A");
            ApplyRotate(rot);
        }
    }

    private void ApplyRotate(float rotationThisFrame)
    {   
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
