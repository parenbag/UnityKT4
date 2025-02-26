using UnityEngine;

public class Sky : MonoBehaviour
{
    public DayNightCycle dayNightCycle;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        dayNightCycle.OnTimeChanged += UpdateSkyColor;
    }

    private void OnDisable()
    {
        dayNightCycle.OnTimeChanged -= UpdateSkyColor;
    }

    private void UpdateSkyColor(float timeOfDay)
    {
        if (timeOfDay < 0.25f)
        {
            mainCamera.backgroundColor = Color.Lerp(dayNightCycle.nightColor, dayNightCycle.morningColor, timeOfDay * 4);
        }
        else if (timeOfDay < 0.5f)
        {
            mainCamera.backgroundColor = Color.Lerp(dayNightCycle.morningColor, dayNightCycle.dayColor, (timeOfDay - 0.25f) * 4);
        }
        else if (timeOfDay < 0.75f)
        {
            mainCamera.backgroundColor = Color.Lerp(dayNightCycle.dayColor, dayNightCycle.eveningColor, (timeOfDay - 0.5f) * 4);
        }
        else
        {
            mainCamera.backgroundColor = Color.Lerp(dayNightCycle.eveningColor, dayNightCycle.nightColor, (timeOfDay - 0.75f) * 4);
        }
    }
}