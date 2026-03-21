using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public float tempoJogador;
    public TextMeshProUGUI tempoTextoJogador;
    public float tempoOponente;
    public TextMeshProUGUI tempoTextoOponente;

    void Start()
    {
        tempoJogador = 120;
        tempoOponente = 120;

        StartCoroutine(TemporizadorJogador());
    }

    void Update()
    {
        tempoTextoJogador.text = tempoJogador.ToString();
        tempoTextoOponente.text = tempoOponente.ToString();

    }

    public IEnumerator TemporizadorJogador()
    {
        for (int i = 1; 120 >= i;)
        {
            yield return new WaitForSeconds(1f);
            tempoJogador -= 1;
        }
    }

    public IEnumerator TemporizadorOponente()
    {
        for (int i = 1; 120 >= i;)
        {
            yield return new WaitForSeconds(1f);
            tempoOponente -= 1;
        }
    }
}
