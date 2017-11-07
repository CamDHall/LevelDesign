using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy {

    bool moving = false;

    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    void FixedUpdate()
    {
        if (PlayerMovement.Instance != null)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < 6)
            {
                moving = true;
            }

            if(moving)
            {
                rb.MovePosition(Vector3.Lerp(transform.position, PlayerMovement.Instance.transform.position, Time.deltaTime * speed));
            }
        }
    }
}
