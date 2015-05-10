using UnityEngine;
using System.Collections;

public class ColliderBarreira : MonoBehaviour {
    public Transform tutorial2; 
	// Use this for initialization
    bool once;
	void Start () {
        once = true;
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && once)
        {
            Instantiate(tutorial2);
            once = false;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
