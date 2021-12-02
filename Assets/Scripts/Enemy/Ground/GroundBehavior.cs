using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{

    public float speed;
    public Transform player;

    private bool lookingRight;

    private Rigidbody2D myScriptsRigidbody2D;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("speed",1f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);

        if((transform.position.x < player.position.x && !lookingRight) || (transform.position.x > player.position.x && lookingRight)){
            Flip();
        }
        if(GetComponent<HealthManagement>().enemyHealth <= 0){
            DestroyImmediate(GetComponent<Collider2D>());
            myScriptsRigidbody2D.gravityScale = 0;
            transform.gameObject.tag = "Untagged";
            speed = 0;
        }
    }

    void Flip(){
        lookingRight = !lookingRight;
        Vector3 face = transform.localScale;
		face.x *= -1;
        transform.localScale = face;
    }
    
}
