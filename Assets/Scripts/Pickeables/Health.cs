using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] Image playerLifebar;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxPick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FloorDetect.CheckLayerInMask(playerMask, collision.gameObject.layer))
        {

            if (playerLifebar.fillAmount < 1)
            {
                AudioSource.clip = SfxPick;
                AudioSource.Play();

                Destroy(gameObject);
                playerLifebar.fillAmount += 0.25f;
            }
        }

    }
}
