using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy {

    float startTime;

    private float RotateSpeed = 3f;
    private float Radius = 0.7f;

    private Vector2 _centre;
    private float _angle;

    // Use this for initialization
    void Start () {
        startTime = Time.time;

        _centre = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerMovement.Instance != null)
        {
            if (health <= 0)
            {
                Death();
            }
            // Explode
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < 5f)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime);
            }
        }
	}

    private void FixedUpdate()
    {
        if (PlayerMovement.Instance != null)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < 15f)
            {
                // Rotate
                _angle += RotateSpeed * Time.deltaTime;

                float stepAmount = (1f - Mathf.Cos(Time.time - startTime * Mathf.PI * 0.5f)) * Time.deltaTime;

                // Move centre closer to player
                _centre = Vector2.Lerp(_centre, PlayerMovement.Instance.transform.position, stepAmount);

                // Move the ball in a circle
                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                rb.MovePosition(_centre + offset);
            }
        }
    }
}
