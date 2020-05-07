using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;
    public GameObject PauseUI;
    public GameObject HealthBar;
    public GameObject MiniMap;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        MiniMap.SetActive(true);
        HealthBar.SetActive(true);
    }

    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        MiniMap.SetActive(false);
        HealthBar.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
