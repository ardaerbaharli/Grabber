using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string volumParameter = "MasterVolume";
    [SerializeField] AudioMixer mixer;
    [SerializeField] private float multiplier = 30f;
    [SerializeField] Toggle toggle;
    private bool disableToggleEvent;

    public AudioSource backGroundAudio;
    public AudioSource[] soundEffectsAudio;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(HanldeToggleValueChanged);
    }

    private void HanldeToggleValueChanged(bool enableSound)
    {
        if (disableToggleEvent)
            return;

       
    }


}
