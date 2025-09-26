using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Example data
    public string playerName;
    public int playerScore;
    public bool isLoggedIn;
    public GameState currentGameState;

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    void Start()
    {
        Debug.Log("Player Name: " + GameManager.Instance.playerName);
    }

    // Add methods to update and retrieve data
    public void SetPlayerName(string name) => playerName = name;
    public void UpdateScore(int score) => playerScore = score;
    public void ChangeState(GameState newState) => currentGameState = newState;


    //for future:
    /*
    public void SaveGame()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Default");
        playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
    }
    */


}