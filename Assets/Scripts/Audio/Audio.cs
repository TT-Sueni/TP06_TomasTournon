
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public Slider volumeWorldSlider;
    [SerializeField] public Slider volumeSFXSlider;
    [SerializeField] public Slider volumeUISlider;
    [SerializeField] public Slider volumeMusicSlider;



    void Awake()
    {
        volumeWorldSlider.onValueChanged.AddListener(SetGameplayVolume);
        volumeSFXSlider.onValueChanged.AddListener(SetSFXVolume);
        volumeUISlider.onValueChanged.AddListener(SetUIVolume);
        volumeMusicSlider.onValueChanged.AddListener(SetMusicVolume);

    }


    private void OnDestroy()
    {
        volumeWorldSlider.onValueChanged.RemoveAllListeners();
        volumeSFXSlider.onValueChanged.RemoveAllListeners();
        volumeUISlider.onValueChanged.RemoveAllListeners();
        volumeMusicSlider.onValueChanged.RemoveAllListeners();
    }
    private void SetGameplayVolume(float volume)
    {
        audioMixer.SetFloat("GameplayVolume", volume);
    }
    private void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);

    }
    private void SetUIVolume(float volume)
    {
        audioMixer.SetFloat("UIVolume", volume);

    }
    private void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);

    }
}
