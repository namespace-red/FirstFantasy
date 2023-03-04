using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    [SerializeField] private UnityEvent _attacked = new UnityEvent();
    
    public void Hit()
    {
        _attacked?.Invoke();
    }
}
