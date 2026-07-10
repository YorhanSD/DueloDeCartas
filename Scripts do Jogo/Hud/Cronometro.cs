using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public float tempoJogador;
    public TextMeshProUGUI tempoTextoJogador;
    public float tempoOponente;
    public TextMeshProUGUI tempoTextoOponente;

    private Coroutine cronometroJogador;
    private Coroutine cronometroOponente;

    void Start()
    {
        tempoJogador = 120;
        tempoOponente = 120;

        IniciaCronometro_Jogador();
    }

    void Update()
    {
        tempoTextoJogador.text = tempoJogador.ToString();
        tempoTextoOponente.text = tempoOponente.ToString();
        
    }

    public void IniciaCronometro_Jogador()
    {
        if (cronometroJogador == null)
        {
            cronometroJogador = StartCoroutine(TemporizadorJogador());
        }
    }
    public void ParaCronometro_Jogador()
    {
        if (cronometroJogador != null)
        {
            StopCoroutine(cronometroJogador);
            cronometroJogador = null;
        }
    }
    public void IniciaCronometro_Oponente()
    {
        if (cronometroOponente == null)
        {
            cronometroOponente = StartCoroutine(TemporizadorOponente());
        }
    }
    public void ParaCronometro_Oponente()
    {
        if (cronometroOponente != null)
        {
            StopCoroutine(cronometroOponente);
            cronometroOponente = null;
        }
    }

    public IEnumerator TemporizadorJogador()
    {
        while (tempoJogador > 0)
        {
            yield return new WaitForSeconds(1f);
            tempoJogador--;
        }
    }

    public IEnumerator TemporizadorOponente()
    {
        while (tempoOponente > 0)
        {
            yield return new WaitForSeconds(1f);
            tempoOponente--;
        }
    }
}
