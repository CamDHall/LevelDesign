﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSprite : Enemy {

    private float RotateSpeed = 2f;
    private float Radius = 0.5f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    void Update () {
        if (PlayerMovement.Instance != null)
        {
            if(health <= 0)
            {
                Death();
            }
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) <= 8)
            {
                transform.localScale += (Vector3.one * (Time.deltaTime * 2));
            }
        }
	}

    private void FixedUpdate()
    {
        if (PlayerMovement.Instance != null)
        {
            // Rotate
            _angle += RotateSpeed * Time.deltaTime;

            // Move the ball in a circle
            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            rb.MovePosition(_centre + offset);
        }
    }
}
