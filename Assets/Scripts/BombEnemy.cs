using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy {

    float startTime;

    private float RotateSpeed = 3f;
    private float Radius = 0.7f;

    private Vector2 _centre;
    private float _angle;

    bool exploding = false;
    float explosionTimer;
    public ParticleSystem ps;

    SpriteRenderer sp;

    // Use this for initialization
    void Start () {
        startTime = Time.time;

        _centre = transform.position;
        sp = GetComponent<SpriteRenderer>();
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
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < 2f && !exploding)
            {
                explosionTimer = Time.time + 0.2f;
                exploding = true;
            }

            if(exploding && explosionTimer > Time.time)
            {
                transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                sp.color += new Color(10, 10, 10);
            }

            if(exploding && explosionTimer < Time.time)
            {
                Instantiate(ps, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
	}

    private void FixedUpdate()
    {
        if (PlayerMovement.Instance != null)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < 8f)
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
