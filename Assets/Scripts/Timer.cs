using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization

    public float time = 100.0f;
    float plusTime = 10.0f;
    bool guiShow = false;
    public static Timer _timer;

	void Start () {
	
	}

    void Awake()
    {
        _timer = this;
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            GetComponent<PlayerBehaviour>().die();
        }
	
	}

    public void plustime(int n)
    {
        time+=n;
    }
    public void minustime(int n)
    {
        time -= n;
    }


    void OnGUI()
    {
        GUI.Box(new Rect(10, 20, 100, 30), "" + time.ToString("0"));

        if (guiShow == true)
        {
            GUI.Box(new Rect(65, 10, 50, 20), "+" + plusTime.ToString("0"));
            ShowGUI();
        }
    }

    IEnumerator ShowGUI()
    {
        yield return new WaitForSeconds(2);
	guiShow = false;
    }
}
