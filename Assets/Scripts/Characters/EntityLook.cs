using UnityEngine;

public class EntityLook : MonoBehaviour
{
    private bool _characterLooksToRight = true;
    private float _horizontalDirection;

    private bool IsRunningToRight { get => _horizontalDirection > 0; }

    public void SetDirection(float horizontalDirection)
    {
        _horizontalDirection = horizontalDirection;
        
        if (IsRunningToRight && (_characterLooksToRight == false))
            FlipLook();
        else if (IsRunningToRight == false && _characterLooksToRight)
            FlipLook();
    }

    private void FlipLook()
    {
        _characterLooksToRight = !_characterLooksToRight;
        
        Vector3 newScale = transform.localScale;
        newScale.x *= -1f;
        transform.localScale = newScale;
    }
}
