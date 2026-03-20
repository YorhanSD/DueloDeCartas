using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Obsolete]
public class Leitor : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private SistemaCombate sC;
    [SerializeField] private Baralho baralho;
    [SerializeField] private Baralho_Oponente baralhoOponente;
    [SerializeField] private BancoCards bancoCartas;

    [System.Obsolete]
    public void Start()
    {
        deck = FindObjectOfType<Deck>();
        sC = FindObjectOfType<SistemaCombate>();
        baralho = FindObjectOfType<Baralho>();
        baralhoOponente = FindObjectOfType<Baralho_Oponente>();
        bancoCartas = FindObjectOfType<BancoCards>();
    }

    [System.Obsolete]
    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.tag != null && this.gameObject.tag == "Card Oponente")
        {
            CartaDaCena atacante = null;
            CartaDaCena defensor = null;

            foreach (CartaDaCena carta in baralhoOponente.deckOponente)
            {
                if (carta.gameObject == collision.gameObject)
                    atacante = carta;

                if (carta.gameObject == this.gameObject)
                    defensor = carta;
            }

            if (atacante != null && defensor != null)
            {
                Debug.Log($"Nome Defensor: {defensor.dados.nomeAtual} Defensor ID: {defensor.dados.ID} Nome Atacante: {atacante.dados.nomeAtual} Atacante ID: {atacante.dados.ID}");
                sC.UmContraUm(defensor.dados.ID, atacante.dados.ID);
            }

        }

        if (collision.gameObject.tag != null && this.gameObject.tag == "Card Player")
        {
            CartaDaCena atacante = null;
            CartaDaCena defensor = null;

            foreach (CartaDaCena carta in baralho.deckJogador)
            {
                if (carta.gameObject == collision.gameObject)
                    atacante = carta;

                if (carta.gameObject == this.gameObject)
                    defensor = carta;
            }

            if (atacante != null && defensor != null)
            {
                Debug.Log($"Nome Defensor: {defensor.dados.nomeAtual} Defensor ID: {defensor.dados.ID} Nome Atacante: {atacante.dados.nomeAtual} Atacante ID: {atacante.dados.ID}");
                sC.UmContraUm(defensor.dados.ID, atacante.dados.ID);
            }

        }
        */

    }

}
