using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsPlayerAtivos : MonoBehaviour
{
    Deck deck;
    MapeamentoPlayerCase mapeamentoPlayerCase;

    public void Start()
    {
        deck = FindObjectOfType<Deck>();
        mapeamentoPlayerCase = FindObjectOfType<MapeamentoPlayerCase>();
    }
    public void ChecaCardPlayerAtivo(string _cardNome)
    {
        foreach(Card cardPlayer in deck.geralCardList)
        {
            if(cardPlayer.nome == _cardNome)
            {
                cardPlayer.cardAtivo = true;

                //mapeamentoPlayerCase.procuraCaseOcupado(cardPlayer.nome);
            }
        }
    }
}
