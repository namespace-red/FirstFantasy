using UnityEngine;
using UnityEngine.Events;

public class ContactTracking : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered = new UnityEvent();
    [SerializeField] private UnityEvent _cameОut = new UnityEvent();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _entered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _cameОut?.Invoke();
    }
}
