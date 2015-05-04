﻿using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private Animator anim;
   
    Transform player;               // Reference to the player's position.
    private Vector3 lastPosition;

    public int life = 3;
    public float speed = 10.0f;
    public float range = 50.0f;
    bool IsWalking;

    public float rotateSpeed = 3.0f;
 


    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;

        lastPosition = transform.position;

         anim = GetComponent<Animator>();
         
      
    }


    void Update ()
    {
        
        float dist = Vector3.Distance(transform.position , player.position);
        //
       Animating(dist);

        if (dist > range)
        {
            anim.SetTrigger("idle");
            anim.SetBool("IsWalking", false);
        }
        else
        {
            if (IsWalking)
            {
                Move();
            }
           
        }


    }

    void Move(){
            if (player)
            {
                Vector3 delta = player.position - transform.position;
                delta.Normalize();
                float moveSpeed = speed * Time.deltaTime;
                delta.y = 0;
                transform.position = transform.position + (delta * moveSpeed);
                RotateTowardsTarget();
            
            }

    }

    private void RotateTowardsTarget()
    {
        // Cria um vetor do player ao inimigo
        Vector3 enemyToPlayer = player.position - transform.position;

        // Ensure the vector is entirely along the floor plane.
        enemyToPlayer.y = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemyToPlayer), rotateSpeed * Time.deltaTime);
    }

    void Animating(float distance)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        IsWalking = distance > 12;
        //print("distancia: " + distance + IsWalking);
        if (IsWalking)
        {
            // Tell the animator whether or not the player is walking.
            anim.SetBool("IsWalking",true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetTrigger("punch");

        }

        
    }

    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Player")
	{
        //col.gameObject.GetComponent<PlayerBehaviour>().TakeDamage();	 
	}
    }


    public void TakeDamage()
    {
        if (life > 0)
        {

            anim.SetTrigger("hit");
            life--;
            PopUpHitPoint.ShowMessage("+1", transform.position);
        }
        else
        {
            StartCoroutine(death());
           
        }
    }

    IEnumerator death()
    {
        anim.SetBool("die",true);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
