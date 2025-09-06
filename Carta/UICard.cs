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

    public int ataqueUI;

    public int resistenciaUI;

    public TextMeshProUGUI nomeTMPRO;

    public TextMeshProUGUI ataqueTMPRO;

    public TextMeshProUGUI resistenciaTMPRO;

    public void Update()
    {
        nomeTMPRO.text = nomeUI;
        barraVida.value = vidaUI;
        ataqueTMPRO.text = "ATQ: " + ataqueUI.ToString();
        resistenciaTMPRO.text = "RES: " + resistenciaUI.ToString();
    }
}
