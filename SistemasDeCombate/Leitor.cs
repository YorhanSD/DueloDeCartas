using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Leitor : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private SistemaCombate sC;

    public void Start()
    {
        deck = FindObjectOfType<Deck>();
        sC = FindObjectOfType<SistemaCombate>(); 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != null && this.gameObject.tag == "Card Oponente")
        {
            foreach (Card card in deck.geralCardList)
            {
                if (card.nome == collision.gameObject.name && collision.gameObject.tag == "Card Player")
                {
                    //Debug.Log("Carta de Ataque: " + gameObject.name + " Carta de Defesa: " + card.nome);

                    sC.UmContraUm(this.gameObject.name, card.nome);
                }
            }
        }
        
        if (collision.gameObject.tag != null && this.gameObject.tag == "Card Player")
        {
            foreach (Card card in deck.geralCardList)
            {
                if (card.nome == collision.gameObject.name && collision.gameObject.tag == "Card Oponente")
                {
                    //Debug.Log("Carta de Ataque: " + gameObject.name + " Carta de Defesa: " + card.nome);

                    sC.UmContraUm(this.gameObject.name, card.nome);
                }
            }
        }
    }
}
