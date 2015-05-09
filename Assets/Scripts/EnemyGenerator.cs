using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {


    //Tempo decorrido
    private float elapsedTime;

    //frequencia para criar inimigos
    public float frequency = 0.1f;

    //prefab inimigo
    public Transform enemy;
    public Transform enemyGroup;
    

	// Use this for initialization
	void Start () {
       
      
	}
	
	// Update is called once per frame
    void Update()
    {
        
        elapsedTime += Time.deltaTime;
        if (0.9f < (Mathf.Sin(elapsedTime * frequency)) && 16 > enemyGroup.childCount)
        {
            Transform newEnemy = Instantiate(enemy, new Vector3(transform.position.x-3, 0, transform.position.z), Quaternion.identity) as Transform;
            newEnemy.parent = enemyGroup.transform;
        }
    }
}
