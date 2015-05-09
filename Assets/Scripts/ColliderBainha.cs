using UnityEngine;
using System.Collections;

public class ColliderBainha : MonoBehaviour {

     // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {

            this.GetComponent<PlayerBehaviour>().TakeDamageBehind(3);
        }



    }



    // Update is called once per frame
    void Update()
    {


    }
}
