using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeonUI : MonoBehaviour
{

    [SerializeField] private LeonStats leonStats;
    [SerializeField] private List<Image> corazones;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarVida();
    }

    void ActualizarVida ()
    {
        
        for (int i = 0; i < corazones.Count; i++)
        {
            
            if (i < leonStats.Vida)
            {
                corazones[i].enabled = true;
            }
            else
            {
                corazones[i].enabled = false;
            }
        }
    }
}
