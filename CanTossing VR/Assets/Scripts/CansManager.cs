using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

    public class CansManager: MonoBehaviour
    {
        List<Vector3> _cansOriginalPosition = new List<Vector3>();
        List<Rigidbody> _cansRigidBody = new List<Rigidbody>();
        void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var canTransform = transform.GetChild(i);
                _cansRigidBody.Add(canTransform.GetComponent<Rigidbody>());
                _cansOriginalPosition.Add(canTransform.position);
            }
        }
        [ContextMenu("restartCans")]
        public void RestartCans()
        {
            for (int i = 0; i < _cansRigidBody.Count; i++)
            {
                var rb = _cansRigidBody[i];
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                _cansRigidBody[i].rotation = quaternion.identity;
                _cansRigidBody[i].position = _cansOriginalPosition[i];
            }
        }
    }