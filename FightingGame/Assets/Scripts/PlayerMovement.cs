using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;
    private float inputMovementHor, inputMovementVer;

    private void Awake()
    {
        InitializeControls();
    }

    private void InitializeControls()
    {
        controls = new Controls();
        controls.Enable();

        controls.MovementControls.MovementHor.performed += context =>
        {
            inputMovementHor = context.ReadValue<float>();
        };
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {

    }
}