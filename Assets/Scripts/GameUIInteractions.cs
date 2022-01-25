using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIInteractions : MonoBehaviour
{
    [SerializeField] private GameObject gameObjects;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
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

    public void MainMenu_Click()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause_Click()
    {
        Time.timeScale = 0;
        gamePanel.SetActive(false);
        gameObjects.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void Resume_Click()
    {
        Time.timeScale = 1;
        gamePanel.SetActive(true);
        gameObjects.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void Restart_Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOverPanel()
    {
        gamePanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameObjects.SetActive(false);
        gameOverPanel.SetActive(true);

        int score = PlayerPrefs.GetInt("Score", 0);
        gameOverPanel.transform.Find("Score").GetComponent<Text>().text = $"Score: {score}";
    }
}