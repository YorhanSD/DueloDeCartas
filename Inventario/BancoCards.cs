using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BancoCards : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] UICard uiCard;
    [SerializeField] Deck deck;

    private int contaID = 0;

    void Start()
    {
        card = GetComponent<Card>();
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
    }
    public void CriaTorosaurus()
    {
        contaID = 0;

        card = new Card
        {
            ID = contaID,
            nome = "Torosaurus",
            vida = 40,
            ataque = 20,
            resistencia = 40
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaGiganotosaurus()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Giganotosaurus",
            vida = 30,
            ataque = 50,
            resistencia = 20
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaVelociraptor()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Velociraptor",
            vida = 50,
            ataque = 40,
            resistencia = 10
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaMalfeitorGalatico()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Malfeitor Galático",
            vida = 40,
            ataque = 40,
            resistencia = 20
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaMalfeitoraGalatica()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Malfeitora Galática",
            vida = 20,
            ataque = 70,
            resistencia = 10
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaGoliath()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Goliath",
            vida = 80,
            ataque = 10,
            resistencia = 10
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaPericuloso()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Periculoso",
            vida = 40,
            ataque = 40,
            resistencia = 20
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaAssombrador()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Assombrador",
            vida = 30,
            ataque = 70,
            resistencia = 0
        };

        deck.AdicionaCard(card.ID, card.nome,card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }
    public void CriaMortoEmCombate()
    {
        contaID++;

        card = new Card
        {
            ID = contaID,
            nome = "Morto em Combate",
            vida = 30,
            ataque = 30,
            resistencia = 40
        };

        deck.AdicionaCard(card.ID, card.nome, card.vida, card.ataque, card.resistencia);

        deck.ImprimirNomes(card.ID, card.nome, card.vida, card.ataque, card.resistencia);
    }

}
