using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement2D))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Attacker))]

public class CharacterAnimationsController : MonoBehaviour
{
    private Animator _animator;
    private Movement2D _movement;
    private GroundChecker _groundChecker;
    private Attacker _attacker;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _attacker = GetComponent<Attacker>();
    }

    private void OnEnable()
    {
        _movement.Jumping += OnJumped;
        _groundChecker.Grounded += OnGrounded;
        _attacker.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _movement.Jumping -= OnJumped;
        _groundChecker.Grounded -= OnGrounded;
        _attacker.Attacked -= OnAttacked;
    }
    
    private void OnAttacked() => _animator.SetTrigger(States.Attack);
    
    private void OnJumped() => _animator.SetBool(Params.IsJumping, true);
    
    private void OnGrounded() => _animator.SetBool(Params.IsJumping, false);
    
    public void SetMoveSpeed(float speed) => _animator.SetFloat(Params.Speed, speed);
    
    public bool IsAttacking() => _animator.GetCurrentAnimatorStateInfo(0).IsName(States.Attack);

    private static class Params
    {
        public const string Speed = nameof(Speed);
        public const string IsJumping = nameof(IsJumping);
    }
    
    private static class States
    {
        public const string Attack = nameof(Attack);
        
    }
}
