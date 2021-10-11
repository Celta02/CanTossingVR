using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] float _velocityAmplificator = 5f;
    bool _isGrabbed;
    Transform _snapTransform;
    Rigidbody _rigidBody;
    PlayerController _playerController;

    void Awake() => _rigidBody = GetComponent<Rigidbody>();

    void Update()
    {
        if (!_isGrabbed) return;
        
        _rigidBody.MovePosition(_snapTransform.position);
    }

    public void TryToGrabWith( Transform snapTransform , PlayerController playerController)
    {
        if (_isGrabbed) return;
        _snapTransform = snapTransform;
        _playerController = playerController;
        _rigidBody.useGravity = false;
        _isGrabbed = true;
    }

    public void Release()
    {
        _isGrabbed = false;
        ReleaseImpulse();
        _rigidBody.useGravity = true;
    }

    void ReleaseImpulse()
    {
        var velocity = _playerController.GetVelocity() * _velocityAmplificator;
        _rigidBody.AddForce(velocity,ForceMode.VelocityChange);
    }
}