using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlaTurnos : MonoBehaviour
{
    IA_Oponente iaOponente;
    SistemaCombate sistemaDeCombate;
    Cronometro cronometro;

    Baralho baralhoJogador;
    Baralho_Oponente baralhoOponente;

    //BancoCards bancoCartas;

    public bool turnoOponente;
    Trava_Casas travaCasas;
    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    Mapeamento_Jogador mapeamentoJogador;

    public GameObject telaTurnoPlayer;
    public GameObject telaturnoOponente;
    public GameObject botaoPassaTurno;

    public int numeroTurno;
    public TextMeshProUGUI textoTurno;

    [System.Obsolete]
    public void Start()
    {
        numeroTurno = 1;

        //Para usar o GetComponent o Script deve estar no mesmo Objeto

        //bancoCartas = GetComponent<BancoCards>();

        sistemaDeCombate = GetComponent<SistemaCombate>();
        travaCasas = GetComponent<Trava_Casas>();
        iaOponente = GetComponent<IA_Oponente>();
        cronometro = GetComponent<Cronometro>();
        mapeamentoJogador = GetComponent<Mapeamento_Jogador>();
        baralhoJogador = GetComponent<Baralho>();
        baralhoOponente = GetComponent<Baralho_Oponente>();
        StartCoroutine(GeraCartasDoJogador());
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        
    }

    public void Update()
    {
        textoTurno.text = numeroTurno.ToString();
    }
    public void BotaoPassaOTurno()
    {
        telaturnoOponente.SetActive(true);

        botaoPassaTurno.SetActive(false);

        StartCoroutine(TurnoOponente());

        sistemaDeCombate.travarJogador = true;
    }

    public IEnumerator TurnoOponente()
    {
        turnoOponente = true;

        ResetaMovimentoDasCartas();

        ResetaUltimoIDCasas();

        travaCasas.ResetaCasas();

        yield return new WaitForSeconds(1.5f);

        cronometro.tempoOponente = 120;

        cronometro.ParaCronometro_Jogador();
        cronometro.IniciaCronometro_Oponente();

        telaturnoOponente.SetActive(false);

        numeroTurno ++;

        if(numeroTurno == 2)
        {
            StartCoroutine(GeraCartasDoOponente());
        }

        if (numeroTurno > 3)
        {
            ProximaCartaOponente();
        }

        Cursor.visible = false;

        yield return new WaitForSeconds(1f);

        iaOponente.ControleDeAcoes();

        yield return new WaitForSeconds(5f);

        turnoOponente = false;

        TelaTurnoJogador(true);

        sistemaDeCombate.travarJogador = false;

        botaoPassaTurno.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        TelaTurnoJogador(false);

        Cursor.visible = true;

        cronometro.tempoJogador = 120;

        cronometro.ParaCronometro_Oponente();
        cronometro.IniciaCronometro_Jogador();

        ProximaCartaJogador();

        numeroTurno++;

        baralhoOponente.casaReferenciaDeMenorPosicao = 10;
    }
    public void ProximaCartaJogador()
    {
        baralhoJogador.ProximaCartaAleatoria();
    }
    public void ProximaCartaOponente()
    {
        baralhoOponente.ProximaCartaAleatoriaOponente();
    }
    public IEnumerator GeraCartasDoJogador()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            baralhoJogador.ProximaCartaAleatoria();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator GeraCartasDoOponente()
    {
        for (int i = 0; i < 3; i++)
        {
            baralhoOponente.ProximaCartaAleatoriaOponente();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void ResetaMovimentoDasCartas()
    {
        foreach(CartaDaCena cartaCena in baralhoOponente.deckOponente)
        {
            if (cartaCena != null) 
            {
                cartaCena.SetMoveuSe(false);
                cartaCena.SetPodeAtacar(true);
            }
        }

        foreach (CartaDaCena cartaCena in baralhoJogador.deckJogador)
        {
            if (cartaCena != null)
            {
                cartaCena.SetMoveuSe(false);
                cartaCena.SetPodeAtacar(true);
            }
        }
    }

    public void ResetaUltimoIDCasas()
    {
        foreach (Case casaB in ia_MapeamentoDeCases.listaCase)
        {
            if (casaB.GetUltimoID() != -1)
            {
                casaB.SetUltimoID(-1);
            }
        }
    }
    public void TelaTurnoJogador(bool _comando)
    {
        telaTurnoPlayer.SetActive(_comando);
    }
   
}
