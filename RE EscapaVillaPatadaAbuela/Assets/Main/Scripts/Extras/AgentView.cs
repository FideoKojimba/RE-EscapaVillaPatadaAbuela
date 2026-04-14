using UnityEngine;
using UnityEngine.InputSystem;
public class AgentView : MonoBehaviour
{
    public Animator animator;
    public enum Animations
    {
        Walking,
        Run,
        Pain,
        Heal,
        Idle
    }
    Animations animations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
   public void AnimationState(Animations animations)
    {
        switch (animations)
        {
            case Animations.Heal:
                animator.SetTrigger("heal");
                break;

            case Animations.Pain:
                animator.SetTrigger("pain");
                break;
            default:
                break;

        }

            
  
    }
}
