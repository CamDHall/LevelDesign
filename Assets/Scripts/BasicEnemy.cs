using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy {

    void FixedUpdate()
    {
        if (PlayerMovement.Instance != null)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, PlayerMovement.Instance.transform.position, Time.deltaTime));
        }
    }
}
