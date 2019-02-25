using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeOfDayText;

    private void OnEnable()
    {
        GameEvents.OnTimeOfDayChange += OnTimeOfDayChange;
    }

    private void OnDisable()
    {
        GameEvents.OnTimeOfDayChange -= OnTimeOfDayChange;
    }

    void OnTimeOfDayChange(TimeOfDay timeOfDay)
    {
        timeOfDayText.text = Utilities.EnumToString(timeOfDay);
    }
}
