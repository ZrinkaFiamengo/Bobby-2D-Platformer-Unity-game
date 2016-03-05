using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.isTrigger != true)
        {
            if (coll.CompareTag("Player"))
            {
                coll.GetComponent<Player>().Damage(1);
                Destroy(gameObject);
            }
        }
    }

}
