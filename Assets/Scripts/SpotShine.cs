using UnityEngine;
using System.Collections;

public class SpotShine : MonoBehaviour {
    //Tempo decorrido do efeito
    private float elapsedTime;
    Light luz;

    //limites para a oscilação da luz
    public float magnitude = 0.2f;
    public float frequency = 10;
    float startRange;
	// Use this for initialization
	void Start () {
        luz = GetComponent<Light>();
        startRange = luz.range;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        luz.range = Mathf.Sin(elapsedTime * frequency) * magnitude + startRange;
	
	}
}
