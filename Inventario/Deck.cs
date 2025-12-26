using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] UICard uiCard;
    [SerializeField] CartaRuntime card;

    [SerializeField] SistemaCombate sistemaCombate;

    public int contador = 0;

    public List<CartaRuntime> geralCardList = new List<CartaRuntime>();

    public List<UICard> geralUiCardList = new List<UICard>();

    public void Start()
    {
        sistemaCombate = GetComponent<SistemaCombate>();
    }

    public void AdicionaCard(int _id, string _cardNome, int _cardVida, int _cardAtaque)
    {
        geralCardList[contador].ID = _id;
        geralCardList[contador].nomeAtual = _cardNome;
        geralCardList[contador].vidaAtual = _cardVida;
        geralCardList[contador].ataqueAtual = _cardAtaque;
    }
    public void ImprimirNomes(int _idUI, string _cardNome, int _cardVida, int _cardAtaque)
    {
        geralUiCardList[contador].idUI = _idUI;
        geralUiCardList[contador].nomeUI = _cardNome;
        geralUiCardList[contador].vidaUI = _cardVida;
        geralUiCardList[contador].ataqueUI = _cardAtaque;

        sistemaCombate.listaCenaCartas[contador].dados.ID = _idUI;
        sistemaCombate.listaCenaCartas[contador].dados.nomeAtual = _cardNome;
        sistemaCombate.listaCenaCartas[contador].dados.vidaAtual = _cardVida;
        sistemaCombate.listaCenaCartas[contador].dados.ataqueAtual = _cardAtaque;

        contador++;
    }
}
