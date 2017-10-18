using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameStates CurrentGameState = GameStates.Game;

    private void Awake ()
    {
        EventManager.OnGameStateChanged += StateChanged;
    }
    
    private void StateChanged (GameStates state)
    {
        CurrentGameState = state;

        switch (state)
        {
            case GameStates.Game:
                Time.timeScale = 1.0f;
                break;
            case GameStates.Paused:
                Time.timeScale = 0.0f;
                break;
            case GameStates.Settings:
                Time.timeScale = 0.0f;
                break;
            case GameStates.LevelComplete:
                Time.timeScale = 0.0f;
                print ("Level is complete");
                break;
        }
    }

    private void OnDestroy ()
    {
        EventManager.OnGameStateChanged -= StateChanged;
    }
}
