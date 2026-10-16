using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;public class ArcadeInputDebugger : MonoBehaviour
{
    public class buttons
    {
        private void Update()
        {
            Vector2 move = InputManager.GetMove();
            float horizontal = move.x;
            float vertical = move.y;
            if (InputManager.GetJumpDown())
            {  }

            if (InputManager.GetSprint())
            {
                // Sprint } if (InputManager.GetCrouchDown()) { // Börja croucha } if (InputManager.GetAttackDown()) { // Attack } }
            }
        }
    }
}