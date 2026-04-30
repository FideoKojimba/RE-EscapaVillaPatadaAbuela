using UnityEngine;  // Librería principal de Unity.

public class PlayerMovementModel : MonoBehaviour
{
    [Header("Referencias")]

    // Referencia al script que lee el input.
    [SerializeField] private PlayerInputController playerInputController;

    // Referencia al Rigidbody del personaje.
    [SerializeField] private Rigidbody rb;

    [Header("Movimiento")]

    // Velocidad de movimiento del personaje.
    public float moveSpeed = 5f;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoSalto;

    public bool IsGrounded;
    [SerializeField] private float jumpCooldown = 0.2f;

    private float lastJumpTime;

    // Velocidad horizontal actual del personaje.
    public Vector3 CurrentHorizontalVelocity { get; private set; }

    // Magnitud de la velocidad horizontal.
    public float CurrentSpeed { get; private set; }

    [SerializeField] private PlayerView playerView;

    // NUEVO:
    // Dirección actual del movimiento en el plano XZ.
    // Esto lo usaremos para girar visualmente al personaje.
    public Vector3 CurrentMoveDirection { get; private set; }

    private void Start()
    {
        // Revisamos referencias importantes.
        if (playerInputController == null)
        {
            Debug.LogError("[PlayerMovementModel] Falta asignar PlayerInputController en el Inspector.");
        }

        if (rb == null)
        {
            Debug.LogError("[PlayerMovementModel] Falta asignar Rigidbody en el Inspector.");
        }
    }

    private void Update()
    {


    }

    private void FixedUpdate()
    {
        // Mueve el rigidbody.
        Move();

        Jump();

        // Actualiza velocidad y dirección real.
        UpdateVelocityData();


    }

    private void Move()
    {
        // Si falta algo, no seguimos.
        if (playerInputController == null || rb == null) return;

        // Leemos el input actual.
        Vector2 input = playerInputController.MoveInput;

        // Convertimos el input 2D a dirección 3D.
        Vector3 moveDirection = new Vector3(input.x, 0f, input.y);

        // Si la magnitud es mayor a 1, normalizamos
        // para evitar que en diagonal se mueva más rápido.
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // Guardamos la dirección actual solo si realmente hay input.
        if (moveDirection != Vector3.zero)
        {
            CurrentMoveDirection = moveDirection;
        }

        // Creamos la nueva velocidad.
        Vector3 newVelocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.linearVelocity.y,
            moveDirection.z * moveSpeed
        );

        // Aplicamos la velocidad al Rigidbody.
        rb.linearVelocity = newVelocity;

        // Debug de movimiento.
        if (moveDirection != Vector3.zero)
        {
            Debug.Log($"[PlayerMovementModel] Dirección de movimiento: {CurrentMoveDirection}");
            Debug.Log($"[PlayerMovementModel] Velocidad aplicada al Rigidbody: {rb.linearVelocity}");
        }
    }

    public  void Jump() 
    {
        if (playerInputController._jumpRequested)
        {
            Debug.Log($"Intento de salto: Grounded es {IsGrounded}");
        
        }

        Debug.Log ("No salta");
        if (playerInputController._jumpRequested == true && IsGrounded ==true && Time.time > lastJumpTime + jumpCooldown) 
        {

            if (audioSource != null && sonidoSalto != null)
        {

            audioSource.PlayOneShot(sonidoSalto);
        }
            
            lastJumpTime = Time.time;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerView.UpdateAnimationTest(PlayerView.Animaciones.Salto);
            IsGrounded = false;
            playerInputController._jumpRequested = false;
            Debug.Log("¡Saltando!");
            return;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo")|| collision.gameObject.CompareTag("Veneno"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo")|| collision.gameObject.CompareTag("Veneno"))
        {
            IsGrounded = false;
        }
    }



    private void UpdateVelocityData()
    {
        // Si no hay rigidbody, no seguimos.
        if (rb == null) return;

        // Tomamos la velocidad actual del rigidbody.
        Vector3 horizontalVelocity = rb.linearVelocity;

        // Quitamos Y para quedarnos solo con movimiento horizontal.
        horizontalVelocity.y = 0f;

        // Guardamos velocidad horizontal.
        CurrentHorizontalVelocity = horizontalVelocity;

        // Calculamos la magnitud de la velocidad.
        CurrentSpeed = horizontalVelocity.magnitude;

        // Debug importante para comprobar velocidad real.
        if (CurrentSpeed > 0f)
        {
            Debug.Log($"[PlayerMovementModel] CurrentHorizontalVelocity: {CurrentHorizontalVelocity} | CurrentSpeed: {CurrentSpeed}");
        }
    }
}