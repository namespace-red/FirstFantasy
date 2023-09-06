using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    
    private Coroutine _activeCoroutine;

    private void OnEnable()
    {
        if (_health == null)
            Debug.LogError("Not set Health in HealthView");
        else
            _health.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value, float maxValue)
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        
        _activeCoroutine = StartCoroutine(ChangeHealthBarSmoothly(value, maxValue));
    }
    
    private IEnumerator ChangeHealthBarSmoothly(float value, float maxValue)
    {
        float target = value / maxValue;
        
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, Time.deltaTime);
            yield return null;
        }
    }
}
