using UnityEngine;
using System.Collections;

public class Tutorial2 : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

    void OnGUI()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
        GUI.Box(new Rect(Screen.width / 2 - 350, Screen.height / 2 - 100, 650, 250),
            "<size=18><color=red><b>Objetivos Gerais</b></color></size>"
            + "\n\n\n <size=18> Destrua todos os Geradores de Inimigos"
            +"\n Fique de olho no Timer do Canto Superior Esquerdo"
            +"\n Ele será a sua vida, pontuação e tempo limite para passar de fase."
            +"\n Inimigos são fonte de Tempo, então tente explorar o cenario"
            +"\n e Destruir os geradores mais distantes do portal"
            +"\n para que haja tempo de caminhar até o portal</size>"           
            );
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 90, 250, 50), "OK"))
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
            Destroy(this.gameObject);
        }
    
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
