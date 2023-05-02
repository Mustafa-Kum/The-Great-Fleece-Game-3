using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Restart()
    {

        SceneManager.LoadScene("Loading_Screen");
        Time.timeScale = 1;

    }

    public void Quit()
    {

        Application.Quit();

    }

}
