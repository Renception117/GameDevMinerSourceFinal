using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    public void SetVolume(float val)
    {
        mixer.SetFloat("volume", val);
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void Start()
    {
        float tempVal;
        mixer.GetFloat("volume", out tempVal);
        slider.value = tempVal;
    }

}
