using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Leitor : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private SistemaCombate sC;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != null)
        {
            //Debug.Log("Detectou");

            foreach (Card card1 in deck.geralCardList)
            {
                if (card1.nome == collision.gameObject.name)
                {
                    //Debug.Log($"{card1.nome}");
                    //Debug.Log($"{gameObject.name}");

                    sC.UmContraUm(gameObject.name, card1.nome);
                }
            }
        }
    }
}
