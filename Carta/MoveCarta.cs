using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCarta : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject resetPoint;
    Card card;

    [SerializeField] private RectTransform _transform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;

    SistemaCombate sistemaCombate;

    void Start()
    {
        card = GetComponent<Card>();
        sistemaCombate = FindObjectOfType<SistemaCombate>();
    }
    //FAZ A CARTA SE MOVER COM O PONTEIRO DO MOUSE, BASTA COLOCAR ESTE SCRIPT NA CARTA
    //DEVE SER COLOCADO SOMENTE NAS CARTAS QUE SÃO CONTROLADAS PELO JOGADOR

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
        if (sistemaCombate.travarJogador == false && card.GetMoveuSe() == false)
        {
            _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        //Debug.Log("Pegou");
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
