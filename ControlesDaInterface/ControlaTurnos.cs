using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaTurnos : MonoBehaviour
{
    IA_Hekaib ia_Hekaib;

    public bool turnoOponente;

    AtivaCartaOponente ativaCarta;

    public GameObject telaTurnoPlayer;
    public GameObject telaturnoOponente;
    public GameObject deck;
    public GameObject botaoPassaTurno;

    public void Start()
    {
        //Para usar o GetComponent o Script deve estar no mesmo Objeto

        ativaCarta = GetComponent<AtivaCartaOponente>();
        ia_Hekaib = FindObjectOfType<IA_Hekaib>();
    }
    public void BotaoPassaOTurno()
    {
        telaturnoOponente.SetActive(true);
        deck.SetActive(false);
        botaoPassaTurno.SetActive(false);
        StartCoroutine(TurnoOponente());
    }

    public IEnumerator TurnoOponente()
    {
        turnoOponente = true;

        yield return new WaitForSeconds(2f);
        telaturnoOponente.SetActive(false);
        Cursor.visible = false;
        yield return new WaitForSeconds(1f);
        ativaCarta.SpawnaCartas();

        ia_Hekaib.ControleDeAcoes();

        yield return new WaitForSeconds(5f);

        turnoOponente = false;

        TelaTurnoJogador(true);
        deck.SetActive(true);
        botaoPassaTurno.SetActive(true);

        yield return new WaitForSeconds(1f);
        TelaTurnoJogador(false);
        Cursor.visible = true;
    }

    public void TelaTurnoJogador(bool _comando)
    {
        telaTurnoPlayer.SetActive(_comando);
    }
   
}
