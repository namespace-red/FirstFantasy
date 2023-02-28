using UnityEngine;

[RequireComponent(typeof(Wallet))]

public class Character : MonoBehaviour
{
    private Wallet _wallet;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Money>(out Money money))
        {
            _wallet.AddMoney(money.GetValue());
            money.PickUp();
        }
    }
}
