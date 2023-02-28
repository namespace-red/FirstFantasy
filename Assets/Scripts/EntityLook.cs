using UnityEngine;

public class EntityLook : MonoBehaviour
{
    private bool _characterLooksToRight = true;
    
    public void SetDirection(float horizontalDirection)
    {
        if (IsRunningToRight(horizontalDirection) && (_characterLooksToRight == false))
            FlipLook();
        else if (IsRunningToLeft(horizontalDirection) && _characterLooksToRight)
            FlipLook();
    }

    private bool IsRunningToRight(float horizontalDirection) => horizontalDirection > 0;
    private bool IsRunningToLeft(float horizontalDirection) => horizontalDirection < 0;

    private void FlipLook()
    {
        _characterLooksToRight = !_characterLooksToRight;
        
        Vector3 newScale = transform.localScale;
        newScale.x *= -1f;
        transform.localScale = newScale;
    }
}
