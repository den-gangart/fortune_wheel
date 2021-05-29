using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTicker : MonoBehaviour
{
    private float prevAngle = 0;
    private float currentAngle = 0;
    private float angleStep = 22.5f;

    private AudioSource audioSource;
    [SerializeField] private AudioClip spinTick;
    [SerializeField] private AudioClip endSpinSound;

    bool _spin = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_spin)
        {
            currentAngle = transform.rotation.eulerAngles.z;

            if (currentAngle - prevAngle < -angleStep || currentAngle - prevAngle > angleStep)
            {
                prevAngle = currentAngle;
                audioSource.Play();
            }
        }
    }
    
    public void StartSpin()
    {
        audioSource.clip = spinTick;
        _spin = true;
    }

    public void EndSpin()
    {
        audioSource.clip = endSpinSound;
        audioSource.Play();

        _spin = false;
    }
}
