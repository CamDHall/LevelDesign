using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager me;
    public GameObject deathText;

    public Text lives;

    private void Awake() {
        me = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);

        }

        if(PlayerMovement.Instance != null)
        {
            lives.text = "Lives: " + PlayerMovement.Instance.health;
        }
	}
}
