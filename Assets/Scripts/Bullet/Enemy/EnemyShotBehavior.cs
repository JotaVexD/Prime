using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotBehavior : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;

    public Animator animator;
    public AnimationClip explosionclip; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        FindObjectOfType<AudioManager>().Play("drone_fire");

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Bullet" && other.gameObject.tag != "BulletEnemy" && other.gameObject.tag != "GameController" && other.gameObject.tag != "Enemy" && other.gameObject.tag != "EnemySpawner"){
            DestroyProjectile();
        }
    }

    void DestroyProjectile(){
        animator.SetBool("shoted", false);
        animator.SetBool("hited", true);
        speed = 0;
        animator.Play("Explode");
        Destroy(this.gameObject,explosionclip.length);
    }

    
}
