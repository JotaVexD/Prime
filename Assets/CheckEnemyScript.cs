using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckEnemyScript : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Transform player;
    private GameObject[] enemies;

    Vector2 whereSpawn;
    Vector2 whereSpawnDrop;

    public Transform spawnGo;
    public Transform spawnItem;
    public GameObject GO;
    public GameObject Drop;

    public bool eventActive = true;
    public bool show = false;

    private float time = 0;
    private float dontShow = 10;
    
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other) {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        time += Time.deltaTime;
        eventActive = true;
        
        if(enemies.Length == 0){
            vcam.Follow = player;
            if(time >= dontShow){
                eventActive = false;
            }
        }

        if(eventActive == false && show == false){
            whereSpawn = new Vector2(spawnGo.position.x,spawnGo.position.y);
            whereSpawnDrop = new Vector2(spawnItem.position.x,spawnItem.position.y);
            GameObject go = Instantiate(GO, whereSpawn, spawnGo.rotation);
            GameObject drop = Instantiate(Drop, whereSpawnDrop, spawnItem.rotation);
            show = true;
            Destroy(go,6);
        }
        
    }
}
