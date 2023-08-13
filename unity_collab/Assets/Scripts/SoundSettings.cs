using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("soundVolume"))
        {
            LoadVolume();
        }
        else{
            SetSoundVolume();
        }


        SetSoundVolume();
    }


    public void SetSoundVolume()
    {
        float volume = soundSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("soundVolume", volume);
    }

    private void LoadVolume()
    {
        soundSlider.value = PlayerPrefs.GetFloat("soundVolume");

        SetSoundVolume();
    }
}
