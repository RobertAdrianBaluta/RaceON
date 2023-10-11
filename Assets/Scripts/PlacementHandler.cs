using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    //Array that takes in all the Lap counter
    public List<LapCounter> lapCounters = new List<LapCounter>();

 //----------List for the cars----------//
    void Start()
    {
        //Puts all Cars in the list
        LapCounter[] lapCounterArray = FindObjectsOfType<LapCounter>();
        lapCounters = lapCounterArray.ToList();

        foreach (LapCounter lapCounters in lapCounters)
            lapCounters.OnPassCheckpoint += OnPassCheckpoint;
    }

    //----------------------Finsh Placement winner-------------------------//
    void OnPassCheckpoint(LapCounter lapCounter)
    {
        //Gets cars rnd placement based on most Checkpoints and least ammount of Time
        lapCounters = lapCounters.OrderByDescending(s => s.GetnumberOfPassedCheckpoints()).ThenBy(s => s.GetTimeAtLastCheckPoint()).ToList();
        int carPlacement = lapCounters.IndexOf(lapCounter) + 1;
        lapCounter.SetCarPlacement(carPlacement);

    }

  
}
