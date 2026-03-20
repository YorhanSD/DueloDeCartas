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

    public int vidaAtual;

    public int vidaMAX;

    public int ataqueUI;

    public TextMeshProUGUI nomeTMPRO;

    public TextMeshProUGUI ataqueTMPRO;

    public TextMeshProUGUI vidaMaximaTMPRO;

    public TextMeshProUGUI vidaAtualTMPRO;

    public TextMeshProUGUI couracaTMPRO;

    public TextMeshProUGUI reacaoTMPRO;

    public TextMeshProUGUI lucidezTMPRO;

    public CartaRuntime cartaRuntime;
    
    public void PegarDados(CartaRuntime _carta)
    {
        //cartaRuntime = _carta;

        //AtualizarUI();
    }
    public void AtualizarUI(CartaRuntime _carta)
    {
        barraVida.maxValue = _carta.vidaMaxima;
        barraVida.value = _carta.vidaAtual;
        vidaMAX = _carta.vidaMaxima;
        vidaAtual = _carta.vidaAtual;

        if (vidaAtualTMPRO != null && vidaMaximaTMPRO != null)
        {
            vidaAtualTMPRO.text = vidaAtual.ToString();
            vidaMaximaTMPRO.text = vidaMAX.ToString();
        }
        else
        {
            Debug.Log(this.gameObject.name + " tem componentes nulos");
        }

        if (nomeTMPRO != null && ataqueTMPRO != null && couracaTMPRO != null && reacaoTMPRO != null && lucidezTMPRO != null)
        {
            nomeTMPRO.text = _carta.nome;
            ataqueTMPRO.text = $"AT {_carta.ataqueAtual.ToString()}";
            couracaTMPRO.text = $"CO {_carta.couraca.ToString()}";
            reacaoTMPRO.text = $"RE {_carta.reacao.ToString()}";
            lucidezTMPRO.text = $"LU {_carta.lucidez.ToString()}";
        }
        else
        {
            Debug.Log(this.gameObject.name + " tem componentes nulos");
        }
    }
}
