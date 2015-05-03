using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

	public Transform player;
	public float speed = 2.0f;
    Rigidbody EnemyRigidbody;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
        EnemyRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (true)
        {
            
		if(player){
		Vector3 delta = player.position - transform.position;
		delta.Normalize();
		float moveSpeed = speed * Time.deltaTime;
        delta.y = 0;
		transform.position = transform.position + (delta * moveSpeed);
		}

        // Cria um vetor do player ao inimigo
        Vector3 enemyToPlayer = player.position - transform.position;

        // Ensure the vector is entirely along the floor plane.
        enemyToPlayer.y = 0f;

        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
        Quaternion newRotation = Quaternion.LookRotation(enemyToPlayer);

        // Set the player's rotation to this new rotation.
        EnemyRigidbody.MoveRotation(newRotation);

	}

        }
}
