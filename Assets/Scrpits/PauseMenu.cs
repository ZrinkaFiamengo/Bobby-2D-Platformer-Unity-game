using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    public GameObject levelSwitchUI;
    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        PauseUI.SetActive(false);
        paused = false;
        levelSwitchUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
