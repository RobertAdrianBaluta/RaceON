using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishRace : MonoBehaviour
{
    public GameObject FinishRaceMenu;
    [SerializeField]
    LapCounter[] lapCounters; //= new LapCounter[3];

    [SerializeField]
    TMP_Text winnerText;

    [SerializeField]
    const int lapsToComplete = 2;

    private void Start()
    {  
    }

    public void Update()
    {
        for (int i = 0; i < lapCounters.Length; i++)
        {
            //lapCounters[i].gameObject.name

            
            if (lapCounters[i].LapsCompleted >= lapsToComplete)
            {

                Debug.Log("winenr " + lapCounters[i].name);
                //RaceComplete = true;
                FinishRaceMenu.SetActive(true);              
                winnerText.SetText(lapCounters[i].name + " IS THE WINNER!!!");
            }
        }

    }

    public void ContinueToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
