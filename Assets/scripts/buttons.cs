using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;public class ArcadeInputDebugger : MonoBehaviour
{
    public class buttons
    {
        private void Start()
        {
            Debug.Log("=== CONNECTED INPUT DEVICES ===");

            foreach (var device in InputSystem.devices)
            {
                Debug.Log(
                    $"Device: {device.displayName} | " +
                    $"Type: {device.GetType().Name} | " +
                    $"ID: {device.deviceId}"
                );
            }

            Debug.Log("===============================");
        }

        private void Update()
        {
            foreach (var device in InputSystem.devices)
            {
                if (device is Gamepad gamepad)
                {
                    CheckGamepad(gamepad);
                }
                else if (device is Joystick joystick)
                {
                    CheckJoystick(joystick);
                }
            }
        }

        private void CheckGamepad(Gamepad gamepad)
        {
            for (int i = 0; i < gamepad.allControls.Count; i++)
            {
                var control = gamepad.allControls[i];

                if (control is ButtonControl button && button.wasPressedThisFrame)
                {
                    Debug.Log(
                        $"GAMEPAD BUTTON PRESSED: " +
                        $"{control.displayName} | " +
                        $"Control: {control.path}"
                    );
                }
            }
        }

        private void CheckJoystick(Joystick joystick)
        {
            foreach (var control in joystick.allControls)
            {
                if (control is ButtonControl button && button.wasPressedThisFrame)
                {
                    Debug.Log(
                        $"JOYSTICK BUTTON PRESSED: " +
                        $"{control.displayName} | " +
                        $"Control: {control.path}"
                    );
                }
            }
        }
    }
}
