using UnityEngine;

[RequireComponent(typeof(Movement2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _parentOfWay;
    [SerializeField] private int _currentWaypointIndex = 0;
    [SerializeField] private float _roundedDistanceToTarget = 0.1f;
    private Movement2D _entityMovement;
    private Rigidbody2D _rigidbody2D;
    private Vector3[] _wayPoints;
    
    private void Start()
    {
        _entityMovement = GetComponent<Movement2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _wayPoints = new Vector3[_parentOfWay.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _parentOfWay.GetChild(i).position;
        }
    }

    private void FixedUpdate()
    {
        if (IsEntityOnWaypoint())
        {
            ChangeWaypointIndex();
        }
        else
        {
            Vector3 normalizedDirection = GetNormalizedDirection();
            _entityMovement.MoveHorizontally(normalizedDirection.x);
        }
    }

    private bool IsEntityOnWaypoint()
    {
        Vector3 targetWaypoint = _wayPoints[_currentWaypointIndex];
        return Mathf.Abs(transform.position.x  - targetWaypoint.x) <= _roundedDistanceToTarget;
    }

    private void ChangeWaypointIndex()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex >= _wayPoints.Length)
            _currentWaypointIndex = 0;
    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 targetWaypoint = _wayPoints[_currentWaypointIndex];
        Vector3 direction = targetWaypoint - transform.position;
        return direction.normalized;
    }
}
