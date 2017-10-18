using UnityEngine;

[RequireComponent (typeof (Rigidbody), typeof (Collider))]
public class MotherShard : MonoBehaviour
{
    [Tooltip ("The shard type that this mother is.")]
    [SerializeField] private MotherShards _MotherShardType = MotherShards.Alpha;

    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        var rb = GetComponent<Rigidbody> ();
        InitialiseRigidbody (rb);

        GetComponent<Collider> ().isTrigger = true; 
    }

    private void InitialiseRigidbody (Rigidbody rb)
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Player"))
            Collect ();
    }

    private void Collect ()
    {
        EventManager.CollectMotherShard (_MotherShardType);
        gameObject.SetActive (false);
    }
}
