using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

    public class CansManager: MonoBehaviour
    {
        List<Vector3> _cansOriginalPosition = new List<Vector3>();
        List<Transform> _cans = new List<Transform>();
        void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var canTransform = transform.GetChild(i);
                _cans.Add(canTransform);
                _cansOriginalPosition.Add(canTransform.position);
            }
        }
        [ContextMenu("restartCans")]
        public void RestartCans()
        {
            for (int i = 0; i < _cans.Count; i++)
            {
                var rb = _cans[i].GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                _cans[i].rotation = quaternion.identity;
                _cans[i].position = _cansOriginalPosition[i];
            }
        }
    }