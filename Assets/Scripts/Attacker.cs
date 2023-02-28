using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    public UnityEvent Attacked = new UnityEvent();
    
    public void Hit()
    {
        Attacked?.Invoke();
    }
}
