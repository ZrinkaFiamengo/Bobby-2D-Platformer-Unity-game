using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    private int levelToLoad;
    private GameMaster gm;
    private Player player;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelToLoad = Application.loadedLevel + 1;
    }

   void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            gm.inputText.text = ("[E] to enter");
            if (Input.GetKeyDown("e"))
            {
                Application.LoadLevel(levelToLoad);
            }
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                Application.LoadLevel(levelToLoad);
                GlobalControl.Instance.SavePlayer(player.currentHealth, gm.points);
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            gm.inputText.text = ("");
        }
    }
}
