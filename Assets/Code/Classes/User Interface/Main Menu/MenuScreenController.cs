using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Controller for everthing within the menu screen</summary>
public class MenuScreenController : MonoBehaviour
{
    [Tooltip ("The name of the level editor scene in the build menu.")]
    [SerializeField] private string _LevelEditorSceneName = "Level Editor";

    public void LevelSelect ()
    {
        EventManager.ChangeMenuState (MenuStates.LevelSelect);
    }

    public void LevelEditor ()
    {
        SceneManager.LoadScene (_LevelEditorSceneName, LoadSceneMode.Single);
    }

    public void Settings ()
    {
        EventManager.ChangeMenuState (MenuStates.Settings);
    }

    public void Credits ()
    {
        EventManager.ChangeMenuState (MenuStates.Credits);
    }

    public void ExitGame ()
    {
        Application.Quit ();
    }
}
