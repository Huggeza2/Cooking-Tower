
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    private static readonly InputSystem_Actions input;

    static InputManager()
    {
        input = new InputSystem_Actions();
        input.Player.Enable();
    }

    // --------------------------------------------------
    // Movement
    // --------------------------------------------------

    public static Vector2 GetMove()
    {
        return input.Player.Move.ReadValue<Vector2>();
    }

    public static Vector2 GetLook()
    {
        return input.Player.Look.ReadValue<Vector2>();
    }


    // --------------------------------------------------
    // Attack
    // --------------------------------------------------

    public static bool GetAttack()
    {
        return input.Player.Attack.IsPressed();
    }

    public static bool GetAttackDown()
    {
        return input.Player.Attack.WasPressedThisFrame();
    }

    public static bool GetAttackUp()
    {
        return input.Player.Attack.WasReleasedThisFrame();
    }


    // --------------------------------------------------
    // Interact
    // --------------------------------------------------

    public static bool GetInteract()
    {
        return input.Player.Interact.IsPressed();
    }

    public static bool GetInteractDown()
    {
        return input.Player.Interact.WasPressedThisFrame();
    }

    public static bool GetInteractUp()
    {
        return input.Player.Interact.WasReleasedThisFrame();
    }


    // --------------------------------------------------
    // Crouch
    // --------------------------------------------------

    public static bool GetCrouch()
    {
        return input.Player.Crouch.IsPressed();
    }

    public static bool GetCrouchDown()
    {
        return input.Player.Crouch.WasPressedThisFrame();
    }

    public static bool GetCrouchUp()
    {
        return input.Player.Crouch.WasReleasedThisFrame();
    }


    // --------------------------------------------------
    // Jump
    // --------------------------------------------------

    public static bool GetJump()
    {
        return input.Player.Jump.IsPressed();
    }

    public static bool GetJumpDown()
    {
        return input.Player.Jump.WasPressedThisFrame();
    }

    public static bool GetJumpUp()
    {
        return input.Player.Jump.WasReleasedThisFrame();
    }


    // --------------------------------------------------
    // Previous
    // --------------------------------------------------

    public static bool GetPrevious()
    {
        return input.Player.Previous.IsPressed();
    }

    public static bool GetPreviousDown()
    {
        return input.Player.Previous.WasPressedThisFrame();
    }

    public static bool GetPreviousUp()
    {
        return input.Player.Previous.WasReleasedThisFrame();
    }


    // --------------------------------------------------
    // Next
    // --------------------------------------------------

    public static bool GetNext()
    {
        return input.Player.Next.IsPressed();
    }

    public static bool GetNextDown()
    {
        return input.Player.Next.WasPressedThisFrame();
    }

    public static bool GetNextUp()
    {
        return input.Player.Next.WasReleasedThisFrame();
    }


    // --------------------------------------------------
    // Sprint
    // --------------------------------------------------

    public static bool GetSprint()
    {
        return input.Player.Sprint.IsPressed();
    }

    public static bool GetSprintDown()
    {
        return input.Player.Sprint.WasPressedThisFrame();
    }

    public static bool GetSprintUp()
    {
        return input.Player.Sprint.WasReleasedThisFrame();
    }


    // --------------------------------------------------
    // Enable / Disable
    // --------------------------------------------------

    public static void Enable()
    {
        input.Player.Enable();
    }

    public static void Disable()
    {
        input.Player.Disable();
    }
}

