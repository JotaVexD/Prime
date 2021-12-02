using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FixCamBossScript : MonoBehaviour
{
    public GameObject enemySpawn1;
    public GameObject enemySpawn2;
    public GameObject enemySpawn3;

    public GameObject checkEnemy;

    public Collider2D direita;
    public Collider2D esquerda;
    public Collider2D meio;

    public CinemachineVirtualCamera vcam;
    public Transform player;
    Vector2 whereToSpawn0;
    Vector2 whereToSpawn1;
    Vector2 whereToSpawnCaminhão;
    Vector2 whereToSpawnBoss;
    public Transform spawn0;
    public Transform spawn1;
    public Transform spawnCaminhao;
    public Transform boss;

    public bool isActive;
    
    void Update() {
        if(!checkEnemy.GetComponent<CheckEnemyScript>().eventActive){
            direita.enabled = false;
            esquerda.enabled = false;
            isActive = true;
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isActive = false;
            meio.enabled = false;
            direita.enabled = true;
            esquerda.enabled = true;
            if(isActive == false){
                if(other.CompareTag("Player")){
                    vcam.Follow = null;
                    vcam.m_Lens.OrthographicSize = 18;
                    whereToSpawn0 = new Vector2(spawn0.position.x,spawn0.position.y);
                    whereToSpawn1 = new Vector2(spawn1.position.x,spawn0.position.y);
                    whereToSpawnCaminhão = new Vector2(spawnCaminhao.position.x,spawnCaminhao.position.y);
                    whereToSpawnBoss = new Vector2(boss.position.x,boss.position.y);
                    Instantiate(enemySpawn1, whereToSpawn0, spawn0.rotation);
                    Instantiate(enemySpawn1, whereToSpawn1, spawn0.rotation);
                    Instantiate(enemySpawn2, whereToSpawnCaminhão, spawnCaminhao.rotation);
                    Instantiate(enemySpawn3, whereToSpawnBoss, boss.rotation);
                }
            }
        }
    }
}
