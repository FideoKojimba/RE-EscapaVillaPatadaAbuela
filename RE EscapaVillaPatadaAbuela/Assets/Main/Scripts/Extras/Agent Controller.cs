using UnityEngine;
using UnityEngine.InputSystem;

public class AgentController : MonoBehaviour

{
    public Vector2 moveValue;

    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();   
    }
}
