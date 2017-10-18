using UnityEngine;

[RequireComponent (typeof (Rigidbody), typeof (Collider))]
public class Shard : MonoBehaviour
{
    [SerializeField] private string _TaggedObjectsToDeactivate = "";
    [SerializeField] private string _TaggedObjectsToActivate = "";

    private GameObject[] _ObjectsToDeactivate = null;
    private GameObject[] _ObjectsToActivate = null;

    private void Awake ()
    {
        AssignReferences ();
    }
    
    private void AssignReferences ()
    {
        var rb = GetComponent<Rigidbody> ();
        GetComponent<Collider> ().isTrigger = true;

        if (!string.IsNullOrEmpty (_TaggedObjectsToDeactivate))
            _ObjectsToDeactivate = GameObject.FindGameObjectsWithTag (_TaggedObjectsToDeactivate);

        if (!string.IsNullOrEmpty (_TaggedObjectsToActivate))
        {
            _ObjectsToActivate = GameObject.FindGameObjectsWithTag (_TaggedObjectsToActivate);
            DeactivateExtraObjects ();
        }

        InitialiseRigidbody (rb);
    }

    private void DeactivateExtraObjects ()
    {
        for (int i = 0; i < _ObjectsToActivate.Length; i++)
            _ObjectsToActivate[i].SetActive (false);
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
            Collected ();
    }

    private void Collected ()
    {
        Invoke ("KillChildren", 0.3f);
        ActivateExtras ();
        gameObject.SetActive (false);
    }

    private void KillChildren ()
    {
        if (_ObjectsToDeactivate != null)
            for (int i = 0; i < _ObjectsToDeactivate.Length; i++)
                _ObjectsToDeactivate[i].SetActive (false);
    }

    private void ActivateExtras ()
    {
        if (_ObjectsToActivate != null)
            for (int i = 0; i < _ObjectsToActivate.Length; i++)
                _ObjectsToActivate[i].SetActive (true);
    }
}
