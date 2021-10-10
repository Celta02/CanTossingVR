using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

    public class PlayerInput: MonoBehaviour
    {
        InputDevice _targetDevice;
        [SerializeField] bool _isRightHand;
        Animator _handAnimator;
        void Start()
        {
            TryToInitialize();
            _handAnimator = GetComponentInChildren<Animator>();
        }

        void TryToInitialize()
        {
            List<InputDevice> devices = new List<InputDevice>();
            InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.Controller;
            InputDeviceCharacteristics desiredCharacteristics;

            if (_isRightHand)
            {
                InputDeviceCharacteristics rightCharacteristic = InputDeviceCharacteristics.Right;
                desiredCharacteristics = rightCharacteristic | controllerCharacteristic;
            }
            else
            {
                InputDeviceCharacteristics leftCharacteristic = InputDeviceCharacteristics.Left;
                desiredCharacteristics = leftCharacteristic | controllerCharacteristic;
            }

            InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, devices);
            if(devices.Count > 0)
                _targetDevice = devices[0];
        }

        void Update()
        {
            if (!_targetDevice.isValid)
                TryToInitialize();
            else
                UpdateAnimator();
        }

        void UpdateAnimator()
        {
            if (_handAnimator == null) return;
            if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
                _handAnimator.SetFloat("Trigger", triggerValue);
            else
                _handAnimator.SetFloat("Trigger", 0f);

            if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
                _handAnimator.SetFloat("Grip", gripValue);
            else
                _handAnimator.SetFloat("Grip", 0f);
        }
    }