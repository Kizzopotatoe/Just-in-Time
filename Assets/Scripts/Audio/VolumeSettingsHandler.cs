using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeSettingsHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            UpdateMusicVolume();
            UpdateSFXVolume();
        }
    }

    public void UpdateMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void UpdateSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        musicSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        UpdateMusicVolume();
        UpdateSFXVolume();
    }

}
