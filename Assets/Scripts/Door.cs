using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    private bool concluido;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        concluido = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().concluido;
	
	}

    void OnTriggerEnter (Collider col) {
        if (concluido && col.gameObject.tag == "Player")
        {
            var thedoor = GameObject.FindGameObjectWithTag("SF_Door");
            thedoor.animation.Play("open");
        }
}

void OnTriggerExit (Collider col) {
    if (concluido && col.gameObject.tag == "Player")
    {
        var thedoor = GameObject.FindGameObjectWithTag("SF_Door");
        thedoor.animation.Play("close");
    }

}


}
