using UnityEngine;

public class Sun : MonoBehaviour
{
    public DayNightCycle dayNightCycle;

    private void OnEnable()
    {
        dayNightCycle.OnTimeChanged += UpdateSunPosition;
    }

    private void OnDisable()
    {
        dayNightCycle.OnTimeChanged -= UpdateSunPosition;
    }

    private void UpdateSunPosition(float timeOfDay)
    {
        if (timeOfDay < 0.25f)
        {
            transform.position = Vector3.Lerp(dayNightCycle.sunStartPosition.position, dayNightCycle.sunMiddayPosition.position, timeOfDay * 4);
        }
        else if (timeOfDay < 0.5f)
        {
            transform.position = dayNightCycle.sunMiddayPosition.position;
        }
        else if (timeOfDay < 0.75f) 
        {
            transform.position = Vector3.Lerp(dayNightCycle.sunMiddayPosition.position, dayNightCycle.sunEndPosition.position, (timeOfDay - 0.5f) * 4);
        }
        else
        {
            transform.position = dayNightCycle.sunEndPosition.position;
        }
    }
}