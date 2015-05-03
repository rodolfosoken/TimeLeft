﻿using UnityEngine;
using System.Collections;

public class ColliderTest : MonoBehaviour {

    Collider col;
    Transform player;
    Transform enemy;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        enemy = GameObject.Find("roBot").transform;
        
        //Physics.IgnoreCollision(GameObject.Find("Espada").transform.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void OnTriggerStay(Collider other)
    {
        //print("Still colliding with trigger object " + other.name);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "roBot")
        {
            Debug.Log("Tigger com o " + col.gameObject.name);
            float dist = Vector3.Distance(transform.position, col.transform.position);

            col.GetComponent<Animator>().SetTrigger("hit");  
        }

            

    }


	
	// Update is called once per frame
	void Update () {


	}
}