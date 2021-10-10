using UnityEngine;

public class HandsAnimation : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    Animator _animator;

    void Awake() => _animator = GetComponent<Animator>();

    void OnEnable()
    {
        _playerInput.Trigger += TriggerAnimation;
        _playerInput.Grip += GripAnimation;
    }
    
    void OnDisable()
    {
        _playerInput.Trigger -= TriggerAnimation;
        _playerInput.Grip -= GripAnimation;
    }

    void GripAnimation(float gripValue) => _animator.SetFloat("Grip", gripValue > 0.1 ? gripValue : 0f);
    void TriggerAnimation(float triggerValue) => _animator.SetFloat("Trigger", triggerValue > 0.1 ? triggerValue : 0f);
}