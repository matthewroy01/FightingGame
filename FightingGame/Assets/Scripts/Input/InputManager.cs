using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace InputManager
{
    public class InputManager : MonoBehaviour
    {
        private Controls controls;

        [HideInInspector] public UnityEvent performedLightAttack { get; private set; }
        [HideInInspector] public UnityEvent performedHeavyAttack { get; private set; }
        [HideInInspector] public UnityEvent performedLeftStick { get; private set; }

        public CustomAxis axisLeftStick;

        private void Awake()
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
            controls = new Controls();
            controls.Enable();

            // initialize unity events
            InitializeEvents();

            // initialize inputs
            InitializeButtons();
            InitializeAxes();
        }

        private void InitializeEvents()
        {
            performedLightAttack = new UnityEvent();
            performedHeavyAttack = new UnityEvent();
            performedLeftStick = new UnityEvent();
        }

        private void InitializeButtons()
        {
            // light attack
            controls.FightingControls.LightAttack.performed += context =>
            {
                performedLightAttack.Invoke();
            };

            // heavy attack
            controls.FightingControls.HeavyAttack.performed += context =>
            {
                performedHeavyAttack.Invoke();
            };
        }

        private void InitializeAxes()
        {
            // left stick
            axisLeftStick = new CustomAxis(performedLeftStick);
        }

        private void Update()
        {
            // update axis values
            axisLeftStick.TryUpdateAxis(controls.FightingControls.LeftStick.ReadValue<Vector2>());
        }
    }

    public class CustomAxis
    {
        private Vector2 previousValue;
        private Vector2 value;
        public UnityEvent performedLeftStick { get; private set; }

        public CustomAxis(UnityEvent _performedLeftStick)
        {
            performedLeftStick = _performedLeftStick;
        }

        public void TryUpdateAxis(Vector2 _value)
        {
            // if the axis' value has changed since last time, update the value and invoke an event
            if (previousValue != _value)
            {
                value = _value;

                previousValue = _value;

                performedLeftStick.Invoke();
            }
        }

        public Vector2 GetValue()
        {
            return value;
        }
    }
}