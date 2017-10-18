using UnityEngine;

/// <summary>Controller for everything within the credits screen.</summary>
public class CreditScreenController : MonoBehaviour
{
    public void BackToMenu ()
    {
        EventManager.ChangeMenuState (MenuStates.Menu);
    }
}
