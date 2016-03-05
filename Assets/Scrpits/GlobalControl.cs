using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int currentHealth;
    public int points;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        this.currentHealth = -1;
        this.points = -1;
    }

    public void SavePlayer(int _currentHealth, int _points)
    {
        GlobalControl.Instance.currentHealth = _currentHealth;
        GlobalControl.Instance.points = _points;
    }
}
