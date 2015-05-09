using UnityEngine;
using System.Collections;

public class ColliderEspada : MonoBehaviour {

    Collider col;
    public Transform player;
    Transform enemy;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        //Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
       // Physics.IgnoreCollision(GameObject.Find("DynamicObject").transform.GetComponent<Collider>(), GetComponent<Collider>());
        enemy = GameObject.Find("roBot").transform;
        
        //Physics.IgnoreCollision(GameObject.Find("Espada").transform.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void OnTriggerStay(Collider other)
    {
     
        //print("Still colliding with trigger object " + other.name);
       
        Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
  
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Tigger com o " + col.gameObject.name);
            float dist = Vector3.Distance(transform.position, col.transform.position);

            col.GetComponent<EnemyBehaviour>().TakeDamage();  
        }

            

    }


	
	// Update is called once per frame
	void Update () {


	}
}
