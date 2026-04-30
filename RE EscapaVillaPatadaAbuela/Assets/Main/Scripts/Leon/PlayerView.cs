using Unity.VisualScripting;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovementModel playerMovementModel;

    public enum Animaciones
    {
        Salto,
        Heal,
        Jump

    }



    private void FixedUpdate()
    {
        animator.SetFloat("Speed", playerMovementModel.CurrentSpeed);
    }

    public void UpdateAnimationTest(Animaciones animation)
    {
        switch (animation)
        {

            case Animaciones.Salto:
                animator.SetTrigger("JumpTrigger");
                break;

            case Animaciones.Heal:
                animator.SetTrigger("HealTrigger");
                break;






        }

   }

  

    
    
}
