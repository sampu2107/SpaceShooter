using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
	// Use this for initialization
	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find the gamecontroller object");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation); //Instantiating the VFX explosion 
        }
        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation); //Instantiating the VFX explosion for the player game object when it directly hits the asteroids 
            gameController.GameOver(); //Call Game over
        }
        if (other.tag != "Player")
        {
            gameController.AddScore(scoreValue);
        }
        Destroy(other.gameObject); //Destroy the bullet
        Destroy(gameObject); //Destroy the attached asteroid game object
    }
}
