using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private Animation anim;
   
    Transform player;               // Reference to the player's position.
    public float moveSpeed = 0.0F;
    private Vector3 lastPosition;

    public float speed = 2.0f;
    public float range = 15.0f;
    Rigidbody EnemyRigidbody;
    bool IsWalking;

    public float rotateSpeed = 3.0f;


    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;

        lastPosition = transform.position;

         anim = GetComponent<Animation>();

         EnemyRigidbody = GetComponent<Rigidbody>();
    }


    void Update ()
    {
        
        // Store the input axes.
        float h = Vector3.Distance(transform.position , player.position);
        //
        Animating(h);

        // Move the controller
        Move();

    }

    void Move(){
        if (IsWalking)
        {

            if (player)
            {
                Vector3 delta = player.position - transform.position;
                delta.Normalize();
                float moveSpeed = speed * Time.deltaTime;
                delta.y = 0;
                transform.position = transform.position + (delta * moveSpeed);
            }

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

    void Animating(float dist)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        IsWalking = dist > range;
        print("distancia: " + dist + IsWalking);
        if (IsWalking)
        {
            // Tell the animator whether or not the player is walking.
            anim.CrossFade("loop_walk_funny");
        }
        else
        {
            anim.CrossFade("punch_hi_left");
        }

    }

}
