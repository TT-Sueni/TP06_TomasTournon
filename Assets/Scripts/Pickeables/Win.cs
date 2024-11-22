using UnityEngine.UI;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] LayerMask playerMask;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject inGamePanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FloorDetect.CheckLayerInMask(playerMask, collision.gameObject.layer))
        {
            winPanel.SetActive(true);
            inGamePanel.SetActive(false);
            
            Destroy(gameObject);


        }

    }
}
