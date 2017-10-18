using UnityEngine;
using System.Collections;

public class FlickerObstacle : MonoBehaviour
{
    [Tooltip ("The delay between when the object is active or inactive.")]
    [SerializeField] private float _FlickerRate = .5f;
    [Tooltip ("The gameobject used for the active state of this obstacle.")]
    [SerializeField] private GameObject _ActiveState = null;
    [Tooltip ("The gameobject used of the inactive state of this obstacle.")]
    [SerializeField] private GameObject _InactiveState = null;

    private bool _Activate = true;

    private void Awake ()
    {
        AssignReferences ();
    }

    // If no active or inactive state are provided, will attempt to find them in children.
    private void AssignReferences ()
    {
        if (_ActiveState == null)
            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild (i).name == "Active")
                    _ActiveState = transform.GetChild (i).gameObject;

        if (_InactiveState == null)
            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild (i).name == "Inactive")
                    _InactiveState = transform.GetChild (i).gameObject;
    }

    private void Start ()
    {
        StartCoroutine ("Flicker");
    }

    private IEnumerator Flicker ()
    {
        ChangeState ();

        yield return new WaitForSeconds (_FlickerRate);

        StopCoroutine ("Flicker");
        StartCoroutine ("Flicker");
    }

    private void ChangeState ()
    {
        _Activate = !_Activate;

        _ActiveState.SetActive (_Activate);
        _InactiveState.SetActive (!_Activate);
    }
}
