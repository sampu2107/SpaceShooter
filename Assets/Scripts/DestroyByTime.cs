using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float lifeTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime); //Destroying the explosions which are accumulating in the scene
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
