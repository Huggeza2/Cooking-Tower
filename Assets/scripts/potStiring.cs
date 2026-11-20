using UnityEngine;
using UnityEngine.InputSystem;

public class potStiring : MonoBehaviour
{
    
    // Drag your Animator component here in the Inspector
    [SerializeField] private Animator potAnimator; 
    
    // The name of the Trigger parameter you created in your Animator controller
    [SerializeField] private string animationTriggerName = "PlayAnimation"; 
 
    public void OnInteract(InputAction.CallbackContext context)
    {
        // Only trigger the animation when the button is first pressed down
        if (context.started)
        {
            TriggerPotAnimation();
        }
    }

    private void TriggerPotAnimation()
    {
        if (potAnimator != null)
        {
            potAnimator.SetTrigger(animationTriggerName);
        }
    } 
}
