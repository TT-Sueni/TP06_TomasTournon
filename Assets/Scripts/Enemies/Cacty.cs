using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Cacty : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask bulletMask;
    [SerializeField] private Image enemyLife;
    [SerializeField] GameObject enemy;
    [SerializeField] private ParticleSystem enemyParticle;
    [SerializeField] private Playermovement playermovement;

    Rigidbody2D rb;
    Vector2 loopRight = new Vector2(3, 0);
    Vector2 loopLeft = new Vector2(-3, 0);
    float looptime;

    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxEnemy;
    [SerializeField] SpriteRenderer sp;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        looptime = 0;
    }
    void Update()
    {
        looptime += Time.deltaTime;
        if (looptime < 2)
        {
            rb.velocity = loopRight;
            sp.flipX = true;
        }
        else if (looptime >= 3)
        {

            rb.velocity = loopLeft;
            sp.flipX = false;
          

            if (looptime >= 6)
            {

                looptime = 0;
            }
        }

        if (enemyLife.fillAmount <= 0)
        {
            Destroy(enemy);
            Instantiate(enemyParticle, transform.position, quaternion.identity);
            enemyParticle.Play();
            AudioSource.clip = SfxEnemy;
            AudioSource.Play();

        }

    }
    private void OnTriggerEnter2D(Collider2D other) // cuando toca un enemigo, insertar danio
    {
        if (FloorDetect.CheckLayerInMask(bulletMask, other.gameObject.layer))
        {
            if (playermovement.powerUp)
            {
                enemyLife.fillAmount -= 0.50f;
            }
            else
            {

                enemyLife.fillAmount -= 0.25f;
            }
        }
    }
}
