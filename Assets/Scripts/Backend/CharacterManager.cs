using UnityEngine;
using Unity.Cinemachine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private KeyCode _nextChar = KeyCode.E;
    [SerializeField] private KeyCode _lastChar = KeyCode.Q;

    /*
    * Total playable characters:
    * Basic bread
    * Toast (fire resist)
    * Garlic Bread (double jump, sheds garlic)
    * French bread (grapple hook)
    */

    [SerializeField] private GameObject[] chars;

    [SerializeField] private int _maxChar = 1;
    private int _curChar = 0;

    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _CMCam = null;
    private CinemachineCamera _CMCamComp = null;

    private bool _hasDblJump = false;
    private bool _hasGrounded = false;

    private Vector2 _respawnPos;

    void Start()
    {
        GetPlayerAndCamera();
        UpdateCamera();
    }

    void Update()
    {
        GetPlayerInput();

        // If the player has grounded, set that to be so
        PlayerController _PC = _player.GetComponent<PlayerController>();
        if(_PC.GetGroundState())
        {
            _hasGrounded = true;
        }
    }

    void GetPlayerInput()
    {
        if(Input.GetKeyDown(_nextChar))
        {
            ChangeChar(1);
        }

        if(Input.GetKeyDown(_lastChar))
        {
            ChangeChar(-1);
        }
    }

    void ChangeChar(int n)
    {
        // Change the character and wrap
        _curChar = (_curChar + n + _maxChar + 1) % (_maxChar + 1);

        // Get the rb
        Rigidbody2D _playerRB = _player.GetComponent<Rigidbody2D>();

        // Store pos and current velocity from player
        Vector2 playerVel = _playerRB.linearVelocity;
        Vector3 playerPos = _player.transform.position;

        // Create new player
        GameObject _newPlayer = Instantiate(chars[_curChar], playerPos, Quaternion.identity);

        // Get new rb
        _playerRB = _newPlayer.GetComponent<Rigidbody2D>();

        // Apply the transform and values
        _newPlayer.transform.position = playerPos;
        _playerRB.linearVelocity = playerVel;

        // Get player controllers
        PlayerController _PC = _player.GetComponent<PlayerController>();
        PlayerController _newPC = _newPlayer.GetComponent<PlayerController>();

        // Save Garlic double jump state
        if(_PC.GetBreadType() == PlayerController.BreadType.Garlic)
        {
            int _jumps = _PC.GetJumps();
            _hasDblJump = (_jumps == 1);
        }

        // Load garlic double jump state
        if(_newPC.GetBreadType() == PlayerController.BreadType.Garlic)
        {
            if(_hasDblJump || _hasGrounded)
            {
                _newPC.SetJumps(1);
            }

            else
            {
                _newPC.SetJumps(0);
            }
        }

        // Get and set respawnpos
        _respawnPos = _PC.GetRespawnPos();
        _newPC.SetRespawnPos(_respawnPos);

        // Destroy and reassign player
        Destroy(_player);
        _player = _newPlayer;

        // Then update the camera
        UpdateCamera();
    }

    public void SetTotalCharCount(int n)
    {
        _maxChar = n;
    }

    void GetPlayerAndCamera()
    {
        _player = GameObject.FindWithTag("Player");
        if(!_player)
        {
            _player = Instantiate(chars[0], new Vector3(0, 0, 0), Quaternion.identity);
        }
        _CMCam = GameObject.FindWithTag("CMCamera");

        _CMCamComp = _CMCam.GetComponent<CinemachineCamera>();
    }

    void UpdateCamera()
    {        
        _CMCamComp.LookAt = _player.transform;
        _CMCamComp.Follow = _player.transform;
    }
}