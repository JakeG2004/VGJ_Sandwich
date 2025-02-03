using UnityEngine;
using UnityEngine.Events;

public class WaitOnStart : MonoBehaviour
{
    [SerializeField] private float _waitTime = 1.0f;
    private float _curTime = 0.0f;
    private bool _hasGone = false;

    [SerializeField] private UnityEvent _startEvent;

    void Start()
    {
        if(_waitTime == 0.0f)
        {
            _startEvent.Invoke();
            _hasGone = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        _waitTime += Time.deltaTime;

        if(_waitTime >= _curTime && !_hasGone)
        {
            _startEvent.Invoke();
            _hasGone = true;
        }
    }
}
