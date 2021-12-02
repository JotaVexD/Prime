using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public int ammount;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            // randX = Random.Range(10.76f,12.76f);
            whereToSpawn = new Vector2(transform.position.x,transform.position.y);
            if(ammount > 0){
                Instantiate(enemy,whereToSpawn,Quaternion.identity);
                ammount--;
            }
        }
    }
}
