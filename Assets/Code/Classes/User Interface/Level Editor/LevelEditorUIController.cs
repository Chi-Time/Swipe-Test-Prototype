using UnityEngine;

/// <summary>Controller for all UI states in the level editor.</summary>
public class LevelEditorUIController : MonoBehaviour
{
    private GameObject _EditorScreen = null;

    private void Awake ()
    {
        AssignReferences ();

        EventManager.OnEditorMenuStateChanged += StateChanged;
    }

    private void AssignReferences ()
    {
    }

    private void Start ()
    {
        EventManager.ChangeEditorMenuState (EditorMenuStates.Editing);
    }

    private void StateChanged (EditorMenuStates state)
    {
        switch (state)
        {
            case EditorMenuStates.Editing:
                SwitchScreen (_EditorScreen.gameObject);
                break;
        }
    }

    private void SwitchScreen (GameObject screen)
    {
        _EditorScreen.gameObject.SetActive (false);

        screen.SetActive (true);
    }

    private void OnDestroy ()
    {
        EventManager.OnEditorMenuStateChanged -= StateChanged;
    }
}
