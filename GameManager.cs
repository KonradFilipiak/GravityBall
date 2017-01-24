using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

        //takes care of the UI
public class GameManager: MonoBehaviour {

    public GameObject m_ball;

    public AudioClip m_buttonClickSound;
    public AudioClip m_newHighScoreSound;

    public Text m_scoreText;
    public Text m_highScoreText;
    public Text m_gravityChangersText;
    public Text m_volumeText;

    public Button m_startGameButton;
    public Button m_exitGameButton;
    public Button m_returnToMenuButton;
    public Slider m_volumeSlider;

    private BallMovement m_ballScript;
    private int m_highScore;
    private int m_score;
    private int m_gravityChangers;

    private bool m_bNewHighScore = false;

            //initializes variables and sets texts
	void Awake()
    {
        m_ballScript = m_ball.GetComponent<BallMovement>();

        m_highScore = PlayerPrefs.GetInt("HighScore", 0);
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue", 1f);

        m_volumeSlider.value = volumeValue;
        m_volumeText.text = "Volume: " + (int)(m_volumeSlider.value * 100);
        m_scoreText.text = "Score: 0";
        m_highScoreText.text = "High Score: " + m_highScore;
        m_gravityChangersText.text = "Gravity Changers: " + m_ballScript.m_gravityChangers;
    }
            //updates the UI
    void Update ()
    {

        if (!m_ballScript.m_bGameStarted)
        {
            m_volumeText.text = "Volume: " + (int)(m_volumeSlider.value * 100);
            SoundManager.instance.SetSoundVolume(m_volumeSlider.value);
        }

        m_score = m_ballScript.GetScore();
        m_gravityChangers = m_ballScript.m_gravityChangers;
                
                //plays sound when new HighScore
        if(!m_bNewHighScore && m_score > m_highScore)
        {
            m_bNewHighScore = true;
            SoundManager.instance.PlaySound(m_newHighScoreSound);
        }

        m_scoreText.text = "Score: " + m_score;
        m_gravityChangersText.text = "Gravity Changers: " + m_gravityChangers;
    }
            //turns on ReturnToMenuButton and shows final score
    public void OnPlayerDeath()
    {
        m_returnToMenuButton.gameObject.SetActive(true);
        if (m_bNewHighScore)         //updates the highscore
        {
            PlayerPrefs.SetInt("HighScore", m_score);

            m_returnToMenuButton.GetComponentInChildren<Text>().text = "New Highscore\n" + m_score + "!";
        }
        else
        {
            m_returnToMenuButton.GetComponentInChildren<Text>().text = "Your score\n" + m_score + "!";
        }
    }
            //hides the UI and sets the ball to move
    private void OnStartGameButtonClick()
    {
        m_startGameButton.gameObject.SetActive(false);
        m_exitGameButton.gameObject.SetActive(false);
        m_volumeSlider.gameObject.SetActive(false);
        m_volumeText.gameObject.SetActive(false);

        PlayerPrefs.SetFloat("VolumeValue", m_volumeSlider.value);

        m_ballScript.m_bGameStarted = true;

        SoundManager.instance.PlaySound(m_buttonClickSound);
    }
            //close the app
    private void OnExitGameButtonClick()
    {
        SoundManager.instance.PlaySound(m_buttonClickSound);

        Application.Quit();
    }
        //Restarts level
    private void OnReturnToMenuButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
