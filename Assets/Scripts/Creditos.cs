using UnityEngine;
using System.Collections;

public class Creditos : MonoBehaviour {

	public float duracao;
	private float contagem;
	private GUIStyle style;
	// começo da cena
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		contagem += Time.deltaTime;
		if (contagem >= duracao) {
			Application.LoadLevel("MainMenu");
		}
	}
	void OnGUI() {
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 500, 400), "<size=18><color=red><b>Game Over!</b></color></size>");
		//inicia grupo de conteudo
       
        GUI.Box(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 50, 250, 50), "<size=18>Criadores:</size>");
        GUI.Box(new Rect(Screen.width / 2 + 30, Screen.height / 2, 250, 50), "<size=18>Lucas Rocha</size>");
        GUI.Box(new Rect(Screen.width / 2 + 30, Screen.height / 2 + 50, 250, 50), "<size=18>Pedro Viviani</size>");
        GUI.Box(new Rect(Screen.width / 2 + 30, Screen.height / 2 + 100, 250, 50), "<size=18>Rodolfo Soken</size>");
        GUI.Box(new Rect(Screen.width / 2 + 30, Screen.height / 2 + 150, 250, 50), "<size=18>Tito Spadini</size>");
        if (GUI.Button(new Rect(Screen.width / 2 + 30, Screen.height / 2 + 200, 250, 50), "<size=18>Voltar</size>"))
        {
            if (GameController._instance != null)
            {
                Application.LoadLevel(GameController._instance.currentLevelName);
            }
            else
            {
                Application.LoadLevel("MainMenu");
            }
        }

	}


}
