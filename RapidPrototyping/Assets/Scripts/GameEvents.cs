using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action<TimeOfDay> OnTimeOfDayChange = null;

    public static void ReportOnTimeOfDayChange(TimeOfDay timeOfDay)
    {
        if (OnTimeOfDayChange != null)
            OnTimeOfDayChange(timeOfDay);
    }
}
