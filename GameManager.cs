using UnityEngine;
using System.Collections;

public enum EGameState
{
    GS_NotStarted,
    GS_Started,
    GS_Finished
}

public class GameManager: MonoBehaviour {

    public static GameManager instance = null;
    public AudioClip newHighScoreSound;
    public GameSpace gameSpace;
    public Transform firstPlatformPosition;

    private SpawnManager spawnManager;

    public Ball ball;

    private int highScore;
    private bool bNewHighScore = false;

    private EGameState eGameState = EGameState.GS_NotStarted;

        // Called when level loaded
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        spawnManager = GetComponent<SpawnManager>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Start()
    {
        spawnManager.StartGame(firstPlatformPosition);
    }

        // Updates every frame
    void Update ()
    {                
                // Plays sound when new HighScore
        if(!bNewHighScore && ball.GetScore() > highScore)
        {
            bNewHighScore = true;
            SoundManager.instance.PlaySound(newHighScoreSound);
        }

        UIManager.instance.ShowInGameHUD(ball.GetScore(), ball.GetGravityChangers(), highScore);

        if(gameSpace.GetDestroyedPlatforms() > 9)
        {
            spawnManager.SpawnPlatformsWave();

            gameSpace.SetDestroyedPlatforms(0);
        }
    }

    /***************************************************************************************************/

        // Called when game starts
    public void StartGame()
    {
        eGameState = EGameState.GS_Started;
    }

        // Called when player dies
    public void OnPlayerDeath()
    {
        eGameState = EGameState.GS_Finished;

        UIManager.instance.ShowOnDeathMenu(ball.GetScore(), highScore);
    }

        // Returns current game state
    public EGameState GetGameState()
    {
        return eGameState;
    }     
}
