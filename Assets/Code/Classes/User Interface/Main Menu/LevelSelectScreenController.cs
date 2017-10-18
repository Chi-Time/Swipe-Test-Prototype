using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Controller for everthing in the Level Select screen</summary>
public class LevelSelectScreenController : MonoBehaviour
{
    public void OpenLevel (int levelNumber)
    {
        SceneManager.LoadScene (levelNumber);
    }

    public void BackToMenu ()
    {
        EventManager.ChangeMenuState (MenuStates.Menu);
    }
}
