using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed;
    public int damage;

    public Animator animator;
    public AnimationClip explosionclip; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        animator.SetBool("shoted", true);
        
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        HealthManagement enemy = other.GetComponent<HealthManagement>();
        if(other.gameObject.tag != "Bullet" && other.gameObject.tag != "BulletEnemy" && other.gameObject.tag != "GameController" && other.gameObject.tag != "Player"){
            if(enemy != null){
                enemy.TakeDamage(damage);
                animator.SetBool("shoted", false);
                animator.SetBool("hited", true);
                speed = 0;
                animator.Play("explode");
                Destroy(this.gameObject,explosionclip.length);
            }else{
                animator.SetBool("shoted", false);
                animator.SetBool("hited", true);
                speed = 0;
                animator.Play("explode");
                Destroy(this.gameObject,explosionclip.length);
            }
            
        }
    }
}
