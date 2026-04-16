using UnityEngine;
using System.Collections;

public class IntroUI : MonoBehaviour
{

    [SerializeField] private GameObject panelIntro; 
    [SerializeField] private float tiempoVisible = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static bool yaSeMostro = false;
    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
   void Start()
    {
        
        if (yaSeMostro)
        {
            Destroy(panelIntro); 
            Destroy(this.gameObject); 
            return;
        }

       
        if (panelIntro != null)
        {
            StartCoroutine(MostrarIntro());
        }
    }

    IEnumerator MostrarIntro()
    {
        yaSeMostro = true; 
        panelIntro.SetActive(true); 
        
        
        yield return new WaitForSecondsRealtime(tiempoVisible); 

  
        panelIntro.SetActive(false);
    }
}

