using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBehavior : MonoBehaviour
{
    public float numberOfEnemy;
    public float xAxisWalk;
    private float start;

    public GameObject enemySpawn;

    private Vector2 velocity;

    Vector2 whereSpawn;
    public Transform spawn0;

    private Rigidbody2D myScriptsRigidbody2D;

    public Animator animator;
    public AnimationClip finishOpening;

    void Start()
    {
        start = transform.position.x;
        animator.SetBool("isMoving",true);
        myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(finishOpening.length);
        if(transform.position.x >= start - 10f){
            transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
        }else{
            animator.SetBool("isMoving",false);
        }

        if(GetComponent<HealthManagement>().enemyHealth <= 0){
            DestroyImmediate(GetComponent<Collider2D>());
            myScriptsRigidbody2D.gravityScale = 0;
            transform.gameObject.tag = "Untagged";
        }
    }

    void spawn(){
        if(numberOfEnemy >= 0){
            whereSpawn = new Vector2(spawn0.position.x,spawn0.position.y);
            Instantiate(enemySpawn, whereSpawn, spawn0.rotation);
            numberOfEnemy--;
        }
    }

    void setTrue(){
        animator.SetBool("doorOpen",true);
    }

    
}
