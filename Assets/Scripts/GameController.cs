using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController _instance;
    //indica se o objetivo da fase foi concluido
    public bool concluido;
    private Transform Objective;

    public string mainMenuSceneName;
    public Font pauseMenuFont;

    //pausa o jogo
    private bool pauseEnabled;

    private bool showGraphicsDropDown;

    private GUIStyle fonte;
    private GUIStyle fonteT;

    private Transform player;
    public string currentLevelName;

    void Awake()
    {
        _instance = this;
        Objective = GameObject.Find("Objective").transform;
        pauseEnabled = false;
        showGraphicsDropDown = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentLevelName = Application.loadedLevelName;
     
    }
	// Use this for initialization
	void Start () {
        concluido = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        currentLevelName = Application.loadedLevelName;

        if (player.GetComponent<PlayerBehaviour>().IsDead)
        {
            StartCoroutine(death());
        }

        //verifica se o botao esc foi pressionado
        if (Input.GetKeyDown("escape"))
        {
            //verifica se o jogo já está pausado
            if (pauseEnabled == true)
            {
                //unpause the game
                unPause();
            }

           //se o jogo não estiver pausado, então pause
            else if (pauseEnabled == false)
            {
                pause();
               // Screen.showCursor = true;
            }
        }


        //verifica se todos os geradores foram destruidos
        if (Objective.childCount == 0)
        {
            concluido = true;
        }
	
	}

    void OnGUI()
    {

        GUI.skin.box.font = pauseMenuFont;
        GUI.skin.button.font = pauseMenuFont;

        if (pauseEnabled == true)
        {

            //background box
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 250), "<size=18>Pause Menu</size>");

            //faz o botão do Main
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 50), "Main Menu"))
            {
                Application.LoadLevel(mainMenuSceneName);
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
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 50), "Restart"))
            {
                unPause();
                Application.LoadLevel(currentLevelName);
            }

            //sai do jogo
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 250, 50), "Quit Game"))
            {
                Application.Quit();
            }
        }
    }

    public void pause()
    {
        pauseEnabled = true;
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    public void unPause()
    {
        //unpause
        pauseEnabled = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;
        }

    IEnumerator death()
    {
        
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Creditos");
        
    }

}
