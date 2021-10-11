using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    BallsManager _ballsManager;
    int _ballNumber;
    Rigidbody _rigidBody;

    public BallsManager BallsManager { set =>_ballsManager=value;}
    public int BallNumber { set => _ballNumber = value; }

    void Awake() => _rigidBody = GetComponent<Rigidbody>();

    void OnEnable()
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Floor")) return;
        
        _ballsManager.RespawnBall(gameObject,_ballNumber);
    }
}