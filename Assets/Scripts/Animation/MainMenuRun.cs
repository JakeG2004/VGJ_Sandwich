using UnityEngine;

public class MainMenuRun : MonoBehaviour
{
    public float vel = 10.0f;
    public float rightBound = 12.0f;

    private Vector2 _resetPos;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _resetPos = new Vector2(transform.position.x, transform.position.y);
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocityX = vel;
        
        if(transform.position.x >= rightBound)
        {
            transform.position = new Vector3(_resetPos.x, _resetPos.y, 0);
        }
    }
}
