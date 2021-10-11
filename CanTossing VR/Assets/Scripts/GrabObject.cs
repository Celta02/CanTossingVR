using UnityEngine;
using static UnityEngine.Physics;
    public class GrabObject: MonoBehaviour
    {
        [SerializeField] Transform _snapTransform;
        [SerializeField] float _grabRadius = 0.05f;
        [SerializeField] LayerMask _layerMask;
        PlayerController _playerController;

        const int MAXColliders = 5;
        Grabbable _grabbedObject;
        float _triggerValue;
        float _gripValue;
        bool _isGrabbing;

        void Awake() => _playerController = GetComponent<PlayerController>();

        void OnEnable()
        {
            _playerController.Trigger += t => _triggerValue = t;
            _playerController.Grip += t => _gripValue = t;
        }

        void Update()
        {
            if (_triggerValue < 0.1f && _gripValue < 0.1f) Release();
                else Grab();
        }
        void Grab()
        {
            if (_isGrabbing) return;
            var results = new Collider[MAXColliders];
            var amountOfResults = OverlapSphereNonAlloc(_snapTransform.position, _grabRadius, results, _layerMask);
            if (amountOfResults == 0) return;
            
            foreach (var result in results)
            {
                var grabbable = result.gameObject.GetComponent<Grabbable>();
                if (grabbable == null) continue;

                _grabbedObject = grabbable;
                _grabbedObject.TryToGrabWith(_snapTransform, _playerController);
                _isGrabbing = true;
                return;
            }
        }
        void Release()
        {
            if (!_isGrabbing) return;
            _grabbedObject.Release();
            _isGrabbing = false;
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_snapTransform.position, _grabRadius);
        }
        
    }