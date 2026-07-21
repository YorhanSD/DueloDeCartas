using System.Collections.Generic;
using UnityEngine;

public class CriaOponentes : MonoBehaviour
{
    SalvaJogoPC salvaJogoPC;

    public List<Personagem> personagemList = new List<Personagem>();

    int numeroAleatorio;

    string especieDominanteSortiada;

    string especieRecessivaSortiada;

    public void Awake()
    {
        salvaJogoPC = GetComponent<SalvaJogoPC>();
    }

    void Start()
    {
        SorteiaEspecieDominante();
        SorteiaEspecieRecessiva();
        SorteiaOponente();
    }

    public void SorteiaEspecieDominante()
    {
        numeroAleatorio = UnityEngine.Random.Range(0, 4);

        switch(numeroAleatorio) 
        { 
            case 0:
                especieDominanteSortiada = "Espacial";
                break;
            case 1:
                especieDominanteSortiada = "Extinto";
                break;
            case 2:
                especieDominanteSortiada = "Tenebroso";
                break;
            case 3:
                especieDominanteSortiada = "Celestial";
                break;
        }
    }

    public void SorteiaEspecieRecessiva()
    {
        numeroAleatorio = UnityEngine.Random.Range(0, 4);

        switch (numeroAleatorio)
        {
            case 0:
                especieRecessivaSortiada = "Espacial";
                break;
            case 1:
                especieRecessivaSortiada = "Extinto";
                break;
            case 2:
                especieRecessivaSortiada = "Tenebroso";
                break;
            case 3:
                especieRecessivaSortiada = "Celestial";
                break;
        }
    }

    public void SorteiaOponente()
    {
        numeroAleatorio = UnityEngine.Random.Range(0, 4);

        switch (numeroAleatorio)
        {
            case 0:
                CriaMyaOponente();
                break;
            case 1:
                CriaMcDinoOponente();
                break;
            case 2:
                CriaOsmanOponente();
                break;
            case 3:
                CriaDalilaOponente();
                break;
        }
    }

    public void CriaMyaOponente()
    {
        personagemList[0].eOponente = true;

        salvaJogoPC.SalvaOponenteEscolhido(personagemList[0].id, personagemList[0].eOponente, personagemList[0].nome, personagemList[0].pais, especieDominanteSortiada, especieRecessivaSortiada);

        Debug.Log($"Oponente ID: {personagemList[0].id} com o nome : {personagemList[0].nome} foi criado com sucesso!");
    }
    public void CriaMcDinoOponente()
    {
        personagemList[1].eOponente = true;

        salvaJogoPC.SalvaOponenteEscolhido(personagemList[1].id, personagemList[1].eOponente, personagemList[1].nome, personagemList[1].pais, especieDominanteSortiada, especieRecessivaSortiada);

        Debug.Log($"Oponente ID: {personagemList[1].id} com o nome : {personagemList[1].nome} foi criado com sucesso!");
    }
    public void CriaOsmanOponente()
    {
        personagemList[2].eOponente = true;

        salvaJogoPC.SalvaOponenteEscolhido(personagemList[2].id, personagemList[2].eOponente, personagemList[2].nome, personagemList[2].pais, especieDominanteSortiada, especieRecessivaSortiada);

        Debug.Log($"Oponente ID: {personagemList[2].id} com o nome : {personagemList[2].nome} foi criado com sucesso!");
    }
    public void CriaDalilaOponente()
    {
        personagemList[3].eOponente = true;

        salvaJogoPC.SalvaOponenteEscolhido(personagemList[3].id, personagemList[3].eOponente, personagemList[3].nome, personagemList[3].pais, especieDominanteSortiada, especieRecessivaSortiada);

        Debug.Log($"Oponente ID: {personagemList[3].id} com o nome : {personagemList[3].nome} foi criado com sucesso!");
    }
}



