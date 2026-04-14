using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class AgentModel : MonoBehaviour
{
    [SerializeField] private AgentController _agentController;
    [SerializeField] private float _velocidad = 20f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private AgentView _agentView;
    
    public void Movimiento()
    {
        _rb.linearVelocity = new Vector3(_agentController.moveValue.x * _velocidad
        , _rb.linearVelocity.y,
         _agentController.moveValue.y * _velocidad); 
    }
   
    void Update()
    {
       
        float veloMax = 10;
        float veloNormalizada = _rb.angularVelocity.magnitude / veloMax;

         if (_rb.linearVelocity.magnitude < 0.001)
        {
            veloNormalizada = 0.001f;
            _agentView.animator.SetFloat("Velocidad", veloNormalizada);
        }

         else
        {
            _agentView.animator.SetFloat("Velocidad", veloNormalizada);
            Movimiento();
        }
        
    }
}

