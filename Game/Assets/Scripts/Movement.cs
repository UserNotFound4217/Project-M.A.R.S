using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public float thrustPower = 1000f;
    public float rot = 100f;
    AudioSource audioSource;
    public AudioClip thrustNoise;
    public ParticleSystem leftThrusterParticles;
    public ParticleSystem rightThrusterParticles;
    public ParticleSystem mainThrusterParticles;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    

    void Thrust()
    {
        StartThrusting();
    }

    void StartThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed Space");
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustNoise);
            }
            if (!mainThrusterParticles.isPlaying)
            {
                mainThrusterParticles.Play();
            }

        }
        else
        {
            audioSource.Stop();
            mainThrusterParticles.Stop();
        }
    }

    void Rotate()
    {
        StartRotation();
    }

    void StartRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed D");
            ApplyRotate(-rot);
            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed A");
            ApplyRotate(rot);
            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }
        else
        {
            leftThrusterParticles.Stop();
            rightThrusterParticles.Stop();
        }
    }

    private void ApplyRotate(float rotationThisFrame)
    {   
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
