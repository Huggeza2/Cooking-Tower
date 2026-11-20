using UnityEngine;

public class potStiring : MonoBehaviour
{
    
    // Drag your Animator component here in the Inspector
    [SerializeField] private Animator potAnimator; 
    
    // The name of the Trigger parameter you created in your Animator controller
    [SerializeField] private string animationTriggerName = "PlayAnimation"; 
 
    // Update is called once per frame
    void Update()
    {
        // Example: Triggers the animation when the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E))
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
        else
        {
            Debug.LogWarning($"Animator is missing on {gameObject.name}!");
        }
    } 
}
