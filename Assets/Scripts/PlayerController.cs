using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum BreadType
    {
        Basic,
        Toast,
        Garlic,
        French,
        Flat,
        Brioche
    }

    [SerializeField] private BreadType breadType = BreadType.Basic;

    // Movement variables
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.W;

    // Control variables
    [SerializeField] private float _maxSpeed = 10.0f;
    [SerializeField] private float _jumpForce = 8.0f;
    [SerializeField] private float _friction = 10.0f;

    // Physics vars
    private Rigidbody2D _rb = null;
    private bool _isGrounded = false;
    private bool _lastGroundedOnRealGround = true;

    // Jumping vars
    [SerializeField] private int _maxJumps = 1;
    private int _jumps;

    // Animator
   // private Animator _anim = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if(!_rb)
        {
            Debug.Log("Failed to get rigidbody!");
        }

        //_anim = GetComponent<Animator>();

        _maxJumps--;
        _jumps = _maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CheckGround();        
    }

    void MovePlayer()
    {
        // Get horizontal movement
        if(Input.GetKey(_left))
        {
            _rb.linearVelocityX = -1 * _maxSpeed;
        }

        else if(Input.GetKey(_right))
        {
            _rb.linearVelocityX = _maxSpeed;
        }

        // Lerp to no movement
        else
        {
            _rb.linearVelocityX = Mathf.Lerp(_rb.linearVelocityX, 0.0f, Time.deltaTime * _friction);
        }

        // Jump
        if(Input.GetKeyDown(_jump) && (_isGrounded || (_jumps > 0)))
        {
            _jumps--;
            _rb.linearVelocityY = _jumpForce;
        }
    }

    void CheckGround()
    {
        // Do the raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -1 * Vector2.up);

        // On hit
        if(hit)
        {
            // Get distance
            float groundDist = Mathf.Abs(hit.point.y - transform.position.y);

            // is Grounded = true if close enough, otherwise false
            if(groundDist < (transform.localScale.y / 2) + 0.1f)
            {
                _isGrounded = true;
                _jumps = _maxJumps;

                // Update real vs fake ground
                if(hit.collider.CompareTag("Ground"))
                {
                    _lastGroundedOnRealGround = true;
                }

                else
                {
                    _lastGroundedOnRealGround = false;
                }
                
                return;
            }

            _isGrounded = false;
            return;
        }

        // False on no hit
        _isGrounded = false;
        _lastGroundedOnRealGround = false;
    }

    public void HurtPlayer(int damage)
    {
        Debug.Log("YEOWCH");
    }

    public BreadType GetBreadType()
    {
        return breadType;
    }

    public int GetJumps()
    {
        return _jumps;
    }

    public void SetJumps(int jumps)
    {
        _jumps = jumps;
    }

    public bool GetGroundState()
    {
        return _isGrounded;
    }

    public bool GetLastGroundedOnRealGround()
    {
        return _lastGroundedOnRealGround;
    }
}
