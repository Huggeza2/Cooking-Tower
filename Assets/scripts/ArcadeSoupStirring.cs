
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ArcadeSoupStirring : MonoBehaviour
{
    [Header("Pot Animation")]
    public Animator potAnimator;

    [Header("Soup Progress")]
    public float soupProgress = 0f;
    public float requiredProgress = 100f;
    public float progressPerRevolution = 10f;

    [Header("Progress Bar (Optional)")]
    public Slider progressBar;

    [Header("Joystick Settings")]
    [Range(0.1f, 1f)]
    public float inputThreshold = 0.5f;

    public float sequenceTimeout = 2f;

    [Header("Keyboard Testing")]
    public bool allowKeyboardTesting = true;

    // Direction order:
    // 0 = Up
    // 1 = Right
    // 2 = Down
    // 3 = Left

    private int sequenceStep = 0;
    private int completedRevolutions = 0;

    private int previousDirection = -1;

    private float lastSequenceTime = 0f;

    private bool isComplete = false;

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.minValue = 0;
            progressBar.maxValue = requiredProgress;
            progressBar.value = soupProgress;
        }

        if (potAnimator != null)
        {
            potAnimator.SetBool("IsStirring", false);
        }

        Debug.Log("Soup stirring system ready!");
    }

    void Update()
    {
        if (isComplete)
            return;

        int direction = GetJoystickDirection();

        bool isMoving = direction != -1;

        // Control the pot animation
        if (potAnimator != null)
        {
            potAnimator.SetBool("IsStirring", isMoving);
        }

        // Only count a new direction when it changes
        if (direction != previousDirection)
        {
            if (direction != -1)
            {
                RegisterDirection(direction);
            }

            previousDirection = direction;
        }

        // Reset incomplete sequence if player takes too long
        if (sequenceStep > 0 &&
            Time.time - lastSequenceTime > sequenceTimeout)
        {
            sequenceStep = 0;
        }
    }

    int GetJoystickDirection()
    {
        Vector2 input = Vector2.zero;

        // Try gamepad D-pad and analog stick
        if (Gamepad.current != null)
        {
            Vector2 dpad =
                Gamepad.current.dpad.ReadValue();

            Vector2 stick =
                Gamepad.current.leftStick.ReadValue();

            input = dpad.magnitude > stick.magnitude
                ? dpad
                : stick;
        }
        // Try generic joystick
        else if (Joystick.current != null)
        {
            input = Joystick.current.stick.ReadValue();
        }

        // Optional keyboard testing
        if (allowKeyboardTesting && input.magnitude < inputThreshold)
        {
            if (Keyboard.current != null)
            {
                if (Keyboard.current.upArrowKey.isPressed ||
                    Keyboard.current.wKey.isPressed)
                    input = Vector2.up;

                else if (Keyboard.current.rightArrowKey.isPressed ||
                         Keyboard.current.dKey.isPressed)
                    input = Vector2.right;

                else if (Keyboard.current.downArrowKey.isPressed ||
                         Keyboard.current.sKey.isPressed)
                    input = Vector2.down;

                else if (Keyboard.current.leftArrowKey.isPressed ||
                         Keyboard.current.aKey.isPressed)
                    input = Vector2.left;
            }
        }

        if (input.magnitude < inputThreshold)
            return -1;

        // Choose the strongest direction.
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            return input.x > 0 ? 1 : 3;
        }
        else
        {
            return input.y > 0 ? 0 : 2;
        }
    }

    void RegisterDirection(int direction)
    {
        lastSequenceTime = Time.time;

        // Start sequence with UP
        if (sequenceStep == 0)
        {
            if (direction == 0)
            {
                sequenceStep = 1;
                Debug.Log("Stirring sequence started!");
            }

            return;
        }

        // Expected direction:
        // Right, Down, Left
        int expectedDirection = sequenceStep;

        if (direction == expectedDirection)
        {
            sequenceStep++;

            Debug.Log("Stirring step: " + sequenceStep);

            // Completed UP -> RIGHT -> DOWN -> LEFT
            if (sequenceStep == 4)
            {
                CompleteRevolution();
                sequenceStep = 0;
            }
        }
        else if (direction == 0)
        {
            // New sequence starts at UP
            sequenceStep = 1;
            Debug.Log("Stirring sequence restarted!");
        }
        else
        {
            // Wrong direction resets sequence
            sequenceStep = 0;
            Debug.Log("Sequence reset. Try again!");
        }
    }

    void CompleteRevolution()
    {
        completedRevolutions++;

        soupProgress += progressPerRevolution;

        soupProgress = Mathf.Clamp(
            soupProgress,
            0f,
            requiredProgress
        );

        // Update progress bar
        if (progressBar != null)
        {
            progressBar.value = soupProgress;
        }

        Debug.Log("Revolutions: " + completedRevolutions);
        Debug.Log("Soup progress: " + soupProgress + "%");

        if (soupProgress >= requiredProgress)
        {
            FinishCooking();
        }
    }

    void FinishCooking()
    {
        isComplete = true;

        if (potAnimator != null)
        {
            potAnimator.SetBool("IsStirring", false);
        }

        Debug.Log("SOUP IS READY!");
    }

    public void ResetCooking()
    {
        soupProgress = 0f;
        completedRevolutions = 0;
        sequenceStep = 0;
        previousDirection = -1;
        isComplete = false;

        if (progressBar != null)
        {
            progressBar.value = 0;
        }

        if (potAnimator != null)
        {
            potAnimator.SetBool("IsStirring", false);
        }

        Debug.Log("Cooking reset!");
    }
}
