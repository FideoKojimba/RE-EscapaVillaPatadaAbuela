using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerModel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private PlayeController playeController;
    public Rigidbody rb;

    float velocidad = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    private void Movimiento ()
    {
        rb.linearVelocity = playeController.DireccionJugador() * velocidad;
    }
}
