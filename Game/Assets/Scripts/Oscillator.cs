using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 StartingPos;
    [SerializeField] Vector3 MovementVector;
    float MovementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(period == Mathf.Epsilon) {return;}

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        MovementFactor = (rawSinWave + 1f) / 2f;

        Vector3 Offset = MovementVector * MovementFactor;

        transform.position = StartingPos + Offset;
    }
}
