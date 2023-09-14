using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    public UnityAction Attacked;
    
    public void Hit()
    {
        Attacked?.Invoke();
    }
}
