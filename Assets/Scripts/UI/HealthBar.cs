using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void OnValueChanged(float value, float maxValue)
    {
        _slider.value = value / maxValue;
    }
}
