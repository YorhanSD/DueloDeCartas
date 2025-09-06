using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCarta : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform _transform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;

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
        //Debug.Log("Pegou");

        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Clicou");
    }
}
