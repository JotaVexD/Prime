using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public Transform player;
    public Transform firePoint0;
    public Transform firePoint1;
    public Transform firePoint2;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<HealthManagement>().enemyHealth > 0){
            if(timeBtwShots <= 0){

                Instantiate(projectile, firePoint0.position, Quaternion.identity);
                Instantiate(projectile, firePoint1.position, Quaternion.identity);
                Instantiate(projectile, firePoint2.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;

            }else {
                timeBtwShots -= Time.deltaTime;
            }
        }
        
    }
}
