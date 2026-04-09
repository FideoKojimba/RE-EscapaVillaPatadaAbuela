using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LeonStats : MonoBehaviour
{
    [SerializeField]
    private float Vida = 3;
    private Vector3 checkPoint;

    [SerializeField] 
    private float fuerzaKnockback = 10f; 
    [SerializeField] 
    private float duracionInmune = 1f;
    [SerializeField] 
    private Renderer modeloRender; 
    [SerializeField]
     private Color colorDaño = Color.red;
     [SerializeField]
     private Rigidbody rb;
     private Color colorOriginal;

    void Start()
    {
        if (modeloRender != null)
        {
            colorOriginal = modeloRender.material.color;
        }
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MuerteInstantanea"))
        {
            Vida = 0;
        }

        if (collider.CompareTag("Enemigo"))
        {
            KnockbackEnemigo(collider);
        }
        

    }

    void KnockbackEnemigo( Collider Knockback)
    {
        Vida --;

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


}
