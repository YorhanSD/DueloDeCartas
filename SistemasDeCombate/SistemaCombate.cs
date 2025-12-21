using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private ControlaTurnos controlaTurnos;

    [SerializeField] private Deck deck;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlePontos controlePontos;

    Energia energia;

    public bool travarJogador = false;

    public void Start()
    {
        deck = GetComponent<Deck>();

        controlaTurnos = GetComponent<ControlaTurnos>();

        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();

        controlePontos = FindObjectOfType<ControlePontos>();

        energia = GetComponent<Energia>();
    }

    private void Update()
    {
        if(energia.barraEnergiaJogador.value < 30)
        {
            travarJogador = true;
        }
        else
        {
            travarJogador = false;
        }
    }

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
                        if (cardA != null && cardA.gameObject.tag == "Card Player" && cardB.gameObject.tag == "Card Oponente")
                        {
                            if (controlaTurnos.turnoOponente == false)
                            {
                                if (cardA != null && cardA.ativo == true && cardA.podeAtacar == true)
                                {
                                    cardA.podeAtacar = false;

                                    cardB.vida -= cardA.ataque;

                                    energia.RetiraEnergiaJogador(40);

                                    Debug.Log($"Defensor: {cardB.nome} Atacante: {cardA.nome}");

                                    Debug.Log($"Card defensor: {cardB.nome} recebe {cardA.ataque} de dano");

                                    if(cardB.vida > 0)
                                    {
                                        foreach(Case casa in ia_MapeamentoDeCases.listaCase)
                                        {
                                            if(casa.GetUltimoCard() == cardA.nome)
                                            {
                                                cardA.gameObject.transform.parent = casa.gameObject.transform;
                                                cardA.gameObject.transform.position = casa.gameObject.transform.position;

                                                //podeMover = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //podeMover = false;
                                        Destroy(cardB.gameObject);
                                        controlePontos.AdicionaPontos(500);
                                        
                                    }
                                }
                            }
                            else
                            {
                                if (cardA != null)
                                {
                                    cardA.vida -= cardB.ataque;

                                    energia.RetiraEnergiaOponente(40);

                                    if (cardA.vida > 0 && cardA != null)
                                    {
                                        foreach (Case casaB in ia_MapeamentoDeCases.listaCase)
                                        {
                                            if (casaB.GetUltimoCard() == cardB.nome)
                                            {
                                                Debug.Log("Case de retorno da carta mais forte do oponente : " + casaB.gameObject.name);

                                                cardB.gameObject.transform.parent = casaB.gameObject.transform;
                                                cardB.gameObject.transform.position = casaB.gameObject.transform.position;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Destroy(cardA.gameObject );

                                    }
                                }

                                Debug.Log($"Atacante: {cardB.nome} Defensor: {cardA.nome}");

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
                        if (controlaTurnos.turnoOponente == false) 
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
