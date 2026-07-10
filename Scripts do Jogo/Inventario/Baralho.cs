using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Baralho : MonoBehaviour
{
    //LISTAS EXCLUSIVAS PARA CARTAS CLONES
    public List<CartaDaCena> deckJogador = new List<CartaDaCena>();
    [SerializeField] private List<CartaDaCena> cenaTemp = new List<CartaDaCena>();
    [SerializeField] private List<CartaOriginal> dadosTemp = new List<CartaOriginal>();

    [SerializeField] UICard uiPrefab;
    [SerializeField] Transform uiParent;

    BancoCards bancoCartas;

    //public int contador = 11;
    public Canvas canvas;


    public int numeroAleatorio;
    public Transform baralhoTransform;
    public void Awake()
    {
        bancoCartas = GetComponent<BancoCards>();
    }
    public void ProximaCartaAleatoria()
    {
        numeroAleatorio = UnityEngine.Random.Range(0, 3);

        CriaDuplicata(numeroAleatorio);
    }

    public void CriaDuplicata(int _numeroSortiado)
    {
        CartaDaCena cartaClone = Instantiate(
            cenaTemp[_numeroSortiado],
            baralhoTransform,
            false
        );

        CartaRuntime cartaRuntime = new CartaRuntime();
        cartaRuntime.cartaOriginal = dadosTemp[_numeroSortiado];
        cartaRuntime.Inicializar(bancoCartas.contaID);

        cartaClone.dados = cartaRuntime;

        cartaClone.GravaUI(cartaRuntime);
        cartaClone.PrintaDados(cartaRuntime);
        //cartaClone.uiCarta.AtualizarUI(cartaClone.dados);

        //cartaClone.GravaDados(cartaRuntime);

        //Debug.Log($"Baralho jogador gerou a carta: {cartaRuntime.nomeAtual} com o ID: {cartaRuntime.ID}");

        bancoCartas.geralCartaCenaLista.Add(cartaClone);
        bancoCartas.geralCartaRuntimeLista.Add(cartaRuntime);
        deckJogador.Add(cartaClone);

        cartaClone.transform.localPosition = Vector3.zero;

        bancoCartas.contaID++;
    }
}