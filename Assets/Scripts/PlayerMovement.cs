using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement Instance;

    Vector2 vel;
    public float grav;
    public float thrust;
    public float rotSpd;
    public ParticleSystem pSys;
    Rigidbody2D rb;
    public GameObject deathPart;
    AudioSource aud;
    public GameObject bullet;
    

	// Use this for initialization
	void Start () {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, transform.position + (transform.up * .2f), Quaternion.Euler(0,0, transform.eulerAngles.z + 90f));
        }


    }

    private void FixedUpdate() {
        vel.y -= grav;
        if (Input.GetKey(KeyCode.UpArrow)) {
            vel += Geo.ToVect(transform.eulerAngles.z+90f) * thrust;
            pSys.Play();
            if (!aud.isPlaying) aud.Play();
        } else {
            pSys.Stop();
            aud.Stop();
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - rotSpd);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + rotSpd);
        }
        rb.MovePosition((Vector2)transform.position + vel);

    }


    private void OnCollisionEnter2D(Collision2D coll) {
        Instantiate(deathPart, transform.position, transform.rotation);
        GameManager.me.deathText.SetActive(true);
        Destroy(gameObject);
    }
}
