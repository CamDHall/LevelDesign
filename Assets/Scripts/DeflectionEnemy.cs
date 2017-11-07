using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectionEnemy : Enemy {

    float Timer;
    float moveTimer;

    Vector3 movePos;

    public GameObject basicEnemy, bombEnemy, growthEnemy;
	void Start () {
        Timer = Time.time + 3;
        moveTimer = Time.time + 2f;

        PickDirection();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerMovement.Instance != null)
        {
            if(health <= 0)
            {
                Death();
            }
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) <= 3)
            {
                if (Timer < Time.time)
                {
                    SpawnEnemy();
                    Timer = Time.time + 2;
                }
            }
        }
	}

    private void FixedUpdate()
    {
        if(moveTimer > Time.time)
        {
            rb.MovePosition(transform.position + (movePos * Time.deltaTime));
        } else
        {
            moveTimer = Time.time + 2f;
            PickDirection();
        }
    }

    void SpawnEnemy()
    {
        int choice = Random.Range(0, 9);

        float x = Random.Range(-2, 2);
        Vector3 Pos = new Vector3(transform.position.x + x, transform.position.y + 0.5f, 0);

        if(choice <= 2)
        {
            Instantiate(basicEnemy, Pos, Quaternion.identity);
        } else if(choice <= 5)
        {
            Instantiate(growthEnemy, Pos, Quaternion.identity);
        } else if(choice <= 7)
        {
            Instantiate(bombEnemy, Pos, Quaternion.identity);
        } else
        {
            Instantiate(gameObject, Pos, Quaternion.identity);
        }

        if(choice == 0)
        {
            Instantiate(gameObject, Pos, Quaternion.identity);
        } else if(choice <= 2)
        {
            Instantiate(basicEnemy, Pos, Quaternion.identity);
        } else if(choice <= 4)
        {
            Instantiate(growthEnemy, Pos, Quaternion.identity);
        } else
        {
            Instantiate(bombEnemy, Pos, Quaternion.identity);
        }
    }

    void PickDirection()
    {
        int choice = Random.Range(0, 2);

        float y = 0;

        if(choice == 0)
        {
            y = -0.25f;
        } else
        {
            y = 0.25f;
        }

        // First x assignment
        if (movePos == Vector3.zero)
        {
            movePos = new Vector3(-0.2f, y, 0);
        }
        else
        {
            movePos = new Vector3(-1 * movePos.x, y, 0);
        }
    }
}
