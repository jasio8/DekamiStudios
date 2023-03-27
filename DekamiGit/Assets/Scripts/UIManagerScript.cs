using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManagerScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public PlayerMovementScript PMS;
    public HeadBob bob;
    public PlayerCamera Pcam;
    void Start()
    {
        
    }

    void Update()
    {
      if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        PMS.IsEnabled = false;
        bob.IsEnabled = false;
        Pcam.IsEnabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        PMS.IsEnabled = true;
        bob.IsEnabled = true;
        Pcam.IsEnabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ExitGame()
    {
        Application.Quit();   
    }
}
