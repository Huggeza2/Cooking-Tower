
using UnityEngine;
using UnityEngine.InputSystem;

public class CuttingBoardController : MonoBehaviour
{
    [Header("Animation")]
    public Animator cuttingBoardAnimator;

    [Header("Input Settings")]
    public bool useKeyboard = true;
    public bool useArcadeButton = true;

    [Header("Arcade Button")]
    public int arcadeButtonNumber = 0;

    [Header("Cutting Settings")]
    public int requiredChops = 10;

    private int currentChops = 0;
    private bool isCuttingComplete = false;

    private bool previousButtonState = false;

    void Update()
    {
        if (isCuttingComplete)
            return;

        bool keyboardPressed = false;
        bool arcadePressed = false;

        // Space bar
        if (useKeyboard && Keyboard.current != null)
        {
            keyboardPressed = Keyboard.current.spaceKey.isPressed;
        }

        // Gamepad button
        if (useArcadeButton && Gamepad.current != null)
        {
            switch (arcadeButtonNumber)
            {
                case 0:
                    arcadePressed = Gamepad.current.buttonSouth.isPressed;
                    break;
                case 1:
                    arcadePressed = Gamepad.current.buttonEast.isPressed;
                    break;
                case 2:
                    arcadePressed = Gamepad.current.buttonWest.isPressed;
                    break;
                case 3:
                    arcadePressed = Gamepad.current.buttonNorth.isPressed;
                    break;
                case 4:
                    arcadePressed = Gamepad.current.leftShoulder.isPressed;
                    break;
                case 5:
                    arcadePressed = Gamepad.current.rightShoulder.isPressed;
                    break;
                case 6:
                    arcadePressed = Gamepad.current.startButton.isPressed;
                    break;
                case 7:
                    arcadePressed = Gamepad.current.selectButton.isPressed;
                    break;
            }
        }

        bool buttonPressed = keyboardPressed || arcadePressed;

        // Count only a new press, not a held button
        if (buttonPressed && !previousButtonState)
        {
            RegisterChop();
        }

        previousButtonState = buttonPressed;
    }

    void RegisterChop()
    {
        currentChops++;

        Debug.Log("Chops: " + currentChops + "/" + requiredChops);

        // Play cutting animation
        if (cuttingBoardAnimator != null)
        {
            cuttingBoardAnimator.SetBool("IsCutting", true);
        }

        if (currentChops >= requiredChops)
        {
            FinishCutting();
        }
    }

    void FinishCutting()
    {
        isCuttingComplete = true;

        if (cuttingBoardAnimator != null)
        {
            cuttingBoardAnimator.SetBool("IsCutting", false);
        }

        Debug.Log("CUTTING COMPLETE! Vegetables are ready!");
    }

    public void ResetCutting()
    {
        currentChops = 0;
        isCuttingComplete = false;
        previousButtonState = false;

        if (cuttingBoardAnimator != null)
        {
            cuttingBoardAnimator.SetBool("IsCutting", false);
        }

        Debug.Log("Cutting reset!");
    }
}
