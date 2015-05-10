using UnityEngine;
using System.Collections;

public class Tutorial1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    void OnGUI()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
        GUI.Box(new Rect(Screen.width / 2 - 350, Screen.height / 2 - 100, 650, 250),
            "<size=18><color=red><b>Comandos Básicos</b></color></size>"
            + "\n\n\n <size=18>Andar: Utilize as teclas A, W, D"
            +"\n Ataque Primário: Mouse Esquerdo (ME)"
            +"\n Defender: Mouse Direito (MD)"
            +"\n Ataque Rotativo: Segure MD e depois o ME</size>"           
            );
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 60, 250, 50), "OK"))
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
