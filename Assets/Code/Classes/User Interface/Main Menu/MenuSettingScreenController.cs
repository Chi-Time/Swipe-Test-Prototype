using UnityEngine;

/// <summary>Controller for everything within the settings screen.</summary>
public class MenuSettingScreenController : MonoBehaviour
{
    public void ChangeMusicLevel (float level)
    {
        //TODO: Implement audio controller for music integration.
    }

    public void ChangeSFXLevel (float level)
    {
        //TODO: Implement audio controller for sfx integration.
    }

    public void BackToMenu ()
    {
        EventManager.ChangeMenuState (MenuStates.Menu);
    }
}
