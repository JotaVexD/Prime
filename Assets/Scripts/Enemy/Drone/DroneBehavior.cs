using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehavior : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float detectPlayer;
    public Transform player;
    public Transform firePoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Rigidbody2D myScriptsRigidbody2D;

    private bool m_FacingRight;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myScriptsRigidbody2D = GetComponent<Rigidbody2D>();

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player.position) < detectPlayer){
            if(Vector2.Distance(transform.position,player.position) > stoppingDistance){
                transform.position = Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
            }else if(Vector2.Distance(transform.position,player.position) < stoppingDistance && Vector2.Distance(transform.position,player.position) > retreatDistance){
                transform.position = this.transform.position;
            }else if(Vector2.Distance(transform.position,player.position) < retreatDistance){
                transform.position = Vector2.MoveTowards(transform.position,player.position, -speed * Time.deltaTime);
            }
        
            if(GetComponent<HealthManagement>().enemyHealth > 0){
                if(timeBtwShots <= 0){

                    Instantiate(projectile, firePoint.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;

                }else {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }

        if(GetComponent<HealthManagement>().enemyHealth <= 0){
            DestroyImmediate(GetComponent<Collider2D>());
            myScriptsRigidbody2D.gravityScale = 0;
            transform.gameObject.tag = "Untagged";
            speed = 0;
        }

        // // FLIPING CARACTER
        // void Flip()
        // {
        //     m_FacingRight = !m_FacingRight;
        //     transform.Rotate(0f,180f,0f);
        // }
    }
}
