using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuUIInteractions : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private ToggleSwitch soundToggle;
    [SerializeField] private ToggleSwitch vibrationToggle;

    [SerializeField] string volumParameter = "MasterVolume";
    [SerializeField] private AudioMixer mixer;


    private void Start()
    {
        soundToggle.valueChanged += ToggleSound;
        vibrationToggle.valueChanged += ToggleVibration;
        
        bool soundValue = PlayerPrefsX.GetBool("Sound", true);
        bool vibrationValue = PlayerPrefsX.GetBool("Vibration", true);

        soundToggle.Toggle(soundValue);
        vibrationToggle.Toggle(vibrationValue);
    }
    

    public void Start_Click()
    {
        SceneManager.LoadScene("1");
    }

    private void ToggleVibration(bool value)
    {
        PlayerPrefsX.SetBool("Vibration", value);
    }

    private void ToggleSound(bool value)
    {
        PlayerPrefsX.SetBool("Sound", value);
        float volume = value ? 0f : -80f;
        mixer.SetFloat(volumParameter, volume);
        
    }

    public void Settings_Click()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void CloseSettings_Click()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}