using UnityEngine;
using UnityEngine.InputSystem;
public class PlayeController : MonoBehaviour
{
    InputAction moveAction;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
    }

    public Vector2 DireccionJugador()
    {
        return moveAction.ReadValue<Vector2>();
    }
}
