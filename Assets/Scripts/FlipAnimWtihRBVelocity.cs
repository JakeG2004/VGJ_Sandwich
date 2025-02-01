using UnityEngine;

public class FlipAnimWtihRBVelocity : MonoBehaviour
{
    private Rigidbody2D _rb = null;
    private SpriteRenderer _sr = null;

    [SerializeField] private bool _reverse = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_reverse)
        {
            _sr.flipX = (_rb.linearVelocityX > 0);
            return;
        }

        _sr.flipX = (_rb.linearVelocityX < 0);
    }
}
