using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public Sprite[] heartSprites;
    public Image HeartUI;
    private Player player;

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        HeartUI.sprite = heartSprites[player.currentHealth];
    }
}
