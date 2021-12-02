using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]


public class PlayerController : MonoBehaviour
{
    
    public float speed = 9;
    public float walkAcceleration = 75;
    public float groundDeceleration = 50;
    public int lifeCount;
    public int ammoValue;
    public bool grounded;

    private Rigidbody2D rb;

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    public bool hited = false;
    private bool isJumping;
    private bool crouch;
    private bool m_FacingRight;
    private bool on_air;

    public float checkRadius;
    public Transform feetPos;
    public LayerMask whatIsGround;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;

    private float time = 4;
    public float invincibleTime;

    public Animator animator;
    public AnimationClip hitedClip;
    public Transform respawnPoint;

    public float moveInput;

   
    private void Awake()
    {

        animator.SetBool("isHited", false);
        ScoreScript.scoreValue = 0;
        LifeCount.lifeCount = lifeCount;
        AmmoScript.ammoValue = 99999;
        jumpTimeCounter = jumpTime;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
      
    }

    private void Update()
    {
        if(ScoreScript.scoreValue >= 3000){
            LifeCount.lifeCount += 1;
            ScoreScript.scoreValue -= 3000;
        }
        if(lifeCount == 0){
            Die();
        }
    }

    void FixedUpdate()
    {
        AmmoScript.ammoValue = GetComponent<Weapon>().ammo;
        time += Time.deltaTime;
        if(!hited){
            grounded = Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround);
            on_air = true;

            moveInput = Input.GetAxisRaw("Horizontal");         

            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            
            // MOVE DIRECTIONS
            if (moveInput != 0)
            {
                
                if (moveInput > 0 && m_FacingRight)
                {
                    Flip();
                    FindObjectOfType<AudioManager>().Play("player_run");
                }
                else if (moveInput < 0 && !m_FacingRight)
                {
                    FindObjectOfType<AudioManager>().Play("player_run");
                    Flip();
                }

                if(crouch == false){
                    // velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, walkAcceleration * Time.deltaTime);
                    velocity.x +=  (transform.right * moveInput * walkAcceleration * Time.deltaTime).x; 
                    
                    if(velocity.x > speed){
                        velocity.x = speed;
                    }
                }
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, groundDeceleration * Time.deltaTime);
            }
            
            //CROUCH
            if(Input.GetKey(KeyCode.S) && grounded == true){
                // GetComponent<Weapon>().isCrouch = true;
                crouch = true;
                animator.SetBool("isCrouching", true);
                velocity.x = 0;
            }
            else{
                crouch = false;
                animator.SetBool("isCrouching", false);
                // GetComponent<Weapon>().isCrouch = false;
            }

            // JUMP
            if(grounded == true && (Input.GetKeyDown(KeyCode.Space) )){
                FindObjectOfType<AudioManager>().Play("player_run");
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }
            if(Input.GetKey(KeyCode.Space) && isJumping == true){
                if(jumpTimeCounter > 0){
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                    on_air = true;
                }else{
                    isJumping = false;
                }
            }

            if(Input.GetKeyUp(KeyCode.Space)){
                isJumping = false;
            }

            // ON AIR
            if(on_air == true){
                animator.SetBool("isJumping", true);
            }

            // ON GROUND
            if(grounded == true){
                on_air = false;
                animator.SetBool("isJumping", false);
            }

            transform.Translate(velocity * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(time >= invincibleTime){
            if(other.CompareTag("BulletEnemy")){
                if(!hited){
                    lifeCount -= 1;
                    animator.SetBool("isHited", true);
                    hited = true;
                    animator.Play("Hited");
                    LifeCount.lifeCount = lifeCount;
                    FindObjectOfType<AudioManager>().Play("player_die");
                    time = 0;
                }
            }
        }

        if(other.CompareTag("WeaponItem")){
            Debug.Log("Achou o item");
            WeaponCollectScript weapon = other.GetComponent<WeaponCollectScript>();
            GetComponent<Weapon>().bulletPrefab = weapon.weapon;
            GetComponent<Weapon>().fireRate = weapon.fireRate;
            GetComponent<Weapon>().ammo = weapon.ammo;
            AmmoScript.ammoValue = GetComponent<Weapon>().ammo;
            Destroy(weapon.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(time >= invincibleTime){
            if(other.gameObject.CompareTag("Enemy")){
                if(!hited){
                    lifeCount -= 1;
                    animator.SetBool("isHited", true);
                    hited = true;
                    animator.Play("Hited");
                    LifeCount.lifeCount = lifeCount;
                    FindObjectOfType<AudioManager>().Play("player_die");
                    time = 0;
                }
            }
        }
    }

    void Respawn(){
        animator.SetBool("isHited", false);
        hited = false;
        animator.Play("idle");
        transform.position = respawnPoint.position;

    }

    void Die(){
        SceneManager.LoadScene("GameOver");
        Destroy(this.gameObject);
    }

    // FLIPING CARACTER
    void Flip()
    {
        FindObjectOfType<AudioManager>().Play("player_run");
        m_FacingRight = !m_FacingRight;
		transform.Rotate(0f,180f,0f);
    }
}
