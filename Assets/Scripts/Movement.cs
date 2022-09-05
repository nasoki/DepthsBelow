using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidbodyRocket;
    public int ThrustPower;
    public int RotatePower;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem rightBooster;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRocket = GetComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            rigidbodyRocket.AddRelativeForce(ThrustPower * Time.deltaTime * Vector3.up);
            if (!mainBooster.isPlaying)
            {
                mainBooster.Play();
            }
        }
        else 
        {
            audioSource.Stop();
            mainBooster.Stop();
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
            rigidbodyRocket.freezeRotation = true;
            transform.Rotate(RotatePower * Time.deltaTime * Vector3.forward);
            rigidbodyRocket.freezeRotation = false;
        }

        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
            rigidbodyRocket.freezeRotation = true;
            transform.Rotate(RotatePower * Time.deltaTime * Vector3.back);
            rigidbodyRocket.freezeRotation = false;
        }

        else
        {
            rightBooster.Stop();
            leftBooster.Stop();
            
        }
    }
}
