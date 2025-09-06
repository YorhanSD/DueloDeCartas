using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsOponentesAtivos : MonoBehaviour
{
    Deck deck;
    public void Start()
    {
        deck = GetComponent<Deck>();
    }
    public void ChecaCardOponenteAtivo(string _cardNome)
    {
        foreach (Card cardOponente in deck.geralCardList)
        {
            if (cardOponente.nome == _cardNome)
            {
                //cardOponente.cardAtivo = true;
            }
        }
    }
}
