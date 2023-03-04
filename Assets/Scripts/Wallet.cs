using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Value 
    { 
        get => _value;
        private set => _value = value; 
    }

    public void AddMoney(int value) => Value += value;
}
