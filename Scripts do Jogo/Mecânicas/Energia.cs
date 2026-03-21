using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia : MonoBehaviour
{
    [SerializeField] private float energiaJogador = 100;

    public Slider barraEnergiaJogador;

    [SerializeField] private float energiaOponente = 100;

    public Slider barraEnergiaOponente;

    void Update()
    {
        if(energiaJogador > 100)
        {
            energiaJogador = 100;
        }

        if(energiaJogador < 0)
        {
            energiaJogador = 0;
        }

        if (energiaOponente > 100)
        {
            energiaOponente = 100;
        }

        if (energiaOponente < 0)
        {
            energiaOponente = 0;
        }

        barraEnergiaJogador.value = energiaJogador;
        barraEnergiaOponente.value = energiaOponente;
    }
    public void RetiraEnergiaJogador(float _energia)
    {
        energiaJogador -= _energia;
    }
    public void AdicionaEnergiaJogador(float _energia)
    {
        energiaJogador += _energia;
    }
    public void RetiraEnergiaOponente(float _energia)
    {
        energiaOponente -= _energia;
    }
    public void AdicionaEnergiaOponente(float _energia)
    {
        energiaOponente += _energia;
    }
    //public void SetEnergia(float _energia)
    //{
    //energia = _energia;
    //}
    //public float GetEnergia()
    //{
    //return energia;
    //}
}
