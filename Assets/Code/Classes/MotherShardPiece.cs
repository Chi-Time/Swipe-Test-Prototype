using UnityEngine;

public class MotherShardPiece : MonoBehaviour
{
    [Tooltip ("Should the brick be activated when the mother shard is collected?")]
    [SerializeField] private bool _Activate = false;
    [Tooltip ("The mother shard this piece belongs to.")]
    [SerializeField] private MotherShards _ShardType = MotherShards.Alpha;

    private void Awake ()
    {
        EventManager.OnMotherShardCollected += MotherShardCollected;

        if (_Activate)
            gameObject.SetActive (false);
    }

    private void MotherShardCollected (MotherShards shard)
    {
        if (shard == _ShardType)
            Invoke ("DeactivateShardPiece", 0.2f);
    }

    private void DeactivateShardPiece ()
    {
        gameObject.SetActive (_Activate);
    }

    private void OnDestroy ()
    {
        EventManager.OnMotherShardCollected -= MotherShardCollected;
    }
}
