using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]

public class Movement2D : MonoBehaviour
{
    [SerializeField] private float _moveForse = 20f;
    [SerializeField] private float _jumpForse = 500f;
    [SerializeField] private bool _canControlledInAir = false;
    
    private Rigidbody2D _rigidbody2D;
    private GroundChecker _groundChecker;

    public UnityAction Jumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    public void MoveHorizontally(float horizontalDirection)
    {
        if ((_groundChecker.IsGrounding == false) && (_canControlledInAir == false))
            return;

        _rigidbody2D.velocity = new Vector2(horizontalDirection * _moveForse, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounding)
        {
            _rigidbody2D.AddForce(_jumpForse * Vector2.up);
            Jumping?.Invoke();
        }
    }
}
