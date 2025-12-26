using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    public List<CartaDaCena> listaCenaCartas = new List<CartaDaCena>();

    //MONOBEHAVIOUR NÃO PODE SER CRIADO COM NEW

    [SerializeField] private ControlaTurnos controlaTurnos;

    [SerializeField] private Deck deck;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlePontos controlePontos;

    Energia energia;

    public bool travarJogador = false;

    [System.Obsolete]
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
        if (energia.barraEnergiaJogador.value < 30)
        {
            travarJogador = true;
        }
        else
        {
            travarJogador = false;
        }
    }

    [System.Obsolete]
    public void UmContraUm(int IDAtacante, int IDDefensor)
    {
        CartaDaCena cartaCenaA = listaCenaCartas.Find(c => c.dados.ID == IDAtacante);
        CartaDaCena cartaCenaB = listaCenaCartas.Find(c => c.dados.ID == IDDefensor);

        if (cartaCenaA == null || cartaCenaB == null) return;

        if (controlaTurnos.turnoOponente == false && cartaCenaA.CompareTag("Card Player") && cartaCenaB.CompareTag("Card Oponente"))
        {
            cartaCenaA.SetPodeAtacar(false);
            cartaCenaB.dados.vidaAtual -= cartaCenaA.dados.ataqueAtual;

            AtualizaUI(cartaCenaB);

            VerificaMorte(cartaCenaB);

            Debug.Log($"Defensor: {cartaCenaA.dados.nomeAtual} Atacante: {cartaCenaB.dados.nomeAtual}");

            Debug.Log($"Card defensor: {cartaCenaB.dados.nomeAtual} recebe {cartaCenaB.dados.ataqueAtual} de dano");

            if (cartaCenaB.dados.vidaAtual > 0)
            {
                foreach (Case casa in ia_MapeamentoDeCases.listaCase)
                {
                    if (casa.GetUltimoID() == cartaCenaA.dados.ID)
                    {
                        cartaCenaA.gameObject.transform.parent = casa.gameObject.transform;
                        cartaCenaA.gameObject.transform.position = casa.gameObject.transform.position;
                    }
                }
            }

        }
        else if (controlaTurnos.turnoOponente == true && cartaCenaA.CompareTag("Card Oponente") && cartaCenaB.CompareTag("Card Player"))
        {
            cartaCenaA.SetPodeAtacar(false);
            cartaCenaB.dados.vidaAtual -= cartaCenaA.dados.ataqueAtual;

            AtualizaUI(cartaCenaB);

            VerificaMorte(cartaCenaB);

            if (cartaCenaB.dados.vidaAtual > 0 && cartaCenaA != null)
            {
                foreach (Case casaB in ia_MapeamentoDeCases.listaCase)
                {
                    if (casaB.GetUltimoID() == cartaCenaB.dados.ID)
                    {
                        Debug.Log("Case de retorno da carta mais forte do oponente : " + casaB.gameObject.name);

                        cartaCenaB.gameObject.transform.parent = casaB.gameObject.transform;
                        cartaCenaB.gameObject.transform.position = casaB.gameObject.transform.position;
                    }
                }

            }
          
            Debug.Log($"Atacante: {cartaCenaB.dados.nomeAtual} Defensor: {cartaCenaA.dados.nomeAtual}");

            Debug.Log($"Card defensor: {cartaCenaA.dados.nomeAtual} recebe {cartaCenaB.dados.ataqueAtual} de dano");
        }




    }
    void VerificaMorte(CartaDaCena carta)
    {
        if (carta.dados.vidaAtual <= 0)
        {
            // Remove UI
            deck.geralUiCardList.RemoveAll(ui => ui.idUI == carta.dados.ID);

            // Remove runtime
            deck.geralCardList.Remove(carta.dados);

            // Remove da cena
            listaCenaCartas.Remove(carta);

            Destroy(carta.gameObject);
        }
    }
    void AtualizaUI(CartaDaCena carta)
    {
        foreach (UICard ui in deck.geralUiCardList)
        {
            if (ui.idUI == carta.dados.ID)
            {
                ui.vidaUI = carta.dados.vidaAtual;
                break;
            }
        }
    }
    /*
    public void CalculoDeDano(CartaDaCena _cardAtacante, CartaDaCena _cardDefensor)
    {
        foreach (UICard uiCardA in deck.geralUiCardList)
        {
            if (uiCardA.idUI == _cardAtacante.dados.ID)
            {
                foreach (UICard uiCardB in deck.geralUiCardList)
                {
                    if (uiCardB.idUI == _cardDefensor.dados.ID)
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
    */
}

