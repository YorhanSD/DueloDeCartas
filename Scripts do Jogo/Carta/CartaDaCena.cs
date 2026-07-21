using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CartaDaCena : MonoBehaviour
{
    public int printID;
    public string printEspecie;
    public string printNome;
    public int printVidaMaxima;
    public int printVida;
    public int printAtaque;
    public int printCouraca;
    public int printReacao;
    public int printLucidez;

    [SerializeField] private RectTransform reactTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private ControlaTurnos turnos;

    private Canvas canvas;

    public CartaRuntime dados;

    public CartaOriginal cartaBase;

    public UICard uiCarta;

    [SerializeField] private Transform uiParent;

    [SerializeField] private bool cartaAtiva = false;

    [SerializeField] private bool podeAtacar = true;
     
    [SerializeField] private bool moveuSe = false;

    [System.Obsolete]
    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        reactTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvas == null)
        {
            Debug.LogError($"Canvas não encontrado para a carta {gameObject.name}");
        }
    }
    public void GravaUI(CartaRuntime _cartaRuntime)
    {
        uiCarta.AtualizarUI(_cartaRuntime);
    }
    public void PrintaDados(CartaRuntime _cartaRuntime)
    {
        printID = _cartaRuntime.ID;
        printEspecie = _cartaRuntime.especieSelecionada;
        printNome = _cartaRuntime.nome;
        printVidaMaxima = _cartaRuntime.vidaMaxima;
        printVida = _cartaRuntime.vidaAtual;
        printAtaque = _cartaRuntime.ataqueAtual;
        printCouraca = _cartaRuntime.couracaAtual;
        printReacao = _cartaRuntime.reacao;
        printLucidez = _cartaRuntime.lucidez;
    }
    
    public void SetPodeAtacar(bool _atacou)
    {
        podeAtacar = _atacou;
    }
    public bool GetPodeAtacar()
    {
        return podeAtacar;
    }
    public void SetEstaAtivada(bool _ativada)
    {
        cartaAtiva = _ativada;
    }
    public bool GetEstaAtivada()
    {
        return cartaAtiva;
    }
    public bool GetMoveuSe()
    {
        return moveuSe;
    }
    public void SetMoveuSe(bool _moveuSe)
    {
        moveuSe = _moveuSe;
    }
}
