using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Movement2D))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(CharacterAnimationsController))]
[RequireComponent(typeof(EntityLook))]

public class UserInput : MonoBehaviour
{
    private Movement2D _movement2D;
    private GroundChecker _groundChecker;
    private Attacker _attacker;
    private CharacterAnimationsController _animationsController;
    private EntityLook _characterLook;
    
    private float _horizontalDirection = 0f;
    private bool _isJumped = false;

    private void Awake()
    {
        _movement2D = GetComponent<Movement2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _attacker = GetComponent<Attacker>();
        _animationsController = GetComponent<CharacterAnimationsController>();
        _characterLook = GetComponent<EntityLook>();
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {            
        _movement2D.MoveHorizontally(_horizontalDirection);
        _animationsController.SetMoveSpeed(Math.Abs(_horizontalDirection));

        if (_horizontalDirection != 0f)
        {
            _characterLook.SetDirection(_horizontalDirection);
        }
        
        if (_isJumped)
        {
            _movement2D.Jump();
            _isJumped = false;
        }
    }
    
    private void Move() =>_horizontalDirection = Input.GetAxis("Horizontal");

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            _isJumped = true;
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            if ((_animationsController.IsAttacking() == false) && _groundChecker.IsGrounding)
            {
                _attacker.Hit();
            }
        }
    }
}
