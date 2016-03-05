using UnityEngine;
using System.Collections;

public class LevelSwitchMenu : MonoBehaviour
{

    public GameObject levelSwitchUI;
    private bool levelSwitch = false;

    void Start()
    {
        levelSwitchUI.SetActive(false);
    }

    void Update()
    {
        if (levelSwitch)
        {
            Time.timeScale = 0;
        }
        if (!levelSwitch)
        {
            Time.timeScale = 1;
        }
    }

    public void Level1()
    {
        levelSwitch = false;
        Application.LoadLevel(0);
    }

    public void Level2()
    {
        levelSwitch = false;
        Application.LoadLevel(1);
    }

    public void Level3()
    {
        levelSwitch = false;
        Application.LoadLevel(2);
    }

    public void Level4()
    {
        levelSwitch = false;
        Application.LoadLevel(3);
    }

    public void Level5()
    {
        levelSwitch = false;
        Application.LoadLevel(4);
    }

    public void Level6()
    {
        levelSwitch = false;
        Application.LoadLevel(5);
    }

    public void Level7()
    {
        levelSwitch = false;
        Application.LoadLevel(6);
    }

    public void Level8()
    {
        levelSwitch = false;
        Application.LoadLevel(7);
    }

    public void Level9()
    {
        levelSwitch = false;
        Application.LoadLevel(8);
    }

    public void Level10()
    {
        levelSwitch = false;
        Application.LoadLevel(9);
    }
}
