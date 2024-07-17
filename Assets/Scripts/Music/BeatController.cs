using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    [SerializeField] private int counter = 0;
    [SerializeField] private int beatOffset = 0;
    [SerializeField] private int HitPerBeats = 4;
    [SerializeField] private List<double> timings;
    [SerializeField] private double startTime;
    [SerializeField] private int nextBeatCounter = 0;
    [SerializeField] private double beatTimeOffset;

    [SerializeField] private string filename;

    void Start()
    {
        beatTimeOffset = TimedObjectsState.Timings.midpoint * TimedObjectsState.Instance.attackSpeedModifier;
        startTime = AudioSettings.dspTime;
        timings = JsonUtility.FromJson<TimingsList>(
            File.ReadAllText(Path.Combine(Path.Combine(Application.dataPath, "Resources"), filename))).Timings;
    }

    public void Update()
    {
        if (AudioSettings.dspTime + beatTimeOffset >= timings[nextBeatCounter] + startTime)
        {
            onOnbeatDetected(timings[nextBeatCounter++]);
        }
}

    void onOnbeatDetected(double beatTime)
    {
        ++counter;
        if (counter % 4 == 2)
        {
            MoleGenerator.Instance.CreateTimedObjectAtTime(beatTime);
        }
    }
}