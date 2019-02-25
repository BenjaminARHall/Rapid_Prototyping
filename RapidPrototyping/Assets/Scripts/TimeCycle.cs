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
    public float timeModifier;
    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = TimeOfDay.MorningTime;
        lightSource = GetComponent<Light>();
        Debug.Log(Utilities.EnumLength(timeOfDay));
        currentTime = 0;
        StartCoroutine(TickTock());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ChangeTime();
        if (Input.GetKeyDown(KeyCode.R))
            ChangeTime();
    }

    void ChangeTime()
    {
        if(ChangeTimeRandom)
        {
            timeOfDay = Utilities.RandomEnumValue<TimeOfDay>();
        }

        if ((int)timeOfDay == Utilities.EnumLength(timeOfDay))
            timeOfDay = 0;
        else
        timeOfDay++;

        Debug.Log(Utilities.EnumToString(timeOfDay));
        
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

    IEnumerator TickTock()
    {
        while (!stopped)
        {
            yield return new WaitForSeconds(timeModifier);
            if (currentTime == 23)
                currentTime = 0;
            else
                currentTime++;
        }
    }

    
}
