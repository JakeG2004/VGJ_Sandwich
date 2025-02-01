using UnityEngine;

public class MovementAnimator : MonoBehaviour
{
    private Rigidbody2D _rb = null;
    private Animator _anim = null;
    private PlayerController _pc = null;

    [SerializeField] private string _HorFloatName = "Speed";
    [SerializeField] private string _JumpingBoolName = "IsJumping";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetFloat(_HorFloatName, Mathf.Abs(_rb.linearVelocityX));
        _anim.SetBool(_JumpingBoolName, !_pc.GetGroundState());
    }
}
