using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Garbage_Collecting : MonoBehaviour
{
    public int metalCount = 0;
    public int plasticCount = 0;
    public int paperCount = 0;

    public Text plasticCountText;
    public Text metalCountText;
    public Text paperCountText;

    [SerializeField] GameObject gameOverPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Metal"))
        {
            Destroy(other.gameObject);
            metalCount++;
            metalCountText.text = "Metal Count : "+metalCount.ToString();

     //       Debug.Log("Metal count : " + metalCount);
        }
        else if (other.gameObject.CompareTag("Paper"))
        {
            Destroy(other.gameObject);
            paperCount++;
            
            //    Debug.Log("Paper count : " + paperCount);
            paperCountText.text="Paper Count : "+paperCount.ToString();
        }
        else if (other.gameObject.CompareTag("Plastic"))
        {
            Destroy(other.gameObject);
            plasticCount++;

            //  Debug.Log("plastic count : " + plasticCount);
            plasticCountText.text = "plastic Count : " + plasticCount.ToString();
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0.0f;
            gameOverPanel.SetActive(true);
            PlayerPrefs.SetInt("MetalNum", metalCount + PlayerPrefs.GetInt("MetalNum",0));
            PlayerPrefs.SetInt("PlasticNum", plasticCount + PlayerPrefs.GetInt("PlasticNum", 0));
            PlayerPrefs.SetInt("PaperNum", paperCount + PlayerPrefs.GetInt("PaperNum", 0));
        }
    }
 
}
