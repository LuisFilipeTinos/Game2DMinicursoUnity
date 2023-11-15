using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeIntensity;

    private Vector3 initialPosition;
    private float currentShakeDuration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShakeDuration > 0)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
            transform.localPosition = initialPosition + randomOffset;

            currentShakeDuration -= Time.deltaTime;
        }
        else
            transform.localPosition = initialPosition;
    }

    public void Shake()
    {
        currentShakeDuration = shakeDuration;
    }
}
