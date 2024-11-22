using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] Playermovement playermovement;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxPick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FloorDetect.CheckLayerInMask(playerMask, collision.gameObject.layer))
        {
            playermovement.powerUp = true;
            AudioSource.clip = SfxPick;
            AudioSource.Play();

            Destroy(gameObject);
            
        }

    }
}
