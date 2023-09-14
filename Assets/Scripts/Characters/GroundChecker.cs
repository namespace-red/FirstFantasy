using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    
    private Transform _groundPoint;
    private Vector2 _groundBoxDistance;
    private const float GroundYDistance = .2f;
    
    public UnityAction Grounded;
    
    public bool IsGrounding { get; private set; }
    
    private void Awake()
    {
        if ((_groundLayer.value) == gameObject.layer)
            Debug.LogError($"Name of game object:{gameObject.name}. Player Layer must be different from Ground Layer!");
        
        if (_groundPoint == null)
            CreateGroundChecker();
    }
    
    private void FixedUpdate()
    {
        CheckGrounding();
    }

    void OnDrawGizmos()
    {
        if (_groundPoint)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(_groundPoint.position, _groundBoxDistance);
        }
    }

    private void CreateGroundChecker()
    {
        GameObject groundPointGameObject = new GameObject("GroundChecker");
        groundPointGameObject.transform.SetParent(this.transform);
        
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        float x = bounds.center.x;
        float y = bounds.min.y;
        float z = this.transform.position.z;
        
        groundPointGameObject.transform.position = new Vector3(x, y, z);
        _groundPoint = groundPointGameObject.transform;

        _groundBoxDistance = new Vector2(bounds.size.x - .1f, GroundYDistance);
    }
    
    private void CheckGrounding()
    {
        bool wasGrounded = IsGrounding;
        IsGrounding = Physics2D.OverlapBox(_groundPoint.position, _groundBoxDistance, 0, _groundLayer);
        
        if (IsGrounding && wasGrounded == false)
            Grounded?.Invoke();
    }
}
