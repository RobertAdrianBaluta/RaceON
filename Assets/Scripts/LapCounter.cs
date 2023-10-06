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
    public TMP_Text CarPlacementNumber;
    int passedCheckPointNumber = 0;
    float timeAtLastPassedCheckPoint = 0;
    int numberOfPassedCheckpoints = 0;
    int lapsCompleted = 0;
    
    int carPlacement = 0;
    public bool RaceComplete = false;
    public GameObject FinishRaceMenu;

    public int LapsCompleted
    {
        get { return lapsCompleted; }
    }
  
    public event Action<LapCounter> OnPassCheckpoint;

    public void Update()
    {
        Debug.Log("passedCheckPointNumber " + passedCheckPointNumber);
        Debug.Log("numberOfPassedCheckpoints " + numberOfPassedCheckpoints);
        Debug.Log("lapsCompleted " + lapsCompleted);
        Debug.Log("timeAtLastPassedCheckPoint " + timeAtLastPassedCheckPoint);
    }
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("aaa");
        if (collision.CompareTag("Checkpoint"))
        {
            
            CheckPoint checkPoint = collision.GetComponent <CheckPoint>();
            // So in order to to to check if you are on the right track, the number of o checkopoint passed + 1 should always be equal to the chekpoint that you need to hit next.
            //  For examle if you hit checkpoint 4, you will need to have passed 3, because 3 + 1 = 4 
            if (passedCheckPointNumber + 1 == checkPoint.checkpointNumber)
            {
                //All it assigns the checkpoint number to the one it has hit so following the example above, it will become 4 and so on so forth
                passedCheckPointNumber = checkPoint.checkpointNumber;
                numberOfPassedCheckpoints++;
                timeAtLastPassedCheckPoint = Time.time;

                if (checkPoint.FinishLine)
                {
                    passedCheckPointNumber = 0;
                    lapsCompleted++;
                }
                OnPassCheckpoint?.Invoke(this);
                CarPlacementNumber.SetText("" + carPlacement);
            }
        }
    }

}
