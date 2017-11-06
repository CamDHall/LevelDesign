using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    public Transform player;
    public float maxDist;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (player == null)
        {
            return;
        }
        else
        {
            if (player.position.x - transform.position.x > maxDist)
            {
                transform.position = new Vector3(player.position.x - maxDist, transform.position.y, -10);
            }
            if (player.position.x - transform.position.x < -maxDist)
            {
                transform.position = new Vector3(player.position.x + maxDist, transform.position.y, -10);
            }

            // Y
            if (player.position.y - transform.position.y > maxDist)
            {
                transform.position = new Vector3(transform.position.x, player.position.y - maxDist, -10);
            }
            if (player.position.y < -maxDist)
            {
                transform.position = new Vector3(transform.position.x, player.position.y + maxDist, -10);
            }
        }
    }
}
