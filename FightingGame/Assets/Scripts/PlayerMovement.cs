using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager.InputManager inputManager;

    private void Awake()
    {
        inputManager.performedLightAttack.AddListener(LightAttack);
        inputManager.performedHeavyAttack.AddListener(HeavyAttack);
        inputManager.performedLeftStick.AddListener(LeftStickChanged);
    }

    private void LightAttack()
    {
        Debug.Log("Light attack!");
    }

    private void HeavyAttack()
    {
        Debug.Log("Heavy attack!");
    }

    private void LeftStickChanged()
    {
        Debug.Log("Left stick changed!");
    }
}