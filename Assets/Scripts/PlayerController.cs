using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource audioSource;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tilt;
    public GameObject shot;
    public Transform[] shots;
    public float fireRate;
    private float nextFire;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (GameObject.Find("GameController").GetComponent<GameController>().score > 100 && (SceneManager.GetActiveScene().buildIndex == 2))
            {
                foreach (var shotSpawn in shots)
                {
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            }
            else
            {
                Instantiate(shot, shots[0].position, shots[0].rotation);
            }    
            audioSource.Play(); //Playing the audio when the player fires
        }
	}
    
    //Called for each physics step
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        rb.velocity = new Vector3 (speed*moveHorizontal, 0.0f, speed*moveVertical);
        rb.position = new Vector3 (Mathf.Clamp (rb.position.x, xMin, xMax), 0.0f, Mathf.Clamp (rb.position.z, zMin, zMax));
        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt );
    }
}
