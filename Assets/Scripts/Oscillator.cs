using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; //continually growing over time

        const float tau = Mathf.PI * 2; //pi * 2 >> 6,283 yani bir dalgan�n tam ger�ekle�mesi i�in gereken de�er (tau), yani pi sadece yar�s� anlam�na geliyor
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 ve 1 aral���

        movementFactor = (rawSinWave + 1f) / 2f; // 0 ve 1 aral���nda gitmesi i�in yeniden d�zenlenmesi

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
