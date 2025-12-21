using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativa_Desativa_Cards : MonoBehaviour
{
    [SerializeField] Deck deck;

    public void Start()
    {
        //deck = FindObjectOfType<Deck>();
    }
    private void OnTriggerEnter2D(Collider2D card)
    {
        if (card.gameObject.tag == "Card Player" || card.gameObject.tag == "Card Oponente")
        {
            //ResetaAtaque(card.name);
        }

        if (card.gameObject.tag == "Card Player")
        {
            //AtivaDesativaCardPlayer(card.gameObject.name);
        }
    }
    public void OnTriggerExit2D(Collider2D card)
    {
        if (card.gameObject.tag == "Card Player" || card.gameObject.tag == "Card Oponente")
        {
            //ResetaAtaque(card.name);
        }

        if (card.gameObject.tag == "Card Player")
        {
            //AtivaDesativaCardPlayer(card.gameObject.name);
        }
    }
    public void ResetaAtaque(string _cardNome)
    {
        foreach (Card card in deck.geralCardList)
        {
            if (card.nome == _cardNome)
            {
                //card.podeAtacar = !card.podeAtacar;
            }
        }
    }
    public void AtivaDesativaCardPlayer(string _cardNome)
    {
        foreach (Card carta in deck.geralCardList)
        {
            if (carta.nome == _cardNome || carta.nome + "(Cópia)" == _cardNome + "(Cópia)")
            {
                Debug.Log("Nome da Carta no Deck: " + carta.nome + " Nome do Coringa: " + _cardNome);

                //carta.ativo = !carta.ativo;
            }
        }
    }
}
