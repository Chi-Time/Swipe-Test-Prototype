using UnityEngine;

/// <summary>Controller for all UI states in the game's menu</summary>
public class MainMenuUIController : MonoBehaviour
{
    [Tooltip ("The screen used for the main menu.")]
    [SerializeField] private MenuScreenController _MenuScreen = null;
    [Tooltip ("The screen used for level selection.")]
    [SerializeField] private LevelSelectScreenController _LevelSelectScreen = null;
    [Tooltip ("The screen used for editing game settings.")]
    [SerializeField] private MenuSettingScreenController _SettingsScreen = null;
    [Tooltip ("The screen used for displaying the game credits.")]
    [SerializeField] private CreditScreenController _CreditsScreen = null;

    private void Awake ()
    {
        AssignReferences ();

        EventManager.OnMenuStateChanged += StateChanged;
    }

    private void AssignReferences ()
    {
        _MenuScreen = FindObjectOfType<MenuScreenController> ();
        _LevelSelectScreen = FindObjectOfType<LevelSelectScreenController> ();
        _SettingsScreen = FindObjectOfType<MenuSettingScreenController> ();
        _CreditsScreen = FindObjectOfType<CreditScreenController> ();
    }

    private void Start ()
    {
        EventManager.ChangeMenuState (MenuStates.Menu);
    } 

    private void StateChanged (MenuStates state)
    {
        switch (state)
        {
            case MenuStates.Menu:
                SwitchScreen (_MenuScreen.gameObject);
                break;
            case MenuStates.LevelSelect:
                SwitchScreen (_LevelSelectScreen.gameObject);
                break;
            case MenuStates.Settings:
                SwitchScreen (_SettingsScreen.gameObject);
                break;
            case MenuStates.Credits:
                SwitchScreen (_CreditsScreen.gameObject);
                break;
        }
    }
    
    private void SwitchScreen (GameObject screen)
    {
        _MenuScreen.gameObject.SetActive (false);
        _LevelSelectScreen.gameObject.SetActive (false);
        _SettingsScreen.gameObject.SetActive (false);
        _CreditsScreen.gameObject.SetActive (false);

        screen.SetActive (true);
    }

    private void OnDestroy ()
    {
        EventManager.OnMenuStateChanged -= StateChanged;
    }
}
