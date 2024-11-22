using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField] Button buttonStartGame;
    [SerializeField] Button buttonEndGame;

    private void Awake()
    {
        buttonStartGame.onClick.AddListener(OnButtonStartGameClicked);
        buttonEndGame.onClick.AddListener(OnButtonEndGameClicked);
    }
    void Update()
    {
        


    }

    

    private void OnButtonStartGameClicked()
    {
        SceneManager.LoadScene("SampleScene");

    }
    private void OnButtonEndGameClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnDestroy()
    {
        buttonStartGame.onClick.RemoveAllListeners();
        buttonEndGame.onClick.RemoveAllListeners();

    }
}
