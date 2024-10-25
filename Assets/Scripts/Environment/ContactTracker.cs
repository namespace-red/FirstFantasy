using System;
using UnityEngine;

public class ContactTracker : MonoBehaviour
{
    public event Action Entered;
    public event Action CameОut;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Thief>() != null)
            Entered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Thief>() != null)
            CameОut?.Invoke();
    }
}
