public delegate void MenuStateChanged (MenuStates state);
public delegate void GameStateChanged (GameStates state);
public delegate void EditorMenuStateChanged (EditorMenuStates state);
public delegate void MotherShardCollected (MotherShards shard);

/// <summary>Responsible for handling all in-game event firing and subscribers.</summary>
public static class EventManager
{
    /// <summary>Event fired when a menu state has been changed.</summary>
    public static event MenuStateChanged OnMenuStateChanged;
    /// <summary>Event fired when a game state has been changed.</summary>
    public static event GameStateChanged OnGameStateChanged;
    /// <summary>Event fired when a editor menu state has been changed.</summary>
    public static event EditorMenuStateChanged OnEditorMenuStateChanged;
    /// <summary>Event fired when a shard piece is collected.</summary>
    public static event MotherShardCollected OnMotherShardCollected;

    /// <summary>Changes the current menu state to that of the one provided.</summary>
    /// <param name="state">The state to change to.</param>
    public static void ChangeMenuState (MenuStates state)
    {
        if (OnMenuStateChanged != null)
            OnMenuStateChanged (state);
    }

    /// <summary>Changes the current game state to that of the one provided</summary>
    /// <param name="state">The state to change to.</param>
    public static void ChangeGameState (GameStates state)
    {
        if (OnGameStateChanged != null)
            OnGameStateChanged (state);
    }

    /// <summary>Changes the curren editor menu state to that of the one provided.</summary>
    /// <param name="state">The state to change to.</param>
    public static void ChangeEditorMenuState (EditorMenuStates state)
    {
        if (OnEditorMenuStateChanged != null)
            OnEditorMenuStateChanged (state);
    }

    /// <summary>Collects a shard piece and fires the event.</summary>
    /// <param name="shard">The shard type collected.</param>
    public static void CollectMotherShard (MotherShards shard)
    {
        if (OnMotherShardCollected != null)
            OnMotherShardCollected (shard);
    }
}
