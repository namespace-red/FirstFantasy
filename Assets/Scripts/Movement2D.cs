using UnityEngine;
using UnityEngine.Events;

public class Movement2D : MonoBehaviour
{
    [SerializeField] private float _moveForse = 20f;
    [SerializeField] private float _jumpForse = 500f;
    [SerializeField] private bool _canControlledInAir = false;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform[] _groundPoints;
    
    private const float GroundDistance = .2f;
    private Rigidbody2D _rigidbody2D;

    [Header("Events")] [Space] public UnityEvent Grounded = new UnityEvent();
    
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent Jumped = new BoolEvent();

    public bool IsGrounded { get; private set; }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if ((_groundLayer.value) == gameObject.layer)
            Debug.LogError($"{gameObject.name} Player Layer must be different from Ground Layer!");
        
        if (_groundPoints == null)
            Debug.LogError($"{gameObject.name} No ground points!");
    }

    private void FixedUpdate()
    {
        bool wasGrounded = IsGrounded;
        IsGrounded = false;
        
        foreach (Transform groundPoint in _groundPoints)
        {
            Debug.DrawRay(groundPoint.position, Vector3.down * GroundDistance, Color.red);
            
            if (Physics2D.Raycast(groundPoint.position, Vector2.down, GroundDistance, _groundLayer))
            {
                IsGrounded = true;
                
                if (wasGrounded == false)
                    Grounded?.Invoke();
                
                return;
            }
        }
    }
    
    public void MoveHorizontally(float horizontalDirection)
    {
        if ((IsGrounded == false) && (_canControlledInAir == false))
            return;

        _rigidbody2D.velocity = new Vector2(horizontalDirection * _moveForse, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            _rigidbody2D.AddForce(_jumpForse * Vector2.up);
            Jumped?.Invoke(true);
        }
    }
}
