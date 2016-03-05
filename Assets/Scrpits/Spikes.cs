using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            player.Damage(1);

            StartCoroutine(player.KnockBack(0.2f, 30, player.transform.position));
        }

    }
}
