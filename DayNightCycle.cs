using UnityEngine;
using UnityEngine.Events;

public class DayNightCycle : MonoBehaviour
{
    [Header("Sun Settings")]

    // Reference to the directional light representing the sun
    public Light sun;

    // Length of a full day in real seconds
    public float dayLength = 120f;

    // Sun's initial rotation
    public Vector3 sunInitialRotation = new Vector3(50f, -30f, 0f);

    [Header("Events")]

    // Event for sunrise
    public UnityEvent onSunrise;

    // Event for noon
    public UnityEvent onNoon;

    // Event for sunset
    public UnityEvent onSunset;

    // Event for midnight
    public UnityEvent onMidnight;

    [Header("Debug")]

    // Debug time (0-24)
    [Range(0f, 24f)]
    public float timeOfDay;

    private float currentTime;
    private float timeMultiplier;

    void Start()
    {
        if (sun == null)
        {
            Debug.LogError("Sun Light is not assigned.");
            return;
        }

        currentTime = timeOfDay / 24f * dayLength;
        timeMultiplier = 24f / dayLength;
    }

    void Update()
    {
        if (sun == null) return;

        // Update the current time
        currentTime += Time.deltaTime * timeMultiplier;

        // Loop the time of day
        if (currentTime >= dayLength)
        {
            currentTime = 0f;
        }

        // Calculate the time of day (0-24)
        timeOfDay = currentTime / dayLength * 24f;

        // Rotate the sun
        float sunRotation = (currentTime / dayLength) * 360f;
        sun.transform.rotation = Quaternion.Euler(sunInitialRotation.x + sunRotation, sunInitialRotation.y, sunInitialRotation.z);

        // Trigger events at specific times
        TriggerEvents();
    }

    private void TriggerEvents()
    {
        // Sunrise at 6:00
        if (Mathf.Approximately(timeOfDay, 6f))
        {
            onSunrise.Invoke();
        }

        // Noon at 12:00
        if (Mathf.Approximately(timeOfDay, 12f))
        {
            onNoon.Invoke();
        }

        // Sunset at 18:00
        if (Mathf.Approximately(timeOfDay, 18f))
        {
            onSunset.Invoke();
        }

        // Midnight at 0:00
        if (Mathf.Approximately(timeOfDay, 0f))
        {
            onMidnight.Invoke();
        }
    }

    private void OnValidate()
    {
        // Ensure the current time is within bounds
        currentTime = Mathf.Clamp(currentTime, 0f, dayLength);
        timeOfDay = Mathf.Clamp(timeOfDay, 0f, 24f);

        // Update the sun's rotation in the editor
        if (sun != null)
        {
            float sunRotation = (timeOfDay / 24f) * 360f;
            sun.transform.rotation = Quaternion.Euler(sunInitialRotation.x + sunRotation, sunInitialRotation.y, sunInitialRotation.z);
        }
    }
}
