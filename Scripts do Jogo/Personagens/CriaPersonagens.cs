using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CriaPersonagens : MonoBehaviour
{
    SalvaJogoPC salvaJogoPC;

    public List<Personagem> personagemList = new List<Personagem>();

    public List<Image> imageList = new List<Image>();

    //public List<String> campanhaList = new List<String>();

    public void Awake()
    {
        salvaJogoPC = GetComponent<SalvaJogoPC>();
    }

    public void Start()
    {
        if (salvaJogoPC != null)
        {
            //CriaMya();
            //CriaMcDino();
            //CriaMelinda();
            //CriaHekaib();
        }
    }

    public void CriaMya()
    {
        personagemList[0].id = 0;
        personagemList[0].nome = "Mya";
        personagemList[0].campanha = "Campanha_Mya";
        personagemList[0].pais = "Brasil";

        salvaJogoPC.SalvaPersonagemEscolhido(personagemList[0].id, personagemList[0].nome, personagemList[0].campanha, personagemList[0].pais);
    }

    public void CriaMcDino()
    {
        personagemList[1].id = 1;
        personagemList[1].nome = "McDino";
        personagemList[1].campanha = "Campanha_McDino";
        personagemList[1].pais = "México";

        salvaJogoPC.SalvaPersonagemEscolhido(personagemList[1].id, personagemList[1].nome, personagemList[1].campanha, personagemList[1].pais);
    }

    public void CriaMelinda()
    {
        personagemList[2].id = 2;
        personagemList[2].nome = "Melinda";
        personagemList[2].campanha = "Campanha_Melinda";
        personagemList[2].pais = "Brasil";

        salvaJogoPC.SalvaPersonagemEscolhido(personagemList[2].id, personagemList[2].nome, personagemList[2].campanha, personagemList[2].pais);
    }

    public void CriaHekaib()
    {
        personagemList[3].id = 3;
        personagemList[3].nome = "Hekaib";
        personagemList[3].campanha = "Campanha_Hekaib";
        personagemList[3].pais = "Egito";
            
        salvaJogoPC.SalvaPersonagemEscolhido(personagemList[3].id, personagemList[3].nome, personagemList[3].campanha, personagemList[3].pais);
    }
}


