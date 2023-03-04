using UnityEngine;

public class Money : MonoBehaviour, IPickable
{
    [SerializeField] private int _value = 1;

    public int Value { get => _value; }

    public void PickUp()
    {
        Destroy(gameObject);
    }
}
