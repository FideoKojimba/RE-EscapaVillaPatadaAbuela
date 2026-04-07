using UnityEngine;                  // Librería principal de Unity.
using UnityEngine.InputSystem;      // Librería del nuevo Input System.
using UnityEngine.Rendering;

public class PlayerInputController : MonoBehaviour
{
    // Referencia privada a la acción de movimiento del Input System.
    private InputAction _moveAction;
    private InputAction _jumpAction;
    [SerializeField] private PlayerMovementModel _movementModel;

    // Propiedad pública de solo lectura.
    public Vector2 MoveInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool _jumpRequested;

    private void Start()
    {
        // Busca la acción llamada "Move" dentro del Input Actions Asset.
        _moveAction = InputSystem.actions.FindAction("Move");

        _jumpAction = InputSystem.actions.FindAction("Jump");


        // Si la encuentra, la habilita.
        if (_moveAction != null)
        {
            _moveAction.Enable();
            Debug.Log("[PlayerInputController] Acción 'Move' encontrada y habilitada correctamente.");
        }
        else
        {
            Debug.LogError("[PlayerInputController] No se encontró la acción 'Move'.");
        }

        if (_jumpAction != null)
        {
            _jumpAction.Enable();
            Debug.Log("[PlayerInputController] Acción 'Jump' encontrada y habilitada correctamente.");
        }
        else
        {
            Debug.LogError("[PlayerInputController] No se encontró la acción 'Jump'.");
        }


    }

    void Update()
    {
        // Capturamos el input en cada frame para no perder ninguna pulsación
        if (_jumpAction != null && _movementModel.IsGrounded == true && _jumpAction.WasPressedThisFrame())
        {
            _jumpRequested = true;
        }
    }
    private void FixedUpdate()
    {
        if (_moveAction == null) return;

        MoveInput = _moveAction.ReadValue<Vector2>();

        if (_jumpAction == null) return;

        // Leemos el input actual como Vector2.
        MoveInput = _moveAction.ReadValue<Vector2>();

        JumpInput = _jumpAction.WasPressedThisFrame();
        // Debug solo cuando hay input.
        if (MoveInput != Vector2.zero)
        {
            Debug.Log($"[PlayerInputController] Input detectado: {MoveInput}");
        }

        if (_jumpRequested == true)
        {

            Debug.Log($"[PlayerInputController] Input detectado: {JumpInput}");
            

            Debug.Log("[PlayerInputController] Salto ejecutado con éxito.");
        }

    }



    private void OnDisable()
    {
        // Deshabilitamos la acción cuando el objeto se apaga.
        if (_moveAction != null)
        {
            _moveAction.Disable();
            Debug.Log("[PlayerInputController] Acción 'Move' deshabilitada.");
        }

        if (_jumpAction != null)
        {
            _jumpAction.Disable();
            Debug.Log("[PlayerInputController] Acción 'Jump' deshabilitada.");
        }


    }
}