using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardProdutor : MonoBehaviour
{
    public float tempoProducao = 30;
    public TextMeshProUGUI textoProducao;

    Energia energia;

    [System.Obsolete]
    void Start()
    {
        tempoProducao = 30;
        StartCoroutine(recarregaEnergia());
        energia = FindObjectOfType<Energia>();
    }

    public void Update()
    {
        textoProducao.text = tempoProducao.ToString();
    }

    public IEnumerator recarregaEnergia()
    {
        for (int i = 0; i < tempoProducao;)
        {
            yield return new WaitForSeconds(1);

            tempoProducao--;
        }

        energia.AdicionaEnergiaJogador(20);
        energia.AdicionaEnergiaOponente(20);

        resetaCiclo();
    }

    public void resetaCiclo()
    {
        tempoProducao = 30;
        StartCoroutine(recarregaEnergia());
    }
}
