
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float initialForce = 10.0f;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bullet;
    

   
    void Update()
    {

        transform.position += -transform.right * Time.deltaTime * initialForce;


    }
    private void OnTriggerEnter2D(Collider2D other) // cuando toca un enemigo, insertar danio
    {
        
            
            Destroy(bullet);


        
    }
}
