using UnityEngine;

[RequireComponent (typeof (Collider))]
public class EndTrigger : MonoBehaviour
{
    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        GetComponent<Collider> ().isTrigger = true;

        this.tag = "Finish";
    }
}
