﻿using UnityEngine;
using System.Collections;

public class PopUpDamage : MonoBehaviour {

    private Vector3 position;
    private Vector3 screenPointPosition;
    private Camera cameraHold;
    private string text;
    private GUIStyle style;


	// Use this for initialization
	void Start () {

        cameraHold = Camera.main;
        screenPointPosition = cameraHold.WorldToScreenPoint(position);
	
	}
	
	// Update is called once per frame
	void Update () {
        screenPointPosition.y -= 1; 
	
	}

    public static void ShowMessage(string texto, Vector3 position)
    {
        var newInstance = new GameObject("Damage Popup");
        position.y = position.y + 10;
        var damagePopUp = newInstance.AddComponent<PopUpDamage>();
        damagePopUp.position = position;
        damagePopUp.text = ("<color=red><size=30>" + texto + "</size></color>");
    }

    void OnGUI()
    {
        var screenPX = cameraHold.WorldToScreenPoint(position);
        GUI.Label(new Rect(screenPX.x, screenPointPosition.y, 300, 300), text);
        DestroyObject(gameObject, 1);
    }

}
