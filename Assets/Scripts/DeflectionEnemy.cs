using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectionEnemy : Enemy {

    float Timer;

    public GameObject basicEnemy, bombEnemy, growthEnemy;
	void Start () {
        Timer = Time.time + 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerMovement.Instance != null && Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) <= 3)
        {
            if(Timer < Time.time)
            {
                SpawnEnemy();
                Timer = Time.time + 2;
            }
        }
	}

    void SpawnEnemy()
    {
        int choice = Random.Range(0, 5);

        Debug.Log(choice);
        float x = Random.Range(-2, 2);
        Vector3 Pos = new Vector3(transform.position.x + x, transform.position.y + 0.5f, 0);

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
}
