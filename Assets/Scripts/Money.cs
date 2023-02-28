using UnityEngine;

public class Money : MonoBehaviour, IPickable
{
    [SerializeField] private int _value = 1;

    public int GetValue() => _value;

    public void PickUp()
    {
        Destroy(gameObject);
    }
}
