using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    public int points;
    public Text pointsText;
    public Text inputText;

    void Start()
    {
        if (GlobalControl.Instance.points == -1)
        {
            points = 0;
        }
        else
        {
            points = GlobalControl.Instance.points;
        }
    }

    void Update()
    {
            pointsText.text = ("Points: " + points);
    }
}
