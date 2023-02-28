using UnityEngine;

[RequireComponent(typeof(Movement2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _parentOfWay;
    private Movement2D _movement;
    private Rigidbody2D _rigidbody2D;
    private Vector3[] _wayPoints;
    [SerializeField] private int _currentWaypointIndex = 0;
    
    private void Start()
    {
        _movement = GetComponent<Movement2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _wayPoints = new Vector3[_parentOfWay.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _parentOfWay.GetChild(i).position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetWaypoint = _wayPoints[_currentWaypointIndex];
        Vector3 direction = targetWaypoint - transform.position;
        direction = direction.normalized;

        _movement.MoveHorizontally(direction.x);
        
        if (Mathf.Abs(transform.position.x  - targetWaypoint.x) <= 0.1f)
        {
            _currentWaypointIndex++;

            if (_currentWaypointIndex >= _wayPoints.Length)
                _currentWaypointIndex = 0;
        }
    }
}
