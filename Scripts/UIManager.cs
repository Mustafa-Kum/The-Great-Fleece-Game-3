using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    
    public static UIManager Instance
    {

        get
        {

            if (_instance == null)
            {

                Debug.LogError(" UI Manager is null !! ");

            }

            return _instance;

        }

    }

    public GameObject _pauseMenuPanel;

    private void Awake()
    {

        _instance = this;

    }

    public void Restart()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("Main");

    }

    public void Quit()
    {

        Application.Quit();

    }

    public void ESCMenu()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Time.timeScale = 0;
            _pauseMenuPanel.SetActive(true);

        }

    }

    public void MainMenu()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");

    }

    public void ResumeGame()
    {
        
        Time.timeScale = 1;
        _pauseMenuPanel.SetActive(false);
    
    }

}
