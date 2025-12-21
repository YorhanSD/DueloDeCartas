using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlePontos : MonoBehaviour
{
    public int pontos;
    public TextMeshProUGUI textoPontos;

    void Start()
    {
        pontos = 0;
    }

    void Update()
    {
        textoPontos.text = pontos.ToString();
    }

    public void AdicionaPontos(int _pontos)
    {
        pontos += _pontos;
    }
}
