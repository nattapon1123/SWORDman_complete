using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControl;
    public float valueX;
    public bool jumpInput;
    public bool tryAttack;

    public void Awake()
    {
        myControl = new Controls();
    }
    private void OnEnable()
    {
        myControl.Player.Move.performed += StartMove;
        myControl.Player.Move.canceled += StopMove;
        myControl.Player.Jump.performed += JumpStart;
        myControl.Player.Jump.canceled += JumpStop;
        myControl.Player.Attack.performed += TryToAttach;
        myControl.Player.Attack.canceled += StopTryToAttack;
        myControl.Player.Enable();
    }
    private void OnDisable()
    {
        myControl.Player.Move.performed -= StartMove;
        myControl.Player.Move.canceled -= StopMove;
        myControl.Player.Jump.performed -= JumpStart;
        myControl.Player.Jump.canceled -= JumpStop;
        myControl.Player.Attack.performed -= TryToAttach;
        myControl.Player.Attack.canceled -= StopTryToAttack;
        myControl.Player.Disable();
    }
    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<float>();
    }
    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }
    private void JumpStart(InputAction.CallbackContext ctx)
    {
        jumpInput = true;
    }
    private void JumpStop(InputAction.CallbackContext ctx)
    {
        jumpInput = false;
    }

    public void DisableControls()
    {
        myControl.Player.Move.performed -= StartMove;
        myControl.Player.Move.canceled -= StopMove;

        myControl.Player.Jump.performed -= JumpStart;
        myControl.Player.Jump.canceled -= JumpStop;

        myControl.Player.Attack.performed -= TryToAttach;
        myControl.Player.Attack.canceled -= StopTryToAttack;

        myControl.Player.Disable();
        valueX = 0;
    }
    private void TryToAttach(InputAction.CallbackContext ctx)
    {
       tryAttack = true;
    }
    private void StopTryToAttack(InputAction.CallbackContext ctx)
    {
       tryAttack = false;
    }
}