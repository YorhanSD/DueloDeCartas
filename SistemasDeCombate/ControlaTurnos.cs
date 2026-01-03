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
    Deck deck;
    Baralho baralho;
    Baralho_Oponente bO;
    BancoCards bancoCartas;

    public bool turnoOponente;

    AtivaCartaOponente ativaCarta;

    Mapeamento_Jogador mapeamentoJogador;

    public GameObject telaTurnoPlayer;
    public GameObject telaturnoOponente;
    public GameObject botaoPassaTurno;

    public int numeroTurno;
    public TextMeshProUGUI textoTurno;
    
    public void Start()
    {
        numeroTurno = 1;

        //Para usar o GetComponent o Script deve estar no mesmo Objeto

        bancoCartas = GetComponent<BancoCards>();
        deck = GetComponent<Deck>();
        sistemaDeCombate = GetComponent<SistemaCombate>();
        ativaCarta = GetComponent<AtivaCartaOponente>();
        iaOponente = GetComponent<IA_Oponente>();
        cronometro = GetComponent<Cronometro>();
        mapeamentoJogador = GetComponent<Mapeamento_Jogador>();
        baralho = GetComponent<Baralho>();
        bO = GetComponent<Baralho_Oponente>();
        
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

        yield return new WaitForSeconds(1.5f);

        cronometro.tempoOponente = 120;

        cronometro.StartCoroutine(cronometro.TemporizadorOponente());

        telaturnoOponente.SetActive(false);

        numeroTurno ++;
        if (numeroTurno > 3)
        {
            ProximaCartaOponente();
        }

        Cursor.visible = false;

        StartCoroutine(ativaCarta.SpawnaCartas());

        yield return new WaitForSeconds(1f);

        iaOponente.ControleDeAcoes();

        yield return new WaitForSeconds(5f);

        //mapeamentoJogador.VerificaPossicaoAtualDaCartaDoJogador();

        turnoOponente = false;

        TelaTurnoJogador(true);

        sistemaDeCombate.travarJogador = false;

        botaoPassaTurno.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        TelaTurnoJogador(false);

        Cursor.visible = true;

        cronometro.tempoJogador = 120;

        ProximaCartaJogador();

        numeroTurno++;
    }
    public void ProximaCartaJogador()
    {
        baralho.ProximaCartaAleatoria();
    }
    public void ProximaCartaOponente()
    {
        bO.ProximaCartaAleatoriaOponente();
    }
    public void ResetaMovimentoDasCartas()
    {
        foreach(CartaDaCena cartaCena in bancoCartas.geralCartaCenaLista)
        {
            if (cartaCena != null) 
            {
                cartaCena.SetMoveuSe(false);
                cartaCena.SetPodeAtacar(true);
            }
        }

      
    }
    public void TelaTurnoJogador(bool _comando)
    {
        telaTurnoPlayer.SetActive(_comando);
    }
   
}
