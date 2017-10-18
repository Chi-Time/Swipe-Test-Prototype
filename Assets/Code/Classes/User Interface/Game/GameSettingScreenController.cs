using UnityEngine;

public class GameSettingScreenController : MonoBehaviour
{
    public void ChangeMusicLevel (float level)
    {
        //TODO: Implement audio controller to change music levels.
    }

    public void ChangeSFXLevel (float level)
    {
        //TODO: Implement audio controller to change sfx levels.
    }

    public void BackToPause ()
    {
        EventManager.ChangeGameState (GameStates.Paused);
    }
}
