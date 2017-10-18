using UnityEngine;

/// <summary>Controller for all UI states in the game loop.</summary>
public class GameUIController : MonoBehaviour
{
    private GameScreenController _GameScreen = null;
    private PauseScreenController _PauseScreen = null;
    private GameSettingScreenController _GameSettingsScreen = null;
    private LevelCompleteScreenController _LevelCompleteScreen = null;

    private void Awake ()
    {
        AssignReferences ();

        EventManager.OnGameStateChanged += StateChanged;
    }
    
    private void AssignReferences ()
    {
        _GameScreen = FindObjectOfType<GameScreenController> ();
        _PauseScreen = FindObjectOfType<PauseScreenController> ();
        _GameSettingsScreen = FindObjectOfType<GameSettingScreenController> ();
        _LevelCompleteScreen = FindObjectOfType<LevelCompleteScreenController> ();
    }
    
    private void Start ()
    {
        EventManager.ChangeGameState (GameStates.Game);
    }

    private void StateChanged (GameStates state)
    {
        switch (state)
        {
            case GameStates.Game:
                SwitchScreen (_GameScreen.gameObject);
                break;
            case GameStates.Paused:
                SwitchScreen (_PauseScreen.gameObject);
                break;
            case GameStates.Settings:
                SwitchScreen (_GameSettingsScreen.gameObject);
                break;
            case GameStates.LevelComplete:
                SwitchScreen (_LevelCompleteScreen.gameObject);
                break;
        }
    }

    private void SwitchScreen (GameObject screen)
    {
        _GameScreen.gameObject.SetActive (false);
        _PauseScreen.gameObject.SetActive (false);
        _GameSettingsScreen.gameObject.SetActive (false);
        _LevelCompleteScreen.gameObject.SetActive (false);

        screen.SetActive (true);
    }

    private void OnDestroy ()
    {
        EventManager.OnGameStateChanged -= StateChanged;
    }
}
