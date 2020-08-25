using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pausesmenue, pauseButton;

    public void pause()
    {
        pausesmenue.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void resume()
    {
        pausesmenue.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void home()
    {
        resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
