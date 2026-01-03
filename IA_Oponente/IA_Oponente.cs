using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IA_Oponente : MonoBehaviour
{
    BancoCards bancoCartas;
    SistemaCombate sistemaCombate;
    //Case casa;

    public List<CartaDaCena> deckOponente = new List<CartaDaCena>();

    [SerializeField] Deck deck;

    Baralho baralho;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlaTurnos controlaTurnos;

    [SerializeField] private int guardaIDCartaComMaiorAtaque;

    [SerializeField] private int guardaIDCartaComMenorAtaque;

    public bool iaPodeAtacar = false;

    [System.Obsolete]
    public void Start()
    {
        bancoCartas = GetComponent<BancoCards>();
        sistemaCombate = GetComponent<SistemaCombate>();
        deck = GetComponent<Deck>();
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        controlaTurnos = GetComponent<ControlaTurnos>();
        baralho = GetComponent<Baralho>();
        //casa = FindObjectOfType<Case>();
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
            //CASO CONTRARIO, MUITOS BUGS SURGIRÃO!
            StartCoroutine(EsperaAsCartasDoOponenteAparecerem());
        }
    }
    public IEnumerator EsperaAsCartasDoOponenteAparecerem()
    {
        yield return new WaitForSeconds(0.5f);

        ChecaCardsAtivosDoPlayer();

    }

    //CHECA TODAS AS CARTAS ATIVAS DO JOGADOR
    public void ChecaCardsAtivosDoPlayer()
    {
        foreach (CartaDaCena cartaCena in bancoCartas.geralCartaCenaLista)
        {
            if (cartaCena != null)
            {
                if (cartaCena.GetEstaAtivada() == true)
                {
                    Debug.Log("Cards ativos do jogador: " + cartaCena.dados.nomeAtual);

                    VerificaCartaDoJogadorComMenosAtaque(cartaCena);
                }
                else
                {
                    //FUNCIONA PERFEITAMENTE
                    Debug.Log("Jogador não tem cartas ativas");
                    StartCoroutine(VerificaMovimento());
                }
            }
        }
    }

    public void VerificaCartaDoJogadorComMenosAtaque(CartaDaCena _cartaAtiva)
    {
        foreach (CartaDaCena cartaMenorAtaque in bancoCartas.geralCartaCenaLista)
        {
            if (cartaMenorAtaque.GetEstaAtivada() == true && cartaMenorAtaque.dados.ataqueAtual < _cartaAtiva.dados.ataqueAtual && _cartaAtiva.GetEstaAtivada() == true)
            {
                SetCartaIDComMenosAtaque(cartaMenorAtaque.dados.ID);

                VerificaAtaque(cartaMenorAtaque);

                Debug.Log("Card com menor ataque entre todas as cartas do jogador : " + cartaMenorAtaque.dados.nomeAtual);
            }
            else
            {
                SetCartaIDComMenosAtaque(_cartaAtiva.dados.ID);

                VerificaAtaque(_cartaAtiva);

                Debug.Log("Só existe uma carta do jogador: " + _cartaAtiva.dados.nomeAtual);

            }
        }

    }

    public void VerificaAtaque(CartaDaCena _cartaJogador)
    {
        foreach (CartaDaCena _cartaOponenteComMaiorAtaque in deckOponente)
        {
            if (_cartaOponenteComMaiorAtaque.dados.ataqueAtual > _cartaJogador.dados.ataqueAtual)
            {
                SetCartaIDComMaiorAtaque(_cartaOponenteComMaiorAtaque.dados.ID);

                Debug.Log($"Carta {_cartaOponenteComMaiorAtaque} tem mais ataque que {_cartaJogador}");
            }
            else
            {
                SetCartaIDComMaiorAtaque(_cartaOponenteComMaiorAtaque.dados.ID);

                Debug.Log($"{_cartaOponenteComMaiorAtaque} não tem ataque maior que {_cartaJogador}");
            }
        }

        ia_MapeamentoDeCases.VerificaPosicaoAtualDaCarta(GetCartaIDComMaiorAtaque());
        StartCoroutine(VerificaMovimento());
    }

    public IEnumerator VerificaMovimento()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (CartaDaCena _cartaApta in deckOponente)
        {
            if (_cartaApta.GetMoveuSe() == false)
            {
                ia_MapeamentoDeCases.VerificaPosicaoAtualDaCarta(_cartaApta.dados.ID);
            }
            else
            {
                Debug.Log("Oponente só tem uma carta e ela atacou");
            }
        }
    }

    public void Ataque()
    {
        CartaDaCena cartaOponente = deckOponente.Find(c => c.dados.ID == GetCartaIDComMaiorAtaque());
        CartaDaCena cartaJogador = bancoCartas.geralCartaCenaLista.Find(c => c.dados.ID == GetCartaIDComMenosAtaque());

        Case _casaOponente = ia_MapeamentoDeCases.listaCase.Find(c => c.GetIDCartaOcupante() == GetCartaIDComMaiorAtaque());
        Case _casaJogador = ia_MapeamentoDeCases.listaCase.Find(c => c.GetIDCartaOcupante() == GetCartaIDComMenosAtaque());

        if (_casaJogador != null && _casaOponente != null)
        {
            Debug.Log($"Número da casa do jogador {_casaJogador.GetPosicaoCasa()}");
            Debug.Log($"Número da casa do oponente {_casaOponente.GetPosicaoCasa()}");

            //REGRA DAS CASAS, UMA CARTA EM UMA CASA PAR SÓ SE MOVE PARA OUTRA CASA PAR
            //UMA CARTA EM UMA CASA IMPAR, SÓ SE MOVE PARA OUTRA CASA IMPAR
            if (_casaJogador.GetPosicaoCasa() % 2 == 0 && _casaOponente.GetPosicaoCasa() % 2 == 0 || _casaJogador.GetPosicaoCasa() % 2 != 0 && _casaOponente.GetPosicaoCasa() % 2 != 0)
            {
                MoveCardOponente(cartaOponente, cartaJogador);
            }
        }
    }

    public void MoveCardOponente(CartaDaCena _cardOponenteComMaiorAtaque, CartaDaCena _cardPlayerComMenorAtaque)
    {
        foreach (Case casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetNomeCartaJogador() == _cardPlayerComMenorAtaque.dados.nomeAtual && _cardOponenteComMaiorAtaque.GetPodeAtacar() == true && _cardOponenteComMaiorAtaque.GetMoveuSe() == false)
            {
                _cardOponenteComMaiorAtaque.SetPodeAtacar(false);
                _cardOponenteComMaiorAtaque.SetMoveuSe(true);

                if (_cardOponenteComMaiorAtaque != null && _cardPlayerComMenorAtaque != null)
                {

                    Debug.Log($"Card do oponente com maior ataque: {_cardOponenteComMaiorAtaque.gameObject.name} Card do jogador com menor ataque: {_cardPlayerComMenorAtaque.dados.nomeAtual}");

                    //_cardOponenteComMaiorAtaque.gameObject.transform.parent = casa.gameObject.transform;
                    //_cardOponenteComMaiorAtaque.gameObject.transform.position = casa.gameObject.transform.position;
                    _cardOponenteComMaiorAtaque.transform.SetParent(casa.gameObject.transform, false);
                    _cardOponenteComMaiorAtaque.transform.localPosition = Vector3.zero;

                }
            }
        }
    }
}

