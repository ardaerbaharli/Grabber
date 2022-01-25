using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string volumParameter = "MasterVolume";
 //  [SerializeField] string backgroundParameter = "BackgroundEffectVolume";
 //   [SerializeField] string soundEffectParameter = "SoundEffectVolume";
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider slider;
    [SerializeField] private float multiplier = 30f;
    [SerializeField] Toggle toggle;
    private bool disableToggleEvent;

    public AudioSource backGroundAudio;
    public AudioSource[] soundEffectsAudio;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
        toggle.onValueChanged.AddListener(HanldeToggleValueChanged);
    }
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumParameter, slider.value);
    }
    private void HanldeToggleValueChanged(bool enableSound)
    {
        if (disableToggleEvent)
            return;

        if (enableSound)
            slider.value = slider.maxValue;
        else
            slider.value = slider.minValue + 0.0001f;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumParameter, slider.value);
    }

    private void HandleSliderValueChanged(float value)
    {
        mixer.SetFloat(volumParameter, value: Mathf.Log10(value) * multiplier);
        disableToggleEvent = true;
        toggle.isOn = slider.value > slider.minValue;
        disableToggleEvent = false;
    }

    public void UpdateSound()
    {
        backGroundAudio.volume = slider.value;
        for(int i=0;i<soundEffectsAudio.Length;i++)
        {
            soundEffectsAudio[i].volume = slider.value;
        }
    }

}
