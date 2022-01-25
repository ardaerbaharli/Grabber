using UnityEngine;

public class AudioSettingsTutorial : MonoBehaviour
{
    private static readonly string volumParameter = "MasterVolume";
    private float sliderValueFloat = 30f;
    public AudioSource backGroundAudio;
    public AudioSource[] soundEffectsAudio;
    private void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    {
        sliderValueFloat = PlayerPrefs.GetFloat(volumParameter);
        backGroundAudio.volume = sliderValueFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = sliderValueFloat;
        }
    }
}
