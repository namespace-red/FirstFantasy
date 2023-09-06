using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue = 100f;
    
    public UnityAction<float, float> ValueChanged;
    public UnityAction Died;

    private float Value
    {
        get => _value;
        set
        {
            _value = value;
            
            if (Value < 0)
                _value = 0;
            
            if (Value > _maxValue) 
                MakeValueMax();
                
            ValueChanged?.Invoke(Value, _maxValue);
            
            if (Value == 0)
                Died?.Invoke();
        }
    }

    private void Start()
    {
        MakeValueMax();
    }
    
    private void MakeValueMax()
    {
        Value = _maxValue;
    }

    public void ApplyDamage(float damage)
    {
        Value -= damage;
    }

    public void Healing(float value)
    {
        Value += value;
    }
}
