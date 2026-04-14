using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float _Vida;
    public float _Speed;
    public float _Shield;
    public UI ui;
    void Awake()
    {
        _Vida=1;
        _Speed = 1.0f;
        _Shield = 2;    
     
    }

    public void _CaminodelaGrulla (float valor)
    {
        if (_Vida < 10)
        { 
        _Vida += valor;
        }

        if (_Vida >= 10)
        { 
            _Vida = 10;  
            return;
        }

    }



    public void _CaminodelaSerpiente (float valor)
    {

        if (_Speed < 1000.0f)
        {
            _Speed *= valor;
        }

        if (_Speed >= 1000.0f)
        {
            _Speed = 1000.0f;
            return;
        }

    }

    public void _CaminodelAguila (float valor)
    {
        if (valor == 1) 
        {
        _Shield = 1;
        return;

        }
        if (valor == 0)
        {
        _Shield = 2;
        return;
        }
        else
        {
        _Shield = 3;
        return; 
        }
       

        
        

    }

    public void _takeDamage(float valor)
    {
        
        if (_Shield == 2)
        {
            _Vida -= valor;
        }

         if (_Shield == 1)
        {
            return;
        }

    }



    // Update is called once per frame
    
}
