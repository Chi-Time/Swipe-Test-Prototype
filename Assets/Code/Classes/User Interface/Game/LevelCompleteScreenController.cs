using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScreenController : MonoBehaviour
{
    public void LoadNextLevel ()
    {
        //TODO: Need to fix otherwise player will eventually hit past the index of available scenes.
        var scene = SceneManager.GetActiveScene ();
        SceneManager.LoadScene (scene.buildIndex + 1, LoadSceneMode.Single);
    }

    public void LoadPreviousLevel ()
    {
        //TODO: Need to fix otherwise player will eventually hit past the index of available scenes.
        var scene = SceneManager.GetActiveScene ();
        SceneManager.LoadScene (scene.buildIndex - 1, LoadSceneMode.Single);
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene ("Main Menu");
    }
}
