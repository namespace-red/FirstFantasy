using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationsController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoveSpeed(float speed) => _animator.SetFloat(Params.Speed, speed);
    public bool IsAttacking() => _animator.GetCurrentAnimatorStateInfo(0).IsName(States.Attack);
    public void OnAttacked() => _animator.SetTrigger(States.Attack);
    public void OnJumped() => _animator.SetBool(Params.IsJumping, true);
    public void OnGrounded() => _animator.SetBool(Params.IsJumping, false);

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
