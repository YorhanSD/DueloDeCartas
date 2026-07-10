using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IA_Oponente : MonoBehaviour
{
    //BancoCards bancoCartas;

    Baralho baralhoJogador;

    Baralho_Oponente baralhoOponente;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlaTurnos controlaTurnos;

    [SerializeField] private int guardaIDCartaComMaiorAtaque;

    [SerializeField] private int guardaIDCartaComMenorAtaque;

    [SerializeField] private int guardaIDCartaComMenorCouraca;

    [SerializeField] private int guardaIDCartaComMaiorCouraca;

    public bool iaPodeAtacar = false;

    [System.Obsolete]
    public void Start()
    {
        //bancoCartas = GetComponent<BancoCards>();
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        controlaTurnos = GetComponent<ControlaTurnos>();
        baralhoOponente = GetComponent<Baralho_Oponente>();
        baralhoJogador = GetComponent<Baralho>();
    }
    public void SetCartaIDComMenorCouraca(int _cartaID)
    {
        guardaIDCartaComMenorCouraca = _cartaID;
    }
    public void SetCartaIDComMaiorCouraca(int _cartaID)
    {
        guardaIDCartaComMaiorCouraca = _cartaID;
    }
    public int GetCartaIDComMaiorCouraca()
    {
        return guardaIDCartaComMaiorCouraca;
    }
    public int GetCartaIDComMenorCouraca()
    {
        return guardaIDCartaComMenorCouraca;
    }
    public void SetCartaIDComMenosAtaque(int _cartaID)
    {
        guardaIDCartaComMenorAtaque = _cartaID;
    }
    public void SetCartaIDComMaiorAtaque(int _cartaID)
    {
        guardaIDCartaComMaiorAtaque = _cartaID;
    }
    public int GetCartaIDComMenosAtaque()
    {
        return guardaIDCartaComMenorAtaque;
    }
    public int GetCartaIDComMaiorAtaque()
    {
        return guardaIDCartaComMaiorAtaque;
    }

    public void ControleDeAcoes()
    {
        if (controlaTurnos == true)
        {
            //JOGO SÓ FUNCIONA SE AS CARTAS DO OPONENTE ESTIVEREM OCULTAS EM CENA
            //CASO CONTRÁRIO, MUITOS BUGS SURGIRÃO!

            StartCoroutine(EsperaAsCartasDoOponenteAparecerem());
        }
    }
    public IEnumerator EsperaAsCartasDoOponenteAparecerem()
    {
        //Tempo mínimo de espera: 1.5 s.
        yield return new WaitForSeconds(2f);

        ChecaCardsAtivosDoPlayer();
    }

    //CHECA TODAS AS CARTAS ATIVAS DO JOGADOR
    public void ChecaCardsAtivosDoPlayer()
    {
        foreach (CartaDaCena cartaAtiva in baralhoJogador.deckJogador)
        {
            if (cartaAtiva.GetEstaAtivada() == true)
            {
                VerificaCartaDoJogador(cartaAtiva);
            }
            else
            {
                VerificaMovimento();

                Debug.Log("Jogador não possui cartas ativas");
            }
        }
    }

    public void VerificaCartaDoJogador(CartaDaCena _cartaAtiva)
    {
        //SetCartaIDComMenosAtaque(_cartaAtiva.dados.ID);
        SetCartaIDComMenorCouraca(_cartaAtiva.dados.ID);

        VerificaAtaque(_cartaAtiva);

        //Debug.Log("Card com menor ataque entre todas as cartas do jogador : " + _cartaAtiva.dados.nomeAtual);
    }

    public void VerificaAtaque(CartaDaCena _cartaJogador)
    {
        CartaDaCena cartaOponente = baralhoOponente.deckOponente.Find(c => c != null);

        if (cartaOponente.dados.ataqueAtual > 0 && cartaOponente.GetPodeAtacar() == true) //Se o ataque não for 0, pode atacar
        {
            SetCartaIDComMaiorAtaque(cartaOponente.dados.ID);

            //Debug.Log($"Carta {cartaOponente} tem mais ataque que {_cartaJogador}");
        }
        else
        {
            SetCartaIDComMaiorAtaque(cartaOponente.dados.ID);

            //Debug.Log($"{cartaOponente} não tem ataque maior que {_cartaJogador}");
        }


        ia_MapeamentoDeCases.VerificaPosicaoAtualDaCarta(GetCartaIDComMaiorAtaque());

        StartCoroutine(VerificaMovimento());
    }

    public IEnumerator VerificaMovimento()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (CartaDaCena _cartaApta in baralhoOponente.deckOponente)
        {
            if (_cartaApta.GetMoveuSe() == false && _cartaApta.GetPodeAtacar() == true)
            {
                ia_MapeamentoDeCases.VerificaPosicaoAtualDaCarta(_cartaApta.dados.ID);
            }
            else
            {
                //Debug.Log(_cartaApta.dados.nomeAtual + " ja atacou");

                break;
            }
        }
    }

    public void Ataque()
    {

        CartaDaCena cartaOponente = baralhoOponente.deckOponente.Find(c => c.dados.ID == GetCartaIDComMaiorAtaque());
        CartaDaCena cartaJogador = baralhoJogador.deckJogador.Find(c => c.dados.ID == GetCartaIDComMenorCouraca());

        Case _casaOponente = ia_MapeamentoDeCases.listaCase.Find(c => c.GetIDCartaOcupante() == GetCartaIDComMaiorAtaque());
        Case _casaJogador = ia_MapeamentoDeCases.listaCase.Find(c => c.GetIDCartaOcupante() == GetCartaIDComMenorCouraca());

        if (_casaJogador != null && _casaOponente != null)
        {
            //REGRA DAS CASAS:

            //UMA CARTA EM UMA CASA PAR, SÓ SE MOVE PARA OUTRA CASA PAR.
            //UMA CARTA EM UMA CASA IMPAR, SÓ SE MOVE PARA OUTRA CASA IMPAR.

            Debug.Log($"Número da casa do jogador {_casaJogador.GetPosicaoCasa()}");
            Debug.Log($"Número da casa do oponente {_casaOponente.GetPosicaoCasa()}");

            if (_casaJogador.GetPosicaoCasa() % 2 == 0 && _casaOponente.GetPosicaoCasa() % 2 == 0 || _casaJogador.GetPosicaoCasa() % 2 != 0 && _casaOponente.GetPosicaoCasa() % 2 != 0)
            {
                MoveCardOponente(cartaOponente, cartaJogador, _casaJogador);
            }
        }
    }

    public void MoveCardOponente(CartaDaCena _cardOponenteComMaiorAtaque, CartaDaCena _cardPlayerComMenorAtaque, Case casa)
    {
        _cardOponenteComMaiorAtaque.SetMoveuSe(true);
        _cardOponenteComMaiorAtaque.SetPodeAtacar(false);

        if (_cardOponenteComMaiorAtaque != null && _cardPlayerComMenorAtaque != null)
        {
            //Debug.Log($"Card do oponente com maior ataque: {_cardOponenteComMaiorAtaque.gameObject.name} Card do jogador com menor ataque: {_cardPlayerComMenorAtaque.dados.nomeAtual}");

            _cardOponenteComMaiorAtaque.transform.SetParent(casa.gameObject.transform, false);
            _cardOponenteComMaiorAtaque.transform.localPosition = Vector3.zero;

            //casa.OcuparCasa(_cardOponenteComMaiorAtaque);
        }
    }
}

