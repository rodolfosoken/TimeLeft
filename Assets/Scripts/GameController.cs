using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool IsUnderAttack;
    public static GameController _instance;

    void Awake()
    {
        _instance = this;
        IsUnderAttack = false;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
