using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private bool showGraphicsDropDown;

	// Use this for initialization
	void Start () {
        showGraphicsDropDown = false;
	}

    void OnGUI()
    {
        //background box
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 250), "<size=30><b>Time Left</b></size>");

        //faz o botão do Main
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 50), "Start"))
        {
            Application.LoadLevel("Fase1");
        }


        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250, 50), "Change Graphics Quality"))
        {

            if (showGraphicsDropDown == false)
            {
                showGraphicsDropDown = true;
            }
            else
            {
                showGraphicsDropDown = false;
            }
        }


        if (showGraphicsDropDown == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2, 250, 50), "Fastest"))
            {
                QualitySettings.currentLevel = QualityLevel.Fastest;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 50, 250, 50), "Fast"))
            {
                QualitySettings.currentLevel = QualityLevel.Fast;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 100, 250, 50), "Simple"))
            {
                QualitySettings.currentLevel = QualityLevel.Simple;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 150, 250, 50), "Good"))
            {
                QualitySettings.currentLevel = QualityLevel.Good;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 200, 250, 50), "Beautiful"))
            {
                QualitySettings.currentLevel = QualityLevel.Beautiful;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 250, 250, 50), "Fantastic"))
            {
                QualitySettings.currentLevel = QualityLevel.Fantastic;
            }

            if (Input.GetKeyDown("escape"))
            {
                showGraphicsDropDown = false;
            }
        }

        //Restart
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 50), "Créditos"))
        {
            Application.LoadLevel("Creditos");
        }

        //sai do jogo
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 250, 50), "Quit Game"))
        {
            Application.Quit();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
