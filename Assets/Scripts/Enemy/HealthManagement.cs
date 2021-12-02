using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour
{
    public int enemyHealth;
    public GameObject deathEffect;
    public int PointsOnDeath;

    private Renderer rend;
    private Color colorToTurnTo = Color.white;

    private float time = 0;
    private float delay = 0.8f;

    public Animator animator;
    public AnimationClip explosionclip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= delay){
            GetComponent<SpriteRenderer>().color = Color.white;
            time = 0;
        }
    }

    public void TakeDamage(int damage){
        enemyHealth -= damage;

        // if(time <= delay){
        //     colorToTurnTo = new Color(1, 0.6273585f, 0.6273585f, 1f);
        //     rend = GetComponent<Renderer>();
        //     rend.material.color = colorToTurnTo;
        // }
        GetComponent<SpriteRenderer>().color = new Color(1, 0.6273585f, 0.6273585f, 1f);
        if(enemyHealth <=0 ){
            Die();
            FindObjectOfType<AudioManager>().Play("drone_die");
        }
        time = 0;
    }

    void Die(){
        if(this.GetComponent<BossBehavior>() != null){
            SceneManager.LoadScene("GameOver");
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        // animator.SetBool("shoted", false);
        animator.SetBool("isDeath", true);
        animator.Play("Explode");
        ScoreScript.scoreValue += PointsOnDeath;
        Destroy(gameObject,explosionclip.length);
    }
}
