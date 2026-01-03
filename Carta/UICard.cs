using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UICard : MonoBehaviour
{
    public int idUI;

    public string nomeUI;

    public Slider barraVida;

    public int vidaUI;

    //public int vidaMAX;

    public int ataqueUI;

    public TextMeshProUGUI nomeTMPRO;

    public TextMeshProUGUI ataqueTMPRO;

    public CartaRuntime cartaRuntime;
    
    public void PegarDados(CartaRuntime _carta)
    {
        //cartaRuntime = _carta;

        //AtualizarUI();
    }
    public void AtualizarUI(CartaRuntime _carta)
    {
        if (cartaRuntime == null) return;

        nomeTMPRO.text = _carta.nomeAtual;
        ataqueTMPRO.text = _carta.ataqueAtual.ToString();

        nomeTMPRO.ForceMeshUpdate();
        ataqueTMPRO.ForceMeshUpdate();

        barraVida.maxValue = _carta.vidaMaxima;
        barraVida.value = _carta.vidaAtual;

        Debug.Log($"UI -> {nomeTMPRO.text} | ATK {ataqueTMPRO.text}");
    }
}
