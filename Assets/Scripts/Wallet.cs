using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    public int GetValue() => _value;

    public void AddMoney(int value) => _value += value;
}
