using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FightingGameInput
{
    public class StickManager : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private Vector2 axis;
        private Vector2 previousAxis;

        [SerializeField] private InputDirection direction;
        private InputDirection previousDirection;

        private const float TWO_PI = 6.28318531f;
        private const float ONE_EIGHTH = 0.125f;
        private const float DEAD_ZONE = 0.2f;

        [HideInInspector] public UnityEvent performedLeftStick = new UnityEvent();

        private void Awake()
        {
            performedLeftStick = new UnityEvent();
        }

        private void Update()
        {
            GetUpdatedAxisValue();
            GetUpdatedInputDirection();
        }

        private void GetUpdatedAxisValue()
        {
            Vector2 tmp = inputManager.axisLeftStick.GetValue();

            if (tmp != previousAxis)
            {
                axis = tmp;

                previousAxis = axis;
            }
        }

        private void GetUpdatedInputDirection()
        {
            // our direction is none if both axes are less than the dead zone
            if (Mathf.Abs(axis.x) < DEAD_ZONE && Mathf.Abs(axis.y) < DEAD_ZONE)
            {
                if (previousDirection != InputDirection.none)
                {
                    direction = InputDirection.none;

                    previousDirection = direction;
                    performedLeftStick.Invoke();
                }

                return;
            }

            // set default direction
            InputDirection tmp = InputDirection.r;

            // calculate angle
            float angle = Mathf.Atan2(axis.y, axis.x);
            if (angle < 0.0f)
            {
                angle += TWO_PI;
            }

            for (int i = 1; i <= 9; ++i)
            {
                // check if the input direction has changed
                if (TrySetInputDirection(angle, i, tmp))
                {
                    // if we've gone all the way around, we're actually right again
                    if (tmp == InputDirection.r2)
                    {
                        tmp = InputDirection.r;
                    }

                    if (tmp != previousDirection)
                    {
                        // update the direction
                        previousDirection = direction;
                        direction = tmp;

                        performedLeftStick.Invoke();
                    }
                    return;                    
                }

                ++tmp;
            }
        }

        private bool TrySetInputDirection(float value, float eighthMultiplier, InputDirection dir)
        {
            if (value < (TWO_PI * (ONE_EIGHTH * eighthMultiplier)) - (ONE_EIGHTH * 0.5f))
            {
                return true;
            }
            return false;
        }

        public InputDirection GetDirection()
        {
            return direction;
        }

        public bool GetJumpInput()
        {
            if (direction == InputDirection.ur || direction == InputDirection.u || direction == InputDirection.ul)
            {
                if (previousDirection != InputDirection.ur && previousDirection != InputDirection.u && previousDirection != InputDirection.ul)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public enum InputDirection { none, r, ur, u, ul, l, dl, d, dr, r2 };
}