using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BancoCards : MonoBehaviour
{
    //public List<UICard> geralCartaUILista = new List<UICard>();
    public List<CartaRuntime> geralCartaRuntimeLista = new();
    public List<CartaDaCena> geralCartaCenaLista = new();

    [SerializeField] CartaRuntime card;
    [SerializeField] CartaDaCena cartaCena;
    [SerializeField] UICard uiPrefab;

    public int contaID = 0;

    void Awake()
    {
        //CriaTorosaurus();
        //CriaGiganotosaurus();
        //CriaVelociraptor();
        //CriaMalfeitorGalatico();
        //CriaMalfeitoraGalatica();
        //CriaGoliath();
        //CriaPericuloso();
        //CriaAssombrador();
        //CriaMortoEmCombate();
        //CriaAnjo();
        //CriaSacerdotiza();
        //CriaProfeta();

        CriarCartasDaCena();
           
        

        //geralCartaCenaLista.Clear();
    }
    public void CriaTorosaurus()
    {
        CartaRuntime card = new CartaRuntime();
        contaID = 0;

        card.ID = contaID;
        card.nomeAtual = "Torosaurus";
        card.vidaAtual = 70;
        card.ataqueAtual = 30;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
     
    }
    public void CriaGiganotosaurus()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Giganotosaurus";
        card.vidaAtual = 30;
        card.ataqueAtual = 50;

        geralCartaRuntimeLista.Add(card);

       //UICard uICard = new UICard();
       //uICard.InserirUI(card.ID);

    }
    public void CriaVelociraptor()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Velociraptor";
        card.vidaAtual = 50;
        card.ataqueAtual = 30;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }
    public void CriaMalfeitorGalatico()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Malfeitor Galatico";
        card.vidaAtual = 30;
        card.ataqueAtual = 60;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }
    public void CriaMalfeitoraGalatica()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Malfeitora Galatica";
        card.vidaAtual = 20;
        card.ataqueAtual = 70;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }
    public void CriaGoliath()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Goliath";
        card.vidaAtual = 80;
        card.ataqueAtual = 10;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }
    public void CriaPericuloso()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Periculoso";
        card.vidaAtual = 40;
        card.ataqueAtual = 40;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }
    public void CriaAssombrador()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Assombrador";
        card.vidaAtual = 30;
        card.ataqueAtual = 70;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }
    public void CriaMortoEmCombate()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Morto em Combate";
        card.vidaAtual = 50;
        card.ataqueAtual = 30;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }

    public void CriaAnjo()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Anjo";
        card.vidaAtual = 70;
        card.ataqueAtual = 30;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }

    public void CriaSacerdotiza()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Sacerdotiza";
        card.vidaAtual = 60;
        card.ataqueAtual = 40;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }

    public void CriaProfeta()
    {
        CartaRuntime card = new CartaRuntime();
        contaID++;

        card.ID = contaID;
        card.nomeAtual = "Profeta";
        card.vidaAtual = 50;
        card.ataqueAtual = 50;

        geralCartaRuntimeLista.Add(card);

        //UICard uICard = new UICard();
        //uICard.InserirUI(card.ID);
    }

    public void CriarCartasDaCena()
    {
        for (int i = 0; i < 12; i++)
        {
            CartaRuntime runtime = new CartaRuntime();
            runtime.cartaOriginal = geralCartaCenaLista[contaID].cartaBase;
            runtime.Inicializar(contaID);

            geralCartaRuntimeLista.Add(runtime);
            geralCartaCenaLista[contaID].dados = runtime;

            // cria a UI aqui
            //UICard uiCarta = new UICard();
            //uiCarta.PegarDados(geralCartaCenaLista[contaID].dados);
            geralCartaCenaLista[contaID].GravaUI(runtime);

            contaID++;
        }
    }
}
