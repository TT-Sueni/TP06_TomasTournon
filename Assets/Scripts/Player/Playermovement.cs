
using UnityEngine;
using UnityEngine.UI;


public class Playermovement : MonoBehaviour
{
    [Header("Parametros")]
    [SerializeField] float speed = 1.0f;
    public float jumpForce = 10;
    [SerializeField] Image playerLifebar;
    public bool powerUp = false;
    public bool invincible = false;
    float invincibilityTimer;

    [Header("Movimiento")]

    [SerializeField] private KeyCode keyLeft = KeyCode.A;
    [SerializeField] private KeyCode keyRight = KeyCode.D;
    [SerializeField] private KeyCode shoot = KeyCode.R;
    [SerializeField] private KeyCode jump = KeyCode.W;
    [SerializeField] private Animator animator;
    [SerializeField] FloorDetect floorDetect;

    private Rigidbody2D rb;

    public bool flip = false;

    [Header("Objetos")]
    [SerializeField] private GameObject bullet;
    [SerializeField] Transform launchOffset;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private LayerMask playerMask;


    [Header("Audio")]
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxJump;
    [SerializeField] AudioClip SfxShoot;

   public  SpriteRenderer sr;



    private GameObject shot;
    


    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        invincibilityTimer = 0;

    }

    void Update()
    {
        Movevement();

        if (invincible)
        {
            invincibilityTimer += Time.deltaTime;
        }
        if (invincibilityTimer > 10)
        {
            invincible = false;
            invincibilityTimer = 0;
        }
    }


    private void Movevement()
    {
        if (Input.GetKeyDown(jump) && floorDetect.isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            AudioSource.clip = SfxJump;
            AudioSource.Play();

            floorDetect.isGrounded = false;



        }
       

        if (Input.GetKey(keyLeft))
        {

            rb.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            Quaternion flip = Quaternion.Euler(0, 0, 0);
            transform.rotation = flip;
            
            animator.SetTrigger("walk");
            


        }
        else if (Input.GetKeyUp(keyLeft))
        {
            
            rb.velocity = Vector3.zero;
            
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        if (Input.GetKey(keyRight))
        {
            
            animator.SetTrigger("walk");
            Quaternion flip = Quaternion.Euler(0, 180, 0);
            transform.rotation = flip;
            rb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            //SpeedLimit();
        }
        else if (Input.GetKeyUp(keyRight))
        {
           
            rb.velocity = Vector3.zero;
            
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(shoot))
        {
           
                Instantiate(bullet, launchOffset.position, transform.rotation);
            
            
            AudioSource.clip = SfxShoot;
            AudioSource.Play();
            animator.SetTrigger("Shot");

        }
        

    }



    private void OnTriggerEnter2D(Collider2D other) // cuando toca un enemigo, insertar danio
    {
        if (FloorDetect.CheckLayerInMask(enemyMask, other.gameObject.layer))
        {
            if (invincible)
            {
                
            }
            else 
            {
                playerLifebar.fillAmount -= 0.25f;

                animator.SetTrigger("hit");
            }
            
        }

    }



}

