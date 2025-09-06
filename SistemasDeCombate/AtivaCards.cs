using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaCards : MonoBehaviour
{
    CardsPlayerAtivos cardsPlayerAtivos;
    CardsOponentesAtivos cardsOponentesAtivos;

    public void Start()
    {
        cardsPlayerAtivos = GetComponent<CardsPlayerAtivos>();
        cardsOponentesAtivos = GetComponent<CardsOponentesAtivos>();
    }

    private void OnTriggerEnter2D(Collider2D _cardPlayer)
    {
        if(_cardPlayer.gameObject.tag == "Card Player")
        {
            cardsPlayerAtivos.ChecaCardPlayerAtivo(_cardPlayer.name);
        }

        //if(gameObject.tag == "Card Oponente")
        //{
            //cardsOponentesAtivos.ChecaCardOponenteAtivo(gameObject.name);
        //}
    }
}
