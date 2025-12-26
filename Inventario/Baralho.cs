using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;

public class Baralho : MonoBehaviour
{
    //LISTAS EXCLUSIVAS PARA CARTAS CLONES
    [SerializeField] private List<CartaDaCena> cartaTemp = new List<CartaDaCena>();
    [SerializeField] private List<CartaOriginal> dadosTemp = new List<CartaOriginal>();
    public List<UICard> uiTemp = new List<UICard>();

    SistemaCombate sistemaCombate;

    int contador = 11;
    public Canvas canvas;
    Deck deck;

    public int numeroAleatorio;
    public Transform baralhoTransform;
    public void Start()
    {
        sistemaCombate = GetComponent<SistemaCombate>();
        deck = GetComponent<Deck>();
    }
    public void ProximaCartaAleatoria()
    {
        numeroAleatorio = UnityEngine.Random.Range(0, 3);

        TransformaCoringaEm(numeroAleatorio);
    }

    public void TransformaCoringaEm(int _numeroSortiado)
    {
       
        CartaDaCena cartaClone  = Instantiate(cartaTemp[_numeroSortiado], baralhoTransform, false);

        baralhoTransform.localScale = Vector3.one;

        cartaClone.gameObject.name = cartaTemp[_numeroSortiado].name;

        contador++;

        CartaRuntime cartaRuntime = new CartaRuntime();
        cartaRuntime.ID = contador;
        cartaRuntime.cartaOriginal = dadosTemp[_numeroSortiado];
        cartaRuntime.Inicializar(contador);

        cartaClone.dados = cartaRuntime;

        UICard uiNova = Instantiate(uiTemp[numeroAleatorio], canvas.transform);

        uiNova.idUI = contador;
        uiNova.nomeUI = cartaRuntime.nomeAtual;
        uiNova.ataqueUI = cartaRuntime.ataqueAtual;
        uiNova.vidaUI = cartaRuntime.vidaAtual;

        //cartaTemp.Add(cartaClone);
        sistemaCombate.listaCenaCartas.Add(cartaClone);
        deck.geralCardList.Add(cartaRuntime);
        deck.geralUiCardList.Add(uiNova);

        //deck.AdicionaCard(cartaClone.dados.ID,cartaClone.dados.nome, cartaClone.dados.vida, cartaClone.dados.ataque);
        //deck.ImprimirNomes(cartaClone.dados.ID, cartaClone.dados.nome, cartaClone.dados.vida, cartaClone.dados.ataque);

        cartaClone.transform.parent = baralhoTransform.transform;
        cartaClone.gameObject.transform.position = baralhoTransform.transform.position;
    }
}
