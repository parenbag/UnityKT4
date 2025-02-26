using UnityEngine;
using System;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 60f;
    public Color morningColor;
    public Color dayColor;
    public Color eveningColor;
    public Color nightColor;

    public Transform sunStartPosition;
    public Transform sunMiddayPosition;
    public Transform sunEndPosition;

    public event Action<float> OnTimeChanged;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > dayDuration)
        {
            timer = 0f;
        }

        float timeOfDay = timer / dayDuration;
        OnTimeChanged?.Invoke(timeOfDay);
    }
}