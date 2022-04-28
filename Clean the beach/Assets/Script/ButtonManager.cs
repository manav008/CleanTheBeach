using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        if(PlayerPrefs.GetInt("DialogueFinished", 0) == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }

        else
            SceneManager.LoadScene("Dialogues Scene");

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StoreItems()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void BuyersList()
    {
        SceneManager.LoadScene("BuyersList");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
