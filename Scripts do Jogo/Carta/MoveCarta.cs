using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//FAZ A CARTA SE MOVER COM O PONTEIRO DO MOUSE, BASTA COLOCAR ESTE SCRIPT NA CARTA
//DEVE SER COLOCADO SOMENTE NAS CARTAS QUE SÃO CONTROLADAS PELO JOGADOR
public class MoveCarta : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject resetaPosicao;
    public CartaDaCena cartaDaCena;

    SistemaCombate sistemaCombate;
    TrocaLugar trocaLugar;
    Baralho baralho;
    EntraESaiCartas entraESaiCartas;

    private CartaDaCena cartaEncostada;

    [SerializeField] private RectTransform _transform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private bool selecionou = false;
    [SerializeField] private bool soltou = false;
    [SerializeField] private bool encostouEmOutraCarta = false;

    private Canvas canvas;

    [System.Obsolete]
    void Awake()
    {
        //NÃO PODEMOS USAR FINDOBJECTOFTYPE PARA OBJETOS QUE SERÃO INSTANCIADOS

        entraESaiCartas = FindObjectOfType<EntraESaiCartas>();
        sistemaCombate = FindObjectOfType<SistemaCombate>();
        baralho = FindObjectOfType<Baralho>();
        trocaLugar = FindObjectOfType<TrocaLugar>();

        cartaDaCena = GetComponent<CartaDaCena>();
        _transform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }
    public void SetSoltouCarta(bool _soltou)
    {
        soltou = _soltou;
    }
    public bool GetSoltouCarta()
    {
        return soltou;
    }
    public void SetSelecinouCarta(bool _selecinou)
    {
        selecionou = _selecinou;
    }
    public bool GetSelecinouCarta()
    {
        return selecionou;
    }
    public void SetEncostouOutraCarta(bool _encostou)
    {
        encostouEmOutraCarta = _encostou;
    }
    public bool GetEncostouOutraCarta()
    {
        return encostouEmOutraCarta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.blocksRaycasts = false;

        SetSoltouCarta(false);
        SetSelecinouCarta(true);

        entraESaiCartas.SetVerificaSeSoltouCarta(GetSoltouCarta());
    }
   
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        SetSoltouCarta(true);
        SetSelecinouCarta(false);

        entraESaiCartas.SetVerificaSeSoltouCarta(GetSoltouCarta());

        //if (cartaEncostada != null)
        //{
            //trocaLugar.VerificaPosicaoDasCartas(cartaEncostada, cartaDaCena);
        //}

        //Debug.Log("Soltou");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas == null || cartaDaCena == null)
            return;

        if (sistemaCombate.travarJogador == false && cartaDaCena.GetMoveuSe() == false)
        {
            _transform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Clicou");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bloqueador" && this.gameObject.CompareTag("Carta Jogador"))
        {
            this.transform.SetParent(resetaPosicao.transform, false);
            this.transform.localPosition = Vector3.zero;
        }

        if(collision.CompareTag("Carta Jogador") && GetSelecinouCarta() == true)
        {
            SetEncostouOutraCarta(true);
            entraESaiCartas.SetEncostouEmOutraCarta(GetEncostouOutraCarta());

            cartaEncostada = collision.GetComponent<CartaDaCena>();

            Debug.Log($"Você está encostando na carta : {cartaEncostada.dados.nome}");
            Debug.Log($"A carta que você está segurando é : {cartaDaCena.dados.nome}");

            //cartaDaCena = baralho.deckJogador.Find(c => c.dados.ID == cartaDaCena.dados.ID);

            //trocaLugar.VerificaPosicaoDasCartas(recebeCarta, cartaDaCena);
        }
    }    
}
