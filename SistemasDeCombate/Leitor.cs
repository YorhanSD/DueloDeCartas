using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Leitor : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private SistemaCombate sC;
    [SerializeField] private Baralho baralho;

    [System.Obsolete]
    public void Start()
    {
        deck = FindObjectOfType<Deck>();
        sC = FindObjectOfType<SistemaCombate>();
        baralho = FindObjectOfType<Baralho>();
    }

    [System.Obsolete]
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != null && this.gameObject.tag == "Card Oponente")
        {
            foreach (CartaRuntime cartaA in deck.geralCardList)
            {
                if (cartaA.nomeAtual == collision.gameObject.name && collision.gameObject.tag == "Card Player")
                {
                    foreach(CartaRuntime cartaB in deck.geralCardList)
                    {
                        if (cartaB.nomeAtual == this.gameObject.name)
                        {
                            Debug.Log("Carta de Ataque: " + gameObject.name + " Carta de Defesa: " + cartaA.nomeAtual);

                            //ATACANTE: CARTA DO OPONENTE / DEFENSOR: CARTA DO JOGADOR

                            sC.UmContraUm(cartaB.ID, cartaA.ID);
                        }
                    }
                }
            }
        }
        
        if (collision.gameObject.tag != null && this.gameObject.tag == "Card Player")
        {
            foreach (CartaRuntime cartaA in deck.geralCardList)
            {
                if (cartaA.nomeAtual == collision.gameObject.name && collision.gameObject.tag == "Card Oponente")
                {
                    foreach (CartaRuntime cartaB in deck.geralCardList)
                    {
                        if (cartaB.nomeAtual == this.gameObject.name)
                        {
                            Debug.Log("Carta de Ataque: " + gameObject.name + " Carta de Defesa: " + cartaA.nomeAtual);

                            //ATACANTE: CARTA DO OPONENTE / DEFENSOR: CARTA DO JOGADOR

                            sC.UmContraUm(cartaB.ID, cartaA.ID);
                        }
                    }
                }
            }
        }
    }
}
