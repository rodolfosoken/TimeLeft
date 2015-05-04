using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization

    float timer = 100.0f;
    float plusTime = 10.0f;
    bool guiShow = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
        }
	
	}


    void OnGUI()
    {
        GUI.Box(new Rect(10, 20, 100, 30), "" + timer.ToString("0"));

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
