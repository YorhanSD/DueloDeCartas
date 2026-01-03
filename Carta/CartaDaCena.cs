using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CartaDaCena : MonoBehaviour
{
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
    void Start()
    {
        if (dados == null && cartaBase != null)
        {
            //dados = new CartaRuntime();
            //dados.cartaOriginal = cartaBase;
            //dados.Inicializar(GeradorID.GerarID());

            //uiCarta = Instantiate(uiPrefab, uiParent);
            //uiCarta.PegarDados(dados);
        }
    }
    public static class GeradorID
    {
        //private static int idAtual = 0;
        //public static int GerarID()
        //{
            //idAtual++;
            //return idAtual;
        //}
    }
    public void GravaUI(CartaRuntime _cartaRuntime)
    {
        uiCarta.nomeTMPRO.text = _cartaRuntime.nomeAtual;
        uiCarta.barraVida.maxValue = _cartaRuntime.vidaMaxima;
        uiCarta.barraVida.value = _cartaRuntime.vidaAtual;
        uiCarta.ataqueTMPRO.text = _cartaRuntime.ataqueAtual.ToString();
    }
    public void Inicializar(CartaRuntime cartaRuntime, UICard _UI, Transform uiParent)
    {
        dados = cartaRuntime;

        //uiCarta = Instantiate(_UI, uiParent);
        GravaUI(cartaRuntime);
        //uiCarta.PegarDados(cartaRuntime);


        Debug.Log($"UI criada para {cartaRuntime.nomeAtual}");
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


    public void OnTriggerEnter2D(Collider2D _casa)
    {        
        if(_casa.gameObject.tag == "Slot Player" && this.gameObject.tag != "Card Oponente")
        {
            SetMoveuSe(true);
            SetEstaAtivada(true);
        }
    }
}
