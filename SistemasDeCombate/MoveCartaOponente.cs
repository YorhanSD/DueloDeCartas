using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCartaOponente : MonoBehaviour
{

    public Deck deck;

    public ControlaTurnos controlaTurnos;

    public void Start()
    {
        //deck = FindObjectOfType<Deck>();

        //controlaTurnos = FindObjectOfType<ControlaTurnos>();
    }

    public void ChecaPosicaoCarta(int _cardPlayerID, int _cardOponenteID)
    {
        Debug.Log("Carta do Oponente : " + _cardOponenteID);

        //Debug.Log("Carta Ativa : " + deck.cardList[_cardOponenteID].nome);









        if (controlaTurnos.turnoOponente == true)
        {
            //deck.geralCardList[_cardOponenteID].transform.position = new Vector3(deck.geralCardList[_cardPlayerID].transform.position.x + Time.deltaTime * 0.1f ,0,0);
        }
    }
}
