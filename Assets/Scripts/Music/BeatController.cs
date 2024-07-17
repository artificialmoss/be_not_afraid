using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    [SerializeField] private int counter = 8;
    [SerializeField] private List<double> timings;
    [SerializeField] private double startTime;
    [SerializeField] private int nextBeatCounter = 0;
    [SerializeField] private double beatTimeOffset;

    [SerializeField] private string filename;

    void Start()
    {
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        // AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        // processor.onBeat.AddListener(onOnbeatDetected);
        // processor.onSpectrum.AddListener (onSpectrum);
        beatTimeOffset = TimedObjectsState.Timings.midpoint * TimedObjectsState.Instance.attackSpeedModifier;
        startTime = AudioSettings.dspTime;
        timings = JsonUtility.FromJson<TimingsList>(
            File.ReadAllText(Path.Combine(Path.Combine(Application.dataPath, "Resources"), filename))).Timings;
    }

    //this event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector
    //to adjust the sensitivity

    public void Update()
    {
        if (AudioSettings.dspTime + beatTimeOffset >= timings[nextBeatCounter] + startTime)
        {
            ++nextBeatCounter;
            onOnbeatDetected();
        }
}

    void onOnbeatDetected()
    {
        ++counter;
        // if (counter % 4 == 2)
        // {
            MoleGenerator.Instance.CreateTimedObject();
        // }
    }

    //This event will be called every frame while music is playing
    // void onSpectrum (float[] spectrum)
    // {
    //     //The spectrum is logarithmically averaged
    //     //to 12 bands
    //
    //     for (int i = 0; i < spectrum.Length; ++i) {
    //         Vector3 start = new Vector3 (i, 0, 0);
    //         Vector3 end = new Vector3 (i, spectrum [i], 0);
    //         Debug.DrawLine (start, end);
    //     }
    // }
}