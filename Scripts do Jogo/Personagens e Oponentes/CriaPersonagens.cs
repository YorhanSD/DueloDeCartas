using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CriaPersonagens : MonoBehaviour
{
    TelaPersonagem telaPersonagem;

    SalvaJogoPC salvaJogoPC;

    public List<Personagem> personagemList = new List<Personagem>();

    //public List<Image> imageList = new List<Image>();

    public void Awake()
    {
        telaPersonagem = GetComponent<TelaPersonagem>();
        salvaJogoPC = GetComponent<SalvaJogoPC>();
    }

    public void Start()
    {
        telaPersonagem = GetComponent<TelaPersonagem>();
    }

    public void BotaoCriaMya()
    {
        telaPersonagem.SetPersonagemSelecionado(personagemList[0].id);

        telaPersonagem.Tela(personagemList[0].fotoPersonagem, personagemList[0].nome, personagemList[0].idade.ToString(), personagemList[0].pais, personagemList[0].profissao, personagemList[0].lore, personagemList[0].elencoDominante.ToString());
    }
    public void BotaoCriaMcDino()
    {
        telaPersonagem.SetPersonagemSelecionado(personagemList[1].id);

        telaPersonagem.Tela(personagemList[1].fotoPersonagem, personagemList[1].nome, personagemList[1].idade.ToString(), personagemList[1].pais, personagemList[1].profissao, personagemList[1].lore, personagemList[1].elencoDominante.ToString());
    }
    public void BotaoCriaHekaib()
    {
        telaPersonagem.SetPersonagemSelecionado(personagemList[2].id);

        telaPersonagem.Tela(personagemList[2].fotoPersonagem, personagemList[2].nome, personagemList[2].idade.ToString(), personagemList[2].pais, personagemList[2].profissao, personagemList[2].lore, personagemList[2].elencoDominante.ToString());
    }
    public void BotaoCriaDalila()
    {
        telaPersonagem.SetPersonagemSelecionado(personagemList[3].id);

        telaPersonagem.Tela(personagemList[3].fotoPersonagem, personagemList[3].nome, personagemList[3].idade.ToString(), personagemList[3].pais, personagemList[3].profissao, personagemList[3].lore, personagemList[3].elencoDominante.ToString());
    }
}


