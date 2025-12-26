using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BancoCards : MonoBehaviour
{
    [SerializeField] CartaRuntime card;
    [SerializeField] CartaDaCena cardDaCena;
    [SerializeField] Deck deck;

    public int contaID = 0;

    void Start()
    {
        deck = GetComponent<Deck>();

        CriaTorosaurus();
        CriaGiganotosaurus();
        CriaVelociraptor();
        CriaMalfeitorGalatico();
        CriaMalfeitoraGalatica();
        CriaGoliath();
        CriaPericuloso();
        CriaAssombrador();
        CriaMortoEmCombate();
        CriaAnjo();
        CriaSacerdotiza();
        CriaProfeta();
    }
    public void CriaTorosaurus()
    {
        CartaRuntime card = new CartaRuntime();
        contaID = 0;

        card.ID = contaID;
        card.nomeAtual = "Torosaurus";
        card.vidaAtual = 70;
        card.ataqueAtual = 20;



        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaGiganotosaurus()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Giganotosaurus";
        card.vidaAtual = 30;
        card.ataqueAtual = 50;



        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaVelociraptor()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Velociraptor";
        card.vidaAtual = 50;
        card.ataqueAtual = 30;
   


        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaMalfeitorGalatico()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Malfeitor Galatico";
        card.vidaAtual = 30;
        card.ataqueAtual = 60;




        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaMalfeitoraGalatica()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Malfeitora Galatica";
        card.vidaAtual = 20;
        card.ataqueAtual = 70;




        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaGoliath()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Goliath";
        card.vidaAtual = 80;
        card.ataqueAtual = 10;



        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaPericuloso()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Periculoso";
        card.vidaAtual = 40;
        card.ataqueAtual = 40;




        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaAssombrador()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Assombrador";
        card.vidaAtual = 30;
        card.ataqueAtual = 70;

        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
    public void CriaMortoEmCombate()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Morto em Combate";
        card.vidaAtual = 50;
        card.ataqueAtual = 30;
       

        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }

    public void CriaAnjo()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Anjo";
        card.vidaAtual = 70;
        card.ataqueAtual = 30;



        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }

    public void CriaSacerdotiza()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Sacerdotiza";
        card.vidaAtual = 60;
        card.ataqueAtual = 40;




        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }

    public void CriaProfeta()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Profeta";
        card.vidaAtual = 50;
        card.ataqueAtual = 50;
  

        deck.AdicionaCard(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);

        deck.ImprimirNomes(card.ID, card.nomeAtual, card.vidaAtual, card.ataqueAtual);
    }
}
