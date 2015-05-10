using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController _instance;
    public bool concluido;
    private Transform Objective;
    void Awake()
    {
        _instance = this;
        Objective = GameObject.Find("Objective").transform;
     
    }
	// Use this for initialization
	void Start () {
        concluido = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Objective.childCount == 0)
            concluido = true;
	
	}
}
