using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxPick;
    [SerializeField] UIManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FloorDetect.CheckLayerInMask(playerMask, collision.gameObject.layer))
        {
            manager.moneyCounter++;
            AudioSource.clip = SfxPick;
            AudioSource.Play();

            Destroy(gameObject);
            
        }

    }
}
