using UnityEngine;

public class BreathingMotion : MonoBehaviour
{
    [Header("Breathing Settings")]
    [Tooltip("How fast the breathing animation plays")]
    public float breathingSpeed = 1.0f;
    
    [Tooltip("How far the object moves up and down")]
    public float breathingAmplitude = 0.1f;
    
    [Tooltip("Offset to make the motion feel more natural")]
    public float breathingOffset = 0.0f;
    
    // Store the initial position
    private Vector3 startPosition;
    private float timeOffset;
    
    void Start()
    {
        // Save the starting position
        startPosition = transform.position;
        
        // Add random offset to make multiple objects breathe differently
        timeOffset = breathingOffset;
    }
    
    void Update()
    {
        // Calculate the vertical offset using a sine wave
        float breathingMotion = Mathf.Sin((Time.time + timeOffset) * breathingSpeed) * breathingAmplitude;
        
        // Apply the new position
        Vector3 newPosition = startPosition + new Vector3(0f, breathingMotion, 0f);
        transform.position = newPosition;
    }
}