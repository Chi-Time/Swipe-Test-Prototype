using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenController : MonoBehaviour
{
    public void OpenSettings ()
    {
        EventManager.ChangeGameState (GameStates.Settings);
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
    }
}
