using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform[] firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabDefault;
    public GameObject Player;
    
    private int value_array;
    private float time = 0;
    public float fireRate;
    public int ammo;

    public bool isShoting = false;
    public bool isMoving = false;
    public bool isCrouch;
    private float timer = 0f;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(ammo > 0){
            if(!GetComponent<PlayerController>().hited){
                if(Player.GetComponent<PlayerController>().moveInput != 0){
                    time += Time.deltaTime;
                    if(Player.transform.rotation.y < 0){
                        if(time >= fireRate){
                            if(Input.GetKey(KeyCode.RightArrow)){
                                if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 7;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 6;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.DownArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else{
                                    value_array = 3;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.LeftArrow)){
                                if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else{
                                    value_array = 0;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.UpArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 4;
                                    Shoot(value_array);
                                }
                            }
                        time = 0;
                        }
                    }else{
                        if(time >= fireRate){
                            if(Input.GetKey(KeyCode.RightArrow)){
                                if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else{
                                    value_array = 0;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.DownArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 7;
                                    Shoot(value_array);
                                }else{
                                    value_array = 3;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.LeftArrow)){
                                if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 7;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 6;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.UpArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 4;
                                    Shoot(value_array);
                                }
                            }
                        time = 0;
                        }
                    }
                }else{
                    if(isShoting == false){
                        changeAnimation(8);
                    }
                    time += Time.deltaTime;
                    if(Player.transform.rotation.y < 0){
                        if(time >= fireRate){
                            if(Input.GetKey(KeyCode.RightArrow)){
                                if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 7;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 6;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.DownArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else{
                                    value_array = 3;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.LeftArrow)){
                                if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else{
                                    value_array = 0;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.UpArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 4;
                                    Shoot(value_array);
                                }
                            }
                        time = 0;
                        }
                    }else{
                        if(time >= fireRate){
                            if(Input.GetKey(KeyCode.RightArrow)){
                                if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else{
                                    value_array = 0;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.DownArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 2;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 7;
                                    Shoot(value_array);
                                }else{
                                    value_array = 3;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.LeftArrow)){
                                if(Input.GetKey(KeyCode.DownArrow)){
                                    value_array = 7;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.UpArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 6;
                                    Shoot(value_array);
                                }
                            }else if(Input.GetKey(KeyCode.UpArrow)){
                                if(Input.GetKey(KeyCode.RightArrow)){
                                    value_array = 1;
                                    Shoot(value_array);
                                }else if(Input.GetKey(KeyCode.LeftArrow)){
                                    value_array = 5;
                                    Shoot(value_array);
                                }else{
                                    value_array = 4;
                                    Shoot(value_array);
                                }
                            }
                        time = 0;
                        }
                    }
                }
            }
        }else if(ammo <= 0){
            changeWeaponDefault();
        }
        if(timer >= fireRate){
            changeAnimation(8);
        }
        // if(isCrouch == false){
        //     changeAnimation(0);
        // }
        
    }

    void Shoot(int value){
        // if(Player.GetComponent<PlayerController>().moveInput != 0){
        timer = 0f;
        isShoting = true;
        changeAnimation(value);
        FindObjectOfType<AudioManager>().Play("pistol_fire");
        GameObject go = Instantiate(bulletPrefab,firePoint[value].position,firePoint[value].rotation);
        Destroy(go,5);
        if(ammo != 99999){
            ammo -= 1;
        }
    }
    
    void changeWeaponDefault(){
        bulletPrefab = bulletPrefabDefault;
        ammo = 99999;
        fireRate = 0.5f;
    }

    public void changeAnimation(int value){
        animator.SetInteger("shoting", value);
    }
}
