using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public Rigidbody2D rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(health <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }
}
