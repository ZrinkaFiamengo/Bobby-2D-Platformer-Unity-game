using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //floats
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    //booleans
    public bool grounded;
    public bool canDoubleJump;

    //stats
    public int currentHealth;
    public int maxHealth = 5;
    public int fallingDepth = -20;

    //references
    private Rigidbody2D rb2d;
    private Animator anim;
    private GameMaster gm;

	void Start () 
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        
        if (GlobalControl.Instance.currentHealth == -1)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = GlobalControl.Instance.currentHealth;
        }
        
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
	}

	void Update () 
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower/1.5f);
                }
            }
        }

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
	}

    void FixedUpdate()
    {
        
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;
        

        //fake fiction/easing the x speed of our player
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }
        

        float h = Input.GetAxis("Horizontal");  //left arrow, right arrow, A, D

        //h is -1 if we press left and +1 if we press right

        //moving the player
        rb2d.AddForce((Vector2.right * speed) * h);


        //limiting the speed of the player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.position.y <= fallingDepth)
        {
            Die();
        }

    }

    void Die()
    {
        GlobalControl.Instance.SavePlayer(maxHealth, 0);
        //restart
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_damage");
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public IEnumerator KnockBack(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);
            if (knockbackDir.x > 0)
            {
                rb2d.AddForce(new Vector3(knockbackDir.x - knockbackPwr / 3, transform.position.y + knockbackPwr, transform.position.z));
            }
            else
            {
                rb2d.AddForce(new Vector3(knockbackDir.x + knockbackPwr / 3, transform.position.y + knockbackPwr, transform.position.z));
            }
        }
        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Coin"))
        {
            Destroy(coll.gameObject);
            gm.points += 1;
        }
    }

}
