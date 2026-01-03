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

    [SerializeField] UICard uiPrefab;
    [SerializeField] Transform uiParent;

    BancoCards bancoCartas;
    SistemaCombate sistemaCombate;

    public int contador = 11;
    public Canvas canvas;
    Deck deck;

    public int numeroAleatorio;
    public Transform baralhoTransform;
    public void Start()
    {
        sistemaCombate = GetComponent<SistemaCombate>();
        deck = GetComponent<Deck>();
        bancoCartas = GetComponent<BancoCards>();
        //CriarUISExistentes();
    }
    public void ProximaCartaAleatoria()
    {
        numeroAleatorio = UnityEngine.Random.Range(0, 3);

        CriaDuplicata(numeroAleatorio);
    }

    public void CriaDuplicata(int _numeroSortiado)
    {
        CartaDaCena cartaClone = Instantiate(
            cartaTemp[_numeroSortiado],
            baralhoTransform,
            false
        );

        contador++;

        CartaRuntime cartaRuntime = new CartaRuntime();
        cartaRuntime.cartaOriginal = dadosTemp[_numeroSortiado];
        cartaRuntime.Inicializar(contador);
        cartaClone.gameObject.name = cartaRuntime.nomeAtual;
        cartaClone.GravaUI(cartaRuntime);

        bancoCartas.geralCartaCenaLista.Add(cartaClone);
        bancoCartas.geralCartaRuntimeLista.Add(cartaRuntime);

        cartaClone.transform.localPosition = Vector3.zero;

    }
}