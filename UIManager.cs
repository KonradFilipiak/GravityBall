using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance = null;

    public Text scoreText;
    public Text highScoreText;
    public Text gravityChangersText;
    public Text volumeText;

    public Button startGameButton;
    public Button exitGameButton;
    public Button returnToMenuButton;
    public Slider volumeSlider;

    public AudioClip buttonClickSound;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
            // Sets sound volume
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue", 100);

        SoundManager.instance.SetSoundVolume(volumeValue);
        volumeText.text = "Volume: " + (int)(volumeValue * 100);
        volumeSlider.value = volumeValue;
    }

    /***************************************************************************************************/

        // Shows during a game
    public void ShowInGameHUD(int score, int gravityChangers, int highScore)
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
        gravityChangersText.text = "Gravity Changers: " + gravityChangers;
    }

        // Called when player dies
    public void ShowOnDeathMenu(int score, int highScore)
    {
        returnToMenuButton.gameObject.SetActive(true);

        // Updates the highscore
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);

            returnToMenuButton.GetComponentInChildren<Text>().text = "New Highscore\n" + score + "!";
        }
        else
        {
            returnToMenuButton.GetComponentInChildren<Text>().text = "Your score\n" + score + "!";
        }
    }

        // Starts the game
    public void OnStartGameButtonClick()
    {
        GameManager.instance.StartGame();

        HideAllButtons();

        PlayerPrefs.SetFloat("VolumeValue", volumeSlider.value);

        SoundManager.instance.PlaySound(buttonClickSound);
    }

        // Closes the app
    public void OnExitGameButtonClick()
    {
        SoundManager.instance.PlaySound(buttonClickSound);

        Application.Quit();
    }

        //Restarts level
    public void OnReturnToMenuButtonClick()
    {
        SceneManager.LoadScene("Main");
    }

        // Mutes all sound. OnVolumeSliderChange is called after this
    public void OnMuteButtonClick()
    {
        volumeSlider.value = 0;
    }

        // Called when volume slider changes
    public void OnVolumeSliderChange()
    {
        float volumeValue = volumeSlider.value;

        SoundManager.instance.SetSoundVolume(volumeValue);
        volumeText.text = "Volume: " + (int)(volumeValue * 100);

        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
    }

    /***************************************************************************************************/


        // Hides all buttons
    private void HideAllButtons()
    {
                // Main Menu
        startGameButton.gameObject.SetActive(false);
        exitGameButton.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);

                // After death menu
        returnToMenuButton.gameObject.SetActive(false);
    }
}
