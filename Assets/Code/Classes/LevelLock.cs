using UnityEngine;

[RequireComponent (typeof (Collider), typeof (Rigidbody))]
public class LevelLock : MonoBehaviour
{
    private GameObject _LevelEnd = null;

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

    private void Start ()
    {
        _LevelEnd = GameObject.FindGameObjectWithTag ("Finish");
        _LevelEnd.SetActive (false);
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
        _LevelEnd.SetActive (true);
        gameObject.SetActive (false);
    }
}
