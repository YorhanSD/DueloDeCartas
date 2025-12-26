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
    SistemaCombate sistemaCombate;

    private Canvas canvas;

    public CartaRuntime dados;

    public UICard uiEstatisticas;

    [SerializeField] private bool cartaAtiva = false;

    [SerializeField] private bool podeAtacar = true;

    [SerializeField] private bool moveuSe = false;

    [System.Obsolete]
    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        reactTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        uiEstatisticas = GetComponentInParent<UICard>();
        sistemaCombate = FindObjectOfType<SistemaCombate>();

        if (canvas == null)
        {
            Debug.LogError($"Canvas não encontrado para a carta {gameObject.name}");
        }
    }

    private void Update()
    {
        //Morte();
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

    public void Morte()
    {
        if (dados.vidaAtual <= 0)
        {
            sistemaCombate.listaCenaCartas.Remove(this);
            Destroy(gameObject);
        }
    }
}
