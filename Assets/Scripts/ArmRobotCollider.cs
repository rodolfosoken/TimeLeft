using UnityEngine;
using System.Collections;

public class ArmRobotCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Tigger com o " + col.gameObject.name);
            float dist = Vector3.Distance(transform.position, col.transform.position);

            col.gameObject.GetComponent<PlayerBehaviour>().TakeDamage();
        }



    }


}
