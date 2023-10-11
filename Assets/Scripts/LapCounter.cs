using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LapCounter : MonoBehaviour
{
    //-------Local Variables------//
    int passedCheckPointNumber = 0;
    float timeAtLastPassedCheckPoint = 0;
    int numberOfPassedCheckpoints = 0;
    int lapsCompleted = 0;
    int carPlacement = 0;

    //------------Public Variables-----------------//
    
    public TMP_Text CarPlacementNumber;
    public bool RaceComplete = false;
    public GameObject FinishRaceMenu;
    public event Action<LapCounter> OnPassCheckpoint;
    public int LapsCompleted
    {
        get { return lapsCompleted; }
    }

 //--------------Variables needed in order to determine the Car's olacement--------------//
    public void SetCarPlacement(int placement)
    {
        carPlacement = placement;
    }
    public int GetnumberOfPassedCheckpoints()
    {
        return numberOfPassedCheckpoints;
    }
    public float GetTimeAtLastCheckPoint()
    {
        return timeAtLastPassedCheckPoint;
    }
    //----------------Checkpoint counter on collision with Car------------------//
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            CheckPoint checkPoint = collision.GetComponent <CheckPoint>();
            //  In order to check if you are on the right track, the number of o checkopoint passed + 1 should always be equal to the chekpoint that you need to hit next.
            //  For examle if you hit checkpoint 4, you will need to have passed 3, because 3 + 1 = 4 
            if (passedCheckPointNumber + 1 == checkPoint.checkpointNumber)
            {
                
                passedCheckPointNumber = checkPoint.checkpointNumber;
                numberOfPassedCheckpoints++;
                timeAtLastPassedCheckPoint = Time.time;
                //Lap coutner
                if (checkPoint.FinishLine)
                {
                    passedCheckPointNumber = 0;
                    lapsCompleted++;
                }

                //Shows the cars placement
                OnPassCheckpoint?.Invoke(this);
                CarPlacementNumber.SetText("" + carPlacement);
            }
        }
    }
}
