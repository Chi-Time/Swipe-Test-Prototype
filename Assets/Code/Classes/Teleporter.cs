using UnityEngine;

[RequireComponent (typeof (Rigidbody), typeof (Collider))]
public class Teleporter : MonoBehaviour
{
    [Tooltip ("The ID of this teleporter and it's partner. (Two teleporters must have the same ID for it to work.)")]
    public int ID = 0;

    [HideInInspector]
    public bool CanTeleport = true;

    private Teleporter _Partner = null;

    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        var rb = GetComponent<Rigidbody> ();
        InitialiseRigidbody (rb);
        GetComponent<Collider> ().isTrigger = true;

        GetPartner ();
    }

    private void InitialiseRigidbody (Rigidbody rb)
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void GetPartner ()
    {
        var teleporters = FindObjectsOfType<Teleporter> ();

        for (int i = 0; i < teleporters.Length; i++)
            if (teleporters[i].ID == ID && teleporters[i] != this)
                _Partner = teleporters[i];
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Player") && CanTeleport)
            Teleport (other.transform);
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag ("Player"))
            CanTeleport = true;
    }

    private void Teleport (Transform player)
    {
        player.position = _Partner.transform.position;

        CanTeleport = false;
        _Partner.CanTeleport = false;
    }
}
