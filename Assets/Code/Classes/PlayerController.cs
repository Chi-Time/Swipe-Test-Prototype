using UnityEngine;

//TODO: Document class better, cleanup update function, abstract movement code from controller.
//TODO: Implement grab mechanic for pickups. Possibly make use of mouse pointer/A,B,X,Y buttons on joystick.

[RequireComponent (typeof (Rigidbody), typeof (Collider))]
public class PlayerController : MonoBehaviour
{
    [Tooltip ("The speed of the player object.")]
    [SerializeField] private float _Speed = 0f;
    [Tooltip ("The layer which the player considers to be solid walls.")]
    [SerializeField] private LayerMask _WallLayer;

    private bool _CanMove = true;
    /// <summary>The offset of the raycast line.</summary>
    private float _LineOffset = 0.6f;
    private Vector3 _Velocity = Vector3.zero;
    private Transform _Tranform = null;
    private Rigidbody _Rigidbody = null;

    private void Awake ()
    {
        AssignReferences ();
    }
    
    private void AssignReferences ()
    {
        _Tranform = GetComponent<Transform> ();
        _Rigidbody = GetComponent<Rigidbody> ();

        this.tag = "Player";
    }

    private void Start ()
    {
        SetDefaults ();
    }
    
    private void SetDefaults ()
    {
        _Rigidbody.useGravity = false;
        _Rigidbody.isKinematic = true;
        _Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update ()
    {
        if (_CanMove)
            GetInput ();

        if (HitWall ())
        {
            _CanMove = true;
            _Velocity = Vector3.zero;
            _Tranform.position = new Vector3 (Mathf.Round (_Tranform.position.x), Mathf.Round (_Tranform.position.y), 0.0f);
        }

        Move ();
    }
    
    private void GetInput ()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (GameController.CurrentGameState == GameStates.Game)
                EventManager.ChangeGameState (GameStates.Paused);
            else if (GameController.CurrentGameState == GameStates.Paused || GameController.CurrentGameState == GameStates.Settings)
                EventManager.ChangeGameState (GameStates.Game);
        }

        // Right
        if (Input.GetAxis ("Horizontal") > 0.01f)
        {
            _Velocity = Vector3.right;
            _CanMove = false;
        }
        // Left
        else if (Input.GetAxis ("Horizontal") < -0.01f)
        {
            _Velocity = Vector3.left;
            _CanMove = false;
        }
        // Up
        else if (Input.GetAxis ("Vertical") > 0.01f)
        {
            _Velocity = Vector3.up;
            _CanMove = false;
        }
        // Down
        else if (Input.GetAxis ("Vertical") < -0.01f)
        {
            _Velocity = Vector3.down;
            _CanMove = false;
        }
    }
    
    private void Move ()
    {
        if (!HitWall ())
            _Rigidbody.MovePosition (_Rigidbody.position + _Velocity * _Speed * Time.fixedDeltaTime);
    }

    private bool HitWall ()
    {
        var endPos = GetEndPosition ();

        if (Physics.Linecast (_Tranform.position, endPos, _WallLayer))
            return true;

        Debug.DrawLine (_Tranform.position, endPos, Color.red);

        return false;
    }

    Vector3 GetEndPosition ()
    {
        if (_Velocity == Vector3.right)
            return new Vector3 (_Tranform.position.x + _LineOffset, _Tranform.position.y, _Tranform.position.z);
        else if (_Velocity == Vector3.left)
            return new Vector3 (_Tranform.position.x + -_LineOffset, _Tranform.position.y, _Tranform.position.z);
        else if (_Velocity == Vector3.up)
            return new Vector3 (_Tranform.position.x, _Tranform.position.y + _LineOffset, _Tranform.position.z);
        else if (_Velocity == Vector3.down)
            return new Vector3 (_Tranform.position.x, _Tranform.position.y + -_LineOffset, _Tranform.position.z);

        return Vector3.zero;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Finish"))
            EventManager.ChangeGameState (GameStates.LevelComplete);

        StopInPosition (other);
    }

    private void StopInPosition (Collider other)
    {
        _CanMove = true;
        _Velocity = Vector3.zero;
        _Tranform.position = other.transform.position;
    }
}
