using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] public UnityEvent _colEvent;
    [SerializeField] private bool _oneOff = false;
    [SerializeField] private string _colTag = "Player";

    private bool _hasTriggered = false;

    // Called when the object collides with another collider
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == _colTag)
        {
            DoEvent();
        }
    }

    // Called when the object enters a trigger collider
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == _colTag)
        {
            DoEvent();
        }
    }

    void DoEvent()
    {
        if(_oneOff && !_hasTriggered)
        {
            _colEvent.Invoke();
            _hasTriggered = true;
            return;
        }

        if(!_oneOff)
        {
            _colEvent.Invoke();
        }
    }
}
