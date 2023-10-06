using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlacementHandler : MonoBehaviour
{
    public List<LapCounter> lapCounters = new List<LapCounter>();
 

    void Start()
    {
        LapCounter[] lapCounterArray = FindObjectsOfType<LapCounter>();
        lapCounters = lapCounterArray.ToList();

        foreach (LapCounter lapCounters in lapCounters)
            lapCounters.OnPassCheckpoint += OnPassCheckpoint;
    }

    void OnPassCheckpoint(LapCounter lapCounter)
    {
        //Debug.Log(message: $"Event: Car {lapCounter.gameObject.name} passed a checkpoint");
        lapCounters = lapCounters.OrderByDescending(s => s.GetnumberOfPassedCheckpoints()).ThenBy(s => s.GetTimeAtLastCheckPoint()).ToList();
        int carPlacement = lapCounters.IndexOf(lapCounter) + 1;
        lapCounter.SetCarPlacement(carPlacement);

    }

  
}
