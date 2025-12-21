using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BancoCards : MonoBehaviour
{
    [SerializeField] Card card;
    //[SerializeField] UICard uiCard;
    [SerializeField] Deck deck;

    public int contaID = 0;

    void Start()
    {
        card = new Card();
        deck = GetComponent<Deck>();
        //uiCard = GetComponent<UICard>();

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
        //CriaCartaCoringa();
    }
    public void CriaTorosaurus()
    {
        contaID = 0;

        card.ID = contaID;
        card.nome = "Torosaurus";
        card.vida = 70;
        card.ataque = 20;
        card.resistencia = 10;
        
        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaGiganotosaurus()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Giganotosaurus";
        card.vida = 30;
        card.ataque = 50;
        card.resistencia = 20;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaVelociraptor()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Velociraptor";
        card.vida = 50;
        card.ataque = 30;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaMalfeitorGalatico()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Malfeitor Galatico";
        card.vida = 30;
        card.ataque = 60;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaMalfeitoraGalatica()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Malfeitora Galatica";
        card.vida = 20;
        card.ataque = 70;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaGoliath()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Goliath";
        card.vida = 80;
        card.ataque = 10;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaPericuloso()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Periculoso";
        card.vida = 40;
        card.ataque = 40;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaAssombrador()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Assombrador";
        card.vida = 30;
        card.ataque = 70;
        card.resistencia = 0;

        deck.AdicionaCard(card.ID, card.nome,card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaMortoEmCombate()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Morto em Combate";
        card.vida = 50;
        card.ataque = 30;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }

    public void CriaAnjo()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Anjo";
        card.vida = 40;
        card.ataque = 40;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }

    public void CriaSacerdotiza()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Sacerdotiza";
        card.vida = 60;
        card.ataque = 30;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }

    public void CriaProfeta()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Profeta";
        card.vida = 60;
        card.ataque = 30;
        card.resistencia = 10;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaCartaCoringa()
    {
        contaID++;

        card.ID = contaID;
        card.nome = "Coringa";
        card.vida = 200;
        card.ataque = 0;
        card.resistencia = 0;

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
}
