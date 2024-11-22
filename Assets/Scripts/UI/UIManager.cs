
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mainPanel;




    [Header("Button")]
    [SerializeField] public Button optionsButton;
    
    [SerializeField] public Button optionsExitButton;
    [SerializeField] public Button menuOptionsButton;
    [SerializeField] public Button menuExitButton;
    [SerializeField] public Button menuPlayButton;
    [SerializeField] public Button menuWinButton;


    [Header("Audio")]
    [SerializeField] private AudioSource audioSourceButton;
    [SerializeField] AudioClip SFXUI;
    [SerializeField] private TMP_Text lifeText;

    public int moneyCounter;


    private void Awake()
    {
        Time.timeScale = 1;
        optionsButton.onClick.AddListener(OnOptionsButtonClicked);
        optionsExitButton.onClick.AddListener(OnOptionsExitButtonClicked);
        menuOptionsButton.onClick.AddListener(OnMenuOptionsButtonClicked);
        menuExitButton.onClick.AddListener(OnMenuExitButtonClicked);
        menuPlayButton.onClick.AddListener(OnmenuPlayButtonClicked);
        menuWinButton.onClick.AddListener(OnWinExitButtonClicked);




    }
    private void Update()
    {
        setMoneyCount();
    }


    private void OnOptionsButtonClicked()
    {
        Time.timeScale = 0;
        inGamePanel.SetActive(false);
        mainPanel.SetActive(true);
        audioSourceButton.clip = SFXUI;
        audioSourceButton.Play();
        

    }
    private void OnMenuButtonClicked()
    {
        Time.timeScale = 0;
        inGamePanel.SetActive(false);
        mainPanel.SetActive(true);
        audioSourceButton.clip = SFXUI;
        audioSourceButton.Play();
        

    }
    private void OnOptionsExitButtonClicked()
    {
        Time.timeScale = 1;
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        inGamePanel.SetActive(true);
        audioSourceButton.clip = SFXUI;
        audioSourceButton.Play();
       

    }
    private void OnmenuPlayButtonClicked()
    {
        Time.timeScale = 1;
        mainPanel.SetActive(false);
        inGamePanel.SetActive(true);
        audioSourceButton.clip = SFXUI;
        audioSourceButton.Play();
        

    }
    private void OnMenuExitButtonClicked()
    {
        audioSourceButton.clip = SFXUI;
        audioSourceButton.Play();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif


    }
    private void OnMenuOptionsButtonClicked()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        audioSourceButton.clip = SFXUI;
        audioSourceButton.Play();


    }
    private void OnWinExitButtonClicked()
    {
        audioSourceButton.clip = SFXUI;
        audioSourceButton.Play();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif


    }

    void setMoneyCount()
    {

        lifeText.SetText(moneyCounter.ToString());
        

    }


    private void OnDestroy()
    {

        optionsButton.onClick.RemoveAllListeners();
        optionsExitButton.onClick.RemoveAllListeners();
        menuOptionsButton.onClick.RemoveAllListeners();
        menuExitButton.onClick.AddListener(OnMenuExitButtonClicked);
        menuPlayButton.onClick.RemoveAllListeners();
        menuWinButton.onClick.RemoveAllListeners();

    }
}
