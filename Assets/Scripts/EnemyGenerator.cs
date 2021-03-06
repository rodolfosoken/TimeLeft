﻿using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {


    //Tempo decorrido
    private float elapsedTime;

    //frequencia para criar inimigos
    public float frequency = 10;

    //prefab inimigo
    public Transform enemy;
    public Transform enemyGroup;

    public float lifeStart = 60;
    private float life;
    //fogo pequeno de dano
    public Transform fireSmall;
    private bool once, once2;
    public Transform explosion;
    public Transform []fireGroup;
    AudioSource explosaoSom;

    Light luz;

	// Use this for initialization
	void Start () {

 
	}

    void Awake()
    {
        luz = GetComponentInChildren<Light>();
        life = lifeStart;
        once2 = once = true;
        fireGroup = new Transform[4];
        explosaoSom = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
    void Update()
    {
        StatusDamage();           
        elapsedTime -= Time.deltaTime;
        //Debug.Log("elpsedTime:"+elapsedTime+ "  Delta:"+Time.deltaTime);
        if (elapsedTime < 0 && 16 > enemyGroup.childCount)
        {
            Transform newEnemy = Instantiate(enemy, new Vector3(transform.position.x-3, 0, transform.position.z), Quaternion.identity) as Transform;
            newEnemy.parent = enemyGroup.transform;
            elapsedTime = frequency;
        }
    }

    void StatusDamage()
    {
        if (life < (lifeStart / 2) && once)
        {
            fireGroup[0] = Instantiate(fireSmall, new Vector3(transform.position.x - 3, 0, transform.position.z), Quaternion.identity) as Transform;
            fireGroup[1] = Instantiate(fireSmall, new Vector3(transform.position.x + 3, 0, transform.position.z - 2), Quaternion.identity) as Transform;
            fireGroup[2] = Instantiate(fireSmall, new Vector3(transform.position.x + 3, 0, transform.position.z - 2), Quaternion.identity) as Transform;
            fireGroup[3] = Instantiate(fireSmall, new Vector3(transform.position.x - 3, 0, transform.position.z + 2), Quaternion.identity) as Transform;
            luz.GetComponent<SpotShine>().frequency = 150;
            luz.GetComponent<SpotShine>().magnitude = 3;
            once = !once;
        }
        if (life <= 0 && once2)
        {
            Destroy(fireGroup[0].gameObject);
            Destroy(fireGroup[1].gameObject);
            Destroy(fireGroup[2].gameObject);
            Destroy(fireGroup[3].gameObject);
            explosaoSom.Play();
            luz.intensity = 0;
            gameObject.renderer.enabled = false;
            Destroy(this.gameObject,4);
            Instantiate(explosion, transform.position, Quaternion.identity);
            once2 = !once2;
    
        }



    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Espada")
        {
            float damage = col.gameObject.GetComponentInParent<PlayerBehaviour>().GetDamage();
            PopUpHitPoint.ShowMessage("-"+damage, transform.position);
            life -= damage;
        }
    }


}
