using UnityEngine;
using UnityEngine.Serialization;

public class HandsAnimation : MonoBehaviour
{
    [FormerlySerializedAs("_playerInput")] [SerializeField] PlayerController _playerController;
    Animator _animator;

    void Awake() => _animator = GetComponent<Animator>();

    void OnEnable()
    {
        _playerController.Trigger += TriggerAnimation;
        _playerController.Grip += GripAnimation;
    }
    
    void OnDisable()
    {
        _playerController.Trigger -= TriggerAnimation;
        _playerController.Grip -= GripAnimation;
    }

    void GripAnimation(float gripValue) => _animator.SetFloat("Grip", gripValue > 0.1 ? gripValue : 0f);
    void TriggerAnimation(float triggerValue) => _animator.SetFloat("Trigger", triggerValue > 0.1 ? triggerValue : 0f);
}