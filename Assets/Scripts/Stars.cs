using UnityEngine;

public class Stars : MonoBehaviour
{
    public DayNightCycle dayNightCycle;
    private SpriteRenderer[] stars;

    private void Start()
    {
        stars = GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        dayNightCycle.OnTimeChanged += UpdateStarsVisibility;
    }

    private void OnDisable()
    {
        dayNightCycle.OnTimeChanged -= UpdateStarsVisibility;
    }

    private void UpdateStarsVisibility(float timeOfDay)
    {
        float alpha = 0f;
        if (timeOfDay < 0.25f)
        {
            alpha = Mathf.Lerp(1f, 0f, timeOfDay * 4);
        }
        else if (timeOfDay >= 0.75f)
        {
            alpha = Mathf.Lerp(0f, 1f, (timeOfDay - 0.75f) * 4);
        }

        foreach (var star in stars)
        {
            Color color = star.color;
            color.a = alpha;
            star.color = color;
        }
    }
}