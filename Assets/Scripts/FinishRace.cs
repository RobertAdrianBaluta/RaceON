using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishRace : MonoBehaviour
{
    //----------List of Cars, TMP and public variable for laps to completed -------//
    public GameObject FinishRaceMenu;
    [SerializeField]
    LapCounter[] lapCounters; 
    [SerializeField]
    TMP_Text winnerText;
    [SerializeField]
    const int lapsToComplete = 2;

    //-------------If the car form th------------//
    public void Update()
    {

        //If any of the cars from the LapCounter list gets to lapsToComplete, the game will be over and the winner will be displayed
        for (int i = 0; i < lapCounters.Length; i++)
        { 
            if (lapCounters[i].LapsCompleted >= lapsToComplete)
            {
                FinishRaceMenu.SetActive(true);              
                winnerText.SetText(lapCounters[i].name + " IS THE WINNER!!!");
            }
        }
    }

    //-------------------Button action for Next level-----------------//
    public void ContinueToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
