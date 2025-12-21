using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] UICard uiCard;
    [SerializeField] Card card;

    public int contador = 0;

    public List<Card> geralCardList = new List<Card>();

    public List<UICard> geralUiCardList = new List<UICard>();

    public void AdicionaCard(int _id, string _cardNome, int _cardVida, int _cardAtaque, int _cardResistencia)
    {
        geralCardList[contador].ID = _id;
        geralCardList[contador].nome = _cardNome;
        geralCardList[contador].vida = _cardVida;
        geralCardList[contador].ataque = _cardAtaque;
        geralCardList[contador].resistencia = _cardResistencia;
    }
    public void ImprimirNomes(int _idUI, string _cardNome, int _cardVida, int _cardAtaque, int _cardResistencia)
    {
        geralUiCardList[contador].idUI = _idUI;
        geralUiCardList[contador].nomeUI = _cardNome;
        geralUiCardList[contador].vidaUI = _cardVida;
        geralUiCardList[contador].ataqueUI = _cardAtaque;
        geralUiCardList[contador].resistenciaUI = _cardResistencia;

        contador++;
    }
}
