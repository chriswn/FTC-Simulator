using UnityEngine;
using UnityEngine.SceneManagement;

// Game Manager - Handles Game States
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState { BuildMode, SimulationMode }
    public GameState currentState;
    
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    public void ChangeState(GameState newState)
    {
        currentState = newState;
        SceneManager.LoadScene(newState == GameState.BuildMode ? "BuildScene" : "SimulationScene");
    }
}
