using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private ControlaTurnos cT;
    [SerializeField] private Deck deck;

    public void UmContraUm(string nomeAtacante, string nomeDefensor)
    {
        foreach (Card cardA in deck.geralCardList)
        {
            if(cardA.nome == nomeAtacante)
            {
                foreach (Card cardB in deck.geralCardList)
                {
                    if (cardB.nome == nomeDefensor)
                    {
                        if (cardA.gameObject.tag == "Card Player" && cardB.gameObject.tag == "Card Oponente")
                        {
                            if (cT.turnoOponente == false)
                            {
                                cardB.vida -= cardA.ataque;

                                Debug.Log($"Defensor: {cardB.nome}");
                                Debug.Log($"Atacante: {cardA.nome}");

                                Debug.Log($"Card defensor: {cardB.nome} recebe {cardA.ataque} de dano");
                            }
                            else
                            {
                                cardA.vida -= cardB.ataque;

                                Debug.Log($"Atacante: {cardB.nome}");
                                Debug.Log($"Defensor: {cardA.nome}");

                                Debug.Log($"Card defensor: {cardA.nome} recebe {cardB.ataque} de dano");
                            }

                            CalculoDeDano(cardA, cardB);
                        }
                    }
                }
            }
        }

    }
    public void CalculoDeDano(Card _cardAtacante, Card _cardDefensor)
    {
        foreach (UICard uiCardA in deck.geralUiCardList)
        {
           if(uiCardA.idUI == _cardAtacante.ID)
            {
                foreach (UICard uiCardB in deck.geralUiCardList)
                {
                    if (uiCardB.idUI == _cardDefensor.ID)
                    {
                        if (cT.turnoOponente == false) 
                        {
                            uiCardB.vidaUI -= uiCardA.ataqueUI;
                        }
                        else
                        {
                            uiCardA.vidaUI -= uiCardB.ataqueUI;
                        }
                    }
                }
            }
        }
    }
}
