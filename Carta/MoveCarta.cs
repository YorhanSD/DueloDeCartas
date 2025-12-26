using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//FAZ A CARTA SE MOVER COM O PONTEIRO DO MOUSE, BASTA COLOCAR ESTE SCRIPT NA CARTA
//DEVE SER COLOCADO SOMENTE NAS CARTAS QUE SÃO CONTROLADAS PELO JOGADOR
public class MoveCarta : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject resetPoint;

    [SerializeField] private RectTransform _transform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;

    private Canvas canvas;

    SistemaCombate sistemaCombate;
    [SerializeField] CartaDaCena cartaDaCena;

    [System.Obsolete]
    void Awake()
    {
        //NÃO PODEMOS USAR FINDOBJECTOFTYPE PARA OBJETOS QUE SERÃO INSTANCIADOS

        cartaDaCena = GetComponent<CartaDaCena>();
        sistemaCombate = FindObjectOfType<SistemaCombate>();

        _transform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }
    

    public void SetCartaDaCena(CartaDaCena _cartaDaCena)
    {
        cartaDaCena = _cartaDaCena;
    }
    public void SetSistemaCombate(SistemaCombate sistema)
    {
        sistemaCombate = sistema;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.blocksRaycasts = false;

        //Debug.Log("Inicio");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        //Debug.Log("Soltou");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas == null || cartaDaCena == null)
            return;

        if (sistemaCombate == null)
        {
            Debug.LogError("SistemaCombate não inicializado");
            return;
        }
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
        if (collision.gameObject.tag == "Zona Restritiva")
        {
            this.transform.parent = resetPoint.transform;
            this.transform.position = resetPoint.transform.position;
        }
    }
}
