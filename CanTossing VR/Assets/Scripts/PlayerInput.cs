using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static HandSide;

    public class PlayerInput: MonoBehaviour
    {
        public event Action<float> Trigger = delegate {};
        public event Action<float> Grip = delegate {};
        
        InputDevice _targetDevice;
        [SerializeField] Side _handSide;
        bool _isTriggerActive;
        bool _isGripActive;
        
        void Start() => TryToInitialize();
        void TryToInitialize()
        {
            var devices = new List<InputDevice>();
            var desiredCharacteristics = InputDeviceCharacteristics.Controller;

            if(_handSide == Side.Left)
                desiredCharacteristics |= InputDeviceCharacteristics.Left;
            else
                desiredCharacteristics |= InputDeviceCharacteristics.Right;

            InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, devices);
            if(devices.Count > 0)
                _targetDevice = devices[0];
        }

        void Update()
        {
            if (!_targetDevice.isValid)
                TryToInitialize();
            else
                SendInputInformation();
        }

        void SendInputInformation()
        {
            SendTriggerInformation();
            SendGripInformation();
        }
        void SendTriggerInformation()
        {
            if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out var triggerValue))
            {
                _isTriggerActive = true;
                Trigger.Invoke(triggerValue);
            }
            else
            {
                if (!_isTriggerActive) return;
                _isTriggerActive = false;
                Trigger.Invoke(0f);
            }
        }
        void SendGripInformation()
        {
            if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out var gripValue))
            {
                _isGripActive = true;
                Grip.Invoke(gripValue);
            }
            else
            {
                if (!_isGripActive) return;
                _isGripActive = false;
                Grip.Invoke(0f);
            }
        }
    }