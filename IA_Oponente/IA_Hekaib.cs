using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IA_Hekaib : MonoBehaviour
{
    public List<Card> HekaibDeck = new List<Card>();

    Deck deck;

    MapeamentoPlayerCase mapeamentoPlayerCase;

    ControlaTurnos controlaTurnos;

    int guardaIDCartaOponente;
    string guardaCartaComMaisAtaque;
    string guardaCartaComMenorAtaqueDoJogador;

    public void Start()
    {
        deck = FindObjectOfType<Deck>();
        mapeamentoPlayerCase = FindObjectOfType<MapeamentoPlayerCase>();
        controlaTurnos = FindObjectOfType<ControlaTurnos>();
    }
    public void SetIDCartaOponente(int _ID)
    {
        guardaIDCartaOponente = _ID;
    }
    public void SetCartaComMenosAtaqueDoJogador(string _cardNome)
    {
        guardaCartaComMenorAtaqueDoJogador = _cardNome;
    }
    public void SetCartaComMaiorAtaque(string _cardNome)
    {
        guardaCartaComMaisAtaque = _cardNome;
    }
    public int GetIDCartaOponente()
    {
        return guardaIDCartaOponente;
    }
    public string GetCartaComMenosAtaqueDoJogador()
    {
        return guardaCartaComMenorAtaqueDoJogador;
    }
    public string GetCartaComMaiorAtaque()
    {
        return guardaCartaComMaisAtaque;
    }
    public void ControleDeAcoes()
    {
        if (controlaTurnos == true)
        {
            ChecaCardsAtivosDoPlayer();
        }
    }
    public void ChecaCardsAtivosDoPlayer()
    {
        foreach (Card cardAtivo in deck.geralCardList)
        {
            if (cardAtivo.cardAtivo == true)
            {
                Debug.Log("Cards Ativos do Jogador: " + cardAtivo.nome);

                VerificaCardPlayerComMenorAtaque(cardAtivo);
            }
        }
    }
    public void VerificaCardPlayerComMenorAtaque(Card _cardAtivo)
    {
        foreach (Card card in deck.geralCardList)
        {
            if (card.ataque < _cardAtivo.ataque && card.cardAtivo == true)
            {
                Debug.Log("Card com Menor Ataque do Jogador: " + card.nome);

                SetCartaComMenosAtaqueDoJogador(card.nome);

                VerificaSeHaCartaOponenteComMaisAtaque(card);

                Ataque();

                break;
            }
            else
            {
                //Debug.Log("Único Card Ativo do Jogador é : " + _cardAtivo.nome);

                SetCartaComMenosAtaqueDoJogador(_cardAtivo.nome);

                VerificaSeHaCartaOponenteComMaisAtaque(card);

                Ataque();

                break;
            }
        }
    }
    public void VerificaSeHaCartaOponenteComMaisAtaque(Card _cardMenorAtaque)
    {
        foreach (Card _cardHekaib in HekaibDeck)
        {
            if (_cardHekaib.ataque > _cardMenorAtaque.ataque)
            {
                VerificaCardOponenteComMaiorAtaque(_cardHekaib);
            }
            else
            {
                break;
            }
        }
    }
    public void VerificaCardOponenteComMaiorAtaque(Card _cardHekaib)
    {
        foreach (Card _cardHekaibMaiorAtaque in HekaibDeck)
        {
            if (_cardHekaibMaiorAtaque.ataque > _cardHekaib.ataque)
            {
                SetCartaComMaiorAtaque(_cardHekaibMaiorAtaque.nome);

                Ataque();

                Debug.Log("Card do Oponente com Mais Ataque : " + GetCartaComMaiorAtaque());
            }

            break;
        }
    }
    public void Ataque()
    {
        foreach (Card cardSalvoA in HekaibDeck)
        {
            if (cardSalvoA.nome == GetCartaComMaiorAtaque())
            {
                foreach (Card cardSalvoB in deck.geralCardList)
                {
                    if (cardSalvoB.nome == GetCartaComMenosAtaqueDoJogador() && cardSalvoB.cardAtivo == true)
                    {
                        MoveCardOponenteAteOCase(cardSalvoA, cardSalvoB);
                    }
                }
            }
        }
    }
    public void MoveCardOponenteAteOCase(Card _cardOponenteComMaiorAtaque, Card _cardPlayerComMenorAtaque)
    {
        foreach (Case casa in mapeamentoPlayerCase.listaCase)
        {
            if (casa.GetCaseOcupado() == true && casa.GetGuardaCartaNome() == _cardPlayerComMenorAtaque.nome)
            {
                if(_cardPlayerComMenorAtaque.vida <= 0)
                {
                    foreach (Card card in deck.geralCardList)
                    {
                        if(card.vida > 0 && card.cardAtivo == true)
                        {
                            SetCartaComMenosAtaqueDoJogador(card.nome);
                        }
                    }
                }

                if (_cardOponenteComMaiorAtaque.vida <= 0)
                {
                    foreach (Card card in HekaibDeck)
                    {
                        if (card.ataque > _cardPlayerComMenorAtaque.ataque)
                        {
                            SetCartaComMaiorAtaque(card.nome);
                        }
                    }
                }

                if(_cardOponenteComMaiorAtaque.ataque <= _cardPlayerComMenorAtaque.ataque)
                {
                    foreach (Card card in deck.geralCardList)
                    {
                        if (card.ataque < _cardOponenteComMaiorAtaque.ataque && card.cardAtivo == true)
                        {
                            SetCartaComMenosAtaqueDoJogador(card.nome);
                        }
                    }
                }

                if (_cardOponenteComMaiorAtaque.ataque <= _cardPlayerComMenorAtaque.ataque)
                {
                    foreach (Card card in HekaibDeck)
                    {
                        if (card.ataque > _cardPlayerComMenorAtaque.ataque)
                        {
                            SetCartaComMaiorAtaque(card.nome);
                        }
                    }
                }

                if (_cardOponenteComMaiorAtaque.vida > 0 && _cardOponenteComMaiorAtaque.ataque > _cardPlayerComMenorAtaque.ataque)
                {
                    _cardOponenteComMaiorAtaque.transform.parent = casa.transform;
                    _cardOponenteComMaiorAtaque.transform.position = casa.transform.position;
                }
            }
        }
    }
}
