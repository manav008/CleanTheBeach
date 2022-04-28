using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    public PlayerMovement Player;
    public TMP_InputField PlayerSpeed;
    public TMP_InputField Gravity;
    public TMP_InputField[] CameraOffset;
    public Transform cameraPos;
    public GameObject MenuDebug;

    Vector3 defaultCamera;
    float defaultSpeed;
    float defaultGravity;
    private void Start()
    {
        defaultCamera = cameraPos.position;
        defaultSpeed = Player.speed;
        defaultGravity = Player.gravity;
      
        Time.timeScale = 1;
        MenuDebug.gameObject.SetActive(false);
    }

    public void OpenDebugMenu()
    {
        PlayerSpeed.text = Player.speed.ToString();
        Gravity.text = Player.gravity.ToString();

        CameraOffset[0].text = cameraPos.position.x.ToString("0.0");
        CameraOffset[1].text = cameraPos.position.y.ToString("0.0");
        CameraOffset[2].text = cameraPos.position.z.ToString("0.0");

        MenuDebug.gameObject.SetActive(MenuDebug.activeInHierarchy ? false : true);
        Time.timeScale = MenuDebug.activeInHierarchy ? 0.0f : 1.0f;



        // if(MenuDebug)
    }
    public void ApplyDebug()
    {
        MenuDebug.gameObject.SetActive(MenuDebug.activeInHierarchy ? false : true);
        Time.timeScale = 1;
        Player.speed = int.Parse(PlayerSpeed.text);
        Player.gravity = int.Parse(Gravity.text);

        Vector3 vect = new Vector3(float.Parse(CameraOffset[0].text), float.Parse(CameraOffset[1].text),float.Parse(CameraOffset[2].text));
        cameraPos.position = vect;
    }
    public void ResetValue()
    {
        MenuDebug.gameObject.SetActive(MenuDebug.activeInHierarchy ? false : true);
        Time.timeScale = 1;
        cameraPos.position = defaultCamera;
        Player.speed = defaultSpeed;
        Player.gravity = defaultGravity;
    }

     


}
