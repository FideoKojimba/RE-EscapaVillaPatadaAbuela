using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LeonStats : MonoBehaviour
{

    public float Vida = 3;
    private Vector3 checkPoint;

    [SerializeField] 
    private float fuerzaKnockback = 10f; 

    [SerializeField] 
    private Renderer modeloRender; 
    [SerializeField]
     private Color colorDaño = Color.red;
     [SerializeField]
     private Rigidbody rb;

     [SerializeField]
    private GameObject objetoEscudo;
    [SerializeField] 
    private AudioSource audioSource;
    [SerializeField] 
    private PlayerMovementModel movementModel;
    [SerializeField] 
    private float multiplicadorVelocidad = 2f;
    [SerializeField] 
    private float duracionSpeedBoost = 5f;
    [SerializeField] 
    private AudioClip sonidoSpeed;

    [SerializeField] 
    private AudioClip sonidoGrito;
    [SerializeField] 
    private AudioClip sonidoCuracion;
    [SerializeField] 
    private AudioClip sonidoEscudo;
    [SerializeField] 
    private Animator animator;
    [SerializeField] 
    private GameObject panelFinal;
    [SerializeField] 
    private AudioClip musicaVictoria;
    [SerializeField]
     private AudioSource audioSourceMusicaFondo;
    private bool esInvencible = false;
     private Color colorOriginal;

    void Start()
    {

            colorOriginal = modeloRender.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vida <= 0)
        {
            ReiniciarNivel();
        }
    }

    void ReiniciarNivel()
    {
        SceneManager.LoadScene(1);
        Vida = 3;
   
    }


        private void OnCollisionEnter(Collision collision)
    {
    // Si tocamos el veneno
        if (collision.gameObject.CompareTag("Veneno"))
        {
        KnockbackEnemigo(collision.collider);
        }
    }
    

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MuerteInstantanea"))
        {
            Vida = 0;
        }

        if (collider.CompareTag("Shield"))
        {
             StartCoroutine(ActivarEscudo());
             if (audioSource != null && sonidoEscudo != null)
                {
                     audioSource.PlayOneShot(sonidoEscudo);
                }
              Destroy(collider.gameObject); 
        }

        if (collider.CompareTag("Speed"))
            {
            StartCoroutine(ActivarSpeedBoost());
             if (audioSource != null && sonidoSpeed != null)
                audioSource.PlayOneShot(sonidoSpeed);
    
              Destroy(collider.gameObject);
            }

        if (collider.CompareTag("Meta"))
             {
                 MostrarFinal();
                Destroy(collider.gameObject); 
             }

        

        if (collider.CompareTag("Enemigo"))
        {
            
            KnockbackEnemigo(collider);
        }

        if (collider.CompareTag("Heal"))
        {
            if (Vida < 3)
            {
                Vida++;

                if (animator != null)
            {
                animator.SetTrigger("HealTrigger");
            }

                if (audioSource != null && sonidoCuracion != null)
                {
                     audioSource.PlayOneShot(sonidoCuracion);
                }
           
                Destroy(collider.gameObject);

            }
            
        }

    }

    void KnockbackEnemigo( Collider Knockback)
    {
        if (esInvencible) return;

        Vida --;

        if (animator != null)
        {
            animator.SetTrigger("DamageTrigger");
            Debug.Log("Trigger de daño disparado en el código");
        }

        if (audioSource != null && sonidoGrito != null)
    {
        audioSource.PlayOneShot(sonidoGrito);
    }

       
        if (Vida <= 0)
        {
            ReiniciarNivel();
        }

        else
        {
            Vector3 direccionEmpuje = (transform.position - Knockback.transform.position).normalized;
            direccionEmpuje.y = 0.5f;

            if (rb != null)
            {
                rb.AddForce(direccionEmpuje * fuerzaKnockback, ForceMode.Impulse);
            }

            StartCoroutine(EfectoDaño());
        
        }
    }

    IEnumerator EfectoDaño()
    {
        modeloRender.material.color= colorDaño;

        yield return new WaitForSeconds(1f);

        modeloRender.material.color = colorOriginal;
    }

    IEnumerator ActivarEscudo()
{
    esInvencible = true;
    
    if (objetoEscudo != null) 
        objetoEscudo.SetActive(true);

    yield return new WaitForSeconds(10f);

    esInvencible = false;
    
    if (objetoEscudo != null) 
        objetoEscudo.SetActive(false); // Desaparece el modelo 3D


}

IEnumerator ActivarSpeedBoost()
{
    float velocidadOriginal = 5f;

    movementModel.moveSpeed = velocidadOriginal * multiplicadorVelocidad;

    Debug.Log("¡Velocidad aumentada!");

    yield return new WaitForSeconds(duracionSpeedBoost);

    movementModel.moveSpeed = velocidadOriginal;

    Debug.Log("Velocidad normalizada");
}

void MostrarFinal()
{
    if (panelFinal != null)
    {
      if (audioSourceMusicaFondo != null && musicaVictoria != null)
        {
            audioSourceMusicaFondo.Stop();            // Paramos la música vieja
            audioSourceMusicaFondo.clip = musicaVictoria; // Ponemos la nueva
            audioSourceMusicaFondo.loop = true;       // Nos aseguramos de que sea un bucle
            audioSourceMusicaFondo.Play();            // ¡A celebrar!
        }
        panelFinal.SetActive(true); 
        Debug.Log("¡JUEGO COMPLETADO! ¡MUEJEJEJE!");
        
        Time.timeScale = 0f; 

        
        if (movementModel != null) movementModel.enabled = false;
    
    }
}

}
