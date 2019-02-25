using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeCycle : MonoBehaviour
{

    public enum TimeOfDay {MorningTime, DayTime, AfternoonTime, NightTime }

    public bool ChangeTimeRandom;
    bool stopped;
    public TimeOfDay timeOfDay;
    Light lightSource;
    float transitionTime = 2f;

    [Header("Sky Colours")]
    public Color morningColour;
    public Color dayTimeColour;
    public Color afternoonColour;
    public Color nightColour;

    [Header("Timers")]
    public int currentTime;
    public float timeModifier = 1;
    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = TimeOfDay.MorningTime;
        lightSource = GetComponent<Light>();
        Debug.Log(Utilities.EnumLength(timeOfDay));
        currentTime = 0;
        StartCoroutine(TickTock());
    }

    

    void ChangeTime()
    {
        #region Old Time Stuff
        //if(ChangeTimeRandom)
        //{
        //    timeOfDay = Utilities.RandomEnumValue<TimeOfDay>();
        //}

        //if ((int)timeOfDay == Utilities.EnumLength(timeOfDay))
        //    timeOfDay = 0;
        //else
        //timeOfDay++;
        #endregion
        Debug.Log(Utilities.EnumToString(timeOfDay));

        timeOfDay = GetTimeOfDay();
        
        switch (timeOfDay)
        {
            case TimeOfDay.MorningTime:
                lightSource.DOColor(morningColour, transitionTime);
                break;
            case TimeOfDay.DayTime:
                lightSource.DOColor(dayTimeColour, transitionTime);
                break;
            case TimeOfDay.AfternoonTime:
                lightSource.DOColor(afternoonColour, transitionTime);
                break;
            case TimeOfDay.NightTime:
                lightSource.DOColor(nightColour, transitionTime);
                break;
        }
    }

   TimeOfDay GetTimeOfDay()
    {
        switch(currentTime)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return TimeOfDay.NightTime;
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                return TimeOfDay.MorningTime;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
                return TimeOfDay.DayTime;
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
                return TimeOfDay.AfternoonTime;
            default:
                return TimeOfDay.NightTime;

        }

    }

    IEnumerator TickTock()
    {
        while (!stopped)
        {
            yield return new WaitForSeconds(timeModifier);
            if (currentTime == 23)
                currentTime = 0;
            else
                currentTime++;

            ChangeTime();
        }
    }

    
}
