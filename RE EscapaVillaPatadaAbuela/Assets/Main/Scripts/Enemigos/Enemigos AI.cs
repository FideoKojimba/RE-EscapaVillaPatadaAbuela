using UnityEngine;
using UnityEngine.AI;

public class EnemigosAI : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform jugador; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null)
        {
            agente.SetDestination(jugador.position);
        }
    }
}
