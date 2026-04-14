using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PlayerStats stats;
    public enum PowerUps

    {
        Heal,
        Speed_Boost,
        Shield,
        Damage

    }

    [Header("Inputs")]
	[SerializeField] private TMP_InputField _InputA;

    [Header("Outputs")]
	[SerializeField] private TMP_Text _Estado;


    [Header("PowerUps")]
    [SerializeField] private PowerUps _powerups;

    public void SeleccionarPowerup(PowerUps powerups)
	{
		_powerups = powerups;	
	}

    public void SeleccionaHeal()
    {
        _powerups = PowerUps.Heal;
        _Estado.text = "Estilo de la grulla seleccionado";

    }

    public void SeleccionaSpeed_Boost()
    {
        _powerups = PowerUps.Speed_Boost;
        _Estado.text = "Estilo de la serpiente seleccionado";
    }
    public void SeleccionaShield()
    {
        _powerups = PowerUps.Shield;
        _Estado.text = "Estilo del águila seleccionado";
    }

    public void SelecionaDamage()
    {
        _powerups = PowerUps.Damage;
        _Estado.text = "Preparáte para sufrir";
    }

    public void Aplicar()
    
    {
        float.TryParse(_InputA.text, out float a);

        if(!float.TryParse(_InputA.text,out a))
        {
            _Estado.text = "Escribe sólo números";
            return;
        }

        switch (_powerups)
        {
            case PowerUps.Heal:
            stats._CaminodelaGrulla(a);
            _Estado.text= "Sientes la calma de la grulla y obtienes " + stats._Vida;
            if (stats._Vida >= 10)
                {
                    _Estado.text= "Tu alma está equilibrada";
                }
             if (stats._Vida <= 0)
                {
                    _Estado.text= "Eres incapaz de recolectar tus pensamientos";
                    return;
                }
            break;

            case PowerUps.Speed_Boost:

            stats._CaminodelaSerpiente(a);
            _Estado.text= "Sientes la agilidad de la serpiente y obtienes " + stats._Speed;
            if (stats._Speed >= 1000.0f)
                {
                    _Estado.text= "Te sientes más ligero que nunca";
                
                }
             if (stats._Speed <= 0)
                {
                    _Estado.text= "Tus puños están más pesados que antes";
                    return;
                }
            break;

            case PowerUps.Shield:
            stats._CaminodelAguila(a);
            _Estado.text= "Ves todas las debilidades de tu enemigo, no puede hacerte daño";
            if (stats._Shield == 1)
                {
                    _Estado.text= "Nada te tocará";
                    return;
                }

            if (stats._Shield == 2)
                {
                    _Estado.text= "Estás indefenso";
                    return;
                }

            if (stats._Shield == 3)
                {
                    _Estado.text= "Utiliza 1 o 0 para activar o desactivar el escudo";
                    return;
                }
            break;

            case PowerUps.Damage:
            stats._takeDamage(a);
            _Estado.text= "Te golpean";
            if (stats._Shield == 1)
                {
                    _Estado.text= "Esquivas con éxito los ataques";
                    return;
                }

            if (stats._Shield == 2)
                {
                    _Estado.text= "Recibes " + stats._Vida + " de daño";
                }

             if (stats._Vida <= 0)
                {
                    _Estado.text= "No puedes seguir luchando";
                }

                break;









        




        }

 


    }





    void Update()
    {
        
    }
}
