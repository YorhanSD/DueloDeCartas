using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IA_Oponente : MonoBehaviour
{
    SistemaCombate sistemaCombate;

    public List<CartaDaCena> deckOponente = new List<CartaDaCena>();

    [SerializeField] Deck deck;

    Baralho baralho;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlaTurnos controlaTurnos;

    [SerializeField] private int guardaIDCartaComMaiorAtaque;

    [SerializeField] private int guardaIDCartaComMenorAtaque;

    public bool iaPodeAtacar = false;

    public void Start()
    {
        sistemaCombate = GetComponent<SistemaCombate>();
        deck = GetComponent<Deck>();
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        controlaTurnos = GetComponent<ControlaTurnos>();
        baralho = GetComponent<Baralho>();
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
            StartCoroutine(EsperaAsCartasDoOponenteAparecerem());
        }
    }
    public IEnumerator EsperaAsCartasDoOponenteAparecerem()
    {
        yield return new WaitForSeconds(1f);

        ChecaCardsAtivosDoPlayer();

        foreach (CartaDaCena carta in deckOponente)
        {
            if (carta != null)
            {
                ia_MapeamentoDeCases.VerificaPosicaoAtualDaCarta(carta);

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    //CHECA TODAS AS CARTAS ATIVAS DO JOGADOR
    public void ChecaCardsAtivosDoPlayer()
    {
        foreach (CartaDaCena cartaCena in sistemaCombate.listaCenaCartas)
        {
            if (cartaCena.GetEstaAtivada() == true)
            {
                Debug.Log("Cards ativos do jogador: " + cartaCena.dados.nomeAtual);

                //VerificaCardPlayerComMenorAtaque(cartaCena);
                VerificaSeHaCartaJogadorComMenosAtaque(cartaCena);
            }
        }
        
        
        
    }

    public void VerificaSeHaCartaJogadorComMenosAtaque(CartaDaCena _cartaAtiva)
    {
        foreach (CartaDaCena cartaCena in sistemaCombate.listaCenaCartas)
        {
            if (cartaCena.GetEstaAtivada() == true && cartaCena.dados.ataqueAtual < _cartaAtiva.dados.ataqueAtual && _cartaAtiva.GetEstaAtivada() == true)
            {
                    SetCartaIDComMenosAtaque(cartaCena.dados.ID);

                VerificaCardOponenteComMaiorAtaque(cartaCena);

                    Debug.Log("Card com menor ataque entre todas as cartas do jogador : " + cartaCena.dados.nomeAtual);
            }
            else
            {
                if (_cartaAtiva != null)
                {
                    SetCartaIDComMenosAtaque(_cartaAtiva.dados.ID);

                    VerificaCardOponenteComMaiorAtaque(_cartaAtiva);
                }
            }
        }

        
        
        
    }

    public void VerificaCardOponenteComMaiorAtaque(CartaDaCena _cardHekaib)
    {
        foreach (CartaDaCena _cardHekaibMaiorAtaque in deckOponente)
        {
            if (_cardHekaibMaiorAtaque.dados.ataqueAtual > _cardHekaib.dados.ataqueAtual)
            {
                if (_cardHekaibMaiorAtaque != null)
                {
                    SetCartaIDComMaiorAtaque(_cardHekaibMaiorAtaque.dados.ID);

                    Debug.Log("Card com maior ataque entre todas as cartas do oponente : " + _cardHekaibMaiorAtaque.dados.nomeAtual);
                }

            }
        }
    }

    public void Ataque()
    {
        foreach (CartaDaCena cardSalvoA in deckOponente)
        {
            if (cardSalvoA.dados.ID == GetCartaIDComMaiorAtaque())
            {
                foreach (CartaDaCena cardSalvoB in sistemaCombate.listaCenaCartas)
                {
                    if (cardSalvoB.dados.ID == GetCartaIDComMenosAtaque() && cardSalvoB.GetEstaAtivada() == true)
                    {
                        Debug.Log("Chama o método mover carta");

                        MoveCardOponente(cardSalvoA, cardSalvoB);
                    }
                }
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

                    _cardOponenteComMaiorAtaque.gameObject.transform.parent = casa.gameObject.transform;
                    _cardOponenteComMaiorAtaque.gameObject.transform.position = casa.gameObject.transform.position;

                }
            }
        }
    }
}

