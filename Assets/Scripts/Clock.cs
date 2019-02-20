using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform HoursArm, MinutesArm, SecondsArm;
    public bool IsContinuous;

    private const float DegreesPerHour = 30f;
    private const float DegreesPerMinutes = 6f;
    private const float DegreesPerSeconds = 6f;


    // Start is called before the first frame update
    void Update()
    {
        if (IsContinuous)
            UpdateContinues();
        else
            UpdateDiscrete();
    }

    // Update is called once per frame
    void UpdateContinues()
    {
        var time = DateTime.Now.TimeOfDay;
        HoursArm.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * DegreesPerHour, 0f);
        MinutesArm.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * DegreesPerMinutes, 0f);
        SecondsArm.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * DegreesPerSeconds, 0f);
    }

    void UpdateDiscrete()
    {
        var time = DateTime.Now;
        HoursArm.localRotation = Quaternion.Euler(0f, time.Hour * DegreesPerHour, 0f);
        MinutesArm.localRotation = Quaternion.Euler(0f, time.Minute * DegreesPerMinutes, 0f);
        SecondsArm.localRotation = Quaternion.Euler(0f, time.Second * DegreesPerSeconds, 0f);
    }
}
