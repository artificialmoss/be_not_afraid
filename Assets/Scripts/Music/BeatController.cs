using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BeatController : MonoBehaviour
{
    [SerializeField] private int counter = 0;
    [SerializeField] private int beatOffset = 0;
    [SerializeField] private int hitPerBeats = 4;
    [SerializeField] private List<double> timings;
    [SerializeField] private double startTime;
    [SerializeField] private int nextBeatCounter = 0;
    [SerializeField] private double beatTimeOffset;

    [SerializeField] private AudioClip song;
    [SerializeField] private TextAsset timingsJson;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        song.LoadAudioData();

        beatTimeOffset = TimedObjectsState.Timings.midpoint * TimedObjectsState.Instance.attackSpeedModifier;
        timings = JsonUtility.FromJson<TimingsList>(timingsJson.text).Timings;
        audioSource.Play();
        startTime = AudioSettings.dspTime;
    }

    public void Update()
    {
        if (nextBeatCounter == timings.Count)
        {
            nextBeatCounter = 0;
        }
        if (AudioSettings.dspTime + beatTimeOffset >= timings[nextBeatCounter] + startTime)
        {
            onOnbeatDetected(timings[nextBeatCounter++]);
        }
    }

    void onOnbeatDetected(double beatTime)
    {
        ++counter;
        if (counter % hitPerBeats == beatOffset)
        {
            MoleGenerator.Instance.CreateTimedObjectAtTime(beatTime);
        }
    }
}