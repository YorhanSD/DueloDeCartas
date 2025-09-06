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
        }
    }

    public void CriaMya()
    {
        personagemList[0].id = 0;
        personagemList[0].nome = "Mya";

        salvaJogoPC.SalvaPersonagemEscolhido(personagemList[0].id, personagemList[0].nome);
    }

    public void CriaMcDino()
    {
        personagemList[1].id = 1;
        personagemList[1].nome = "McDino";

        salvaJogoPC.SalvaPersonagemEscolhido(personagemList[1].id, personagemList[1].nome);
    }
}


