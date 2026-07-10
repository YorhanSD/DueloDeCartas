using System.Collections;
using UnityEngine;

public class Trava_Casas : MonoBehaviour
{
    IA_MapeamentoDeCases ia_MapeamentoDeCases;
    public GameObject[] bloqueadores;

    void Start()
    {
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
    }

    public void BloqueiaCasas(int posicaoCasa) 
    {
        for (int i = 0; i < 16; i++)
        {
            if (bloqueadores[i] != bloqueadores[posicaoCasa])
            {
                bloqueadores[i].SetActive(true);
            }
        }

        StartCoroutine(LiberaCasas(posicaoCasa));
        
    }

    public void ResetaCasas()
    {
        for (int i = 0; i < 16; i++)
        {

        bloqueadores[i].SetActive(false);
            
        }
    }

    public IEnumerator LiberaCasas(int posicaoCasa)
    {
        Debug.Log($"Número da casa, onde você colocou o Card : {posicaoCasa}");
        yield return new WaitForSeconds(1);

        // Se a posição da casa for um número par então:
        // Exemplo 4
        // As casas liberadas são estas:

        if (posicaoCasa % 2 == 0)
        {
            posicaoCasa += 2; //CASA 6
            bloqueadores[posicaoCasa].SetActive(false);
            Debug.Log($"Número da casa da direita que deve ficar livre : {posicaoCasa}");

            posicaoCasa -= 1; //CASA 5
            bloqueadores[posicaoCasa].SetActive(false);
            Debug.Log($"Número da casa de baixo que deve ficar livre : {posicaoCasa}");

            posicaoCasa -= 3; //CASA 2
            bloqueadores[posicaoCasa].SetActive(false);
            Debug.Log($"Número da casa da esquerda que deve ficar livre : {posicaoCasa}");
        }
        else
        {
            // Se a posição da casa é um número ímpar então:
            // Exemplo 5
            // As casas liberadas são estas:

            posicaoCasa += 2; //CASA 7
            bloqueadores[posicaoCasa].SetActive(false);
            Debug.Log($"Número da casa da direita que deve ficar livre : {posicaoCasa}");

            posicaoCasa -= 3; //CASA 4
            bloqueadores[posicaoCasa].SetActive(false);
            Debug.Log($"Número da casa de cima que deve ficar livre : {posicaoCasa}");

            posicaoCasa -= 1; //CASA 3
            bloqueadores[posicaoCasa].SetActive(false);
            Debug.Log($"Número da casa da esquerda que deve ficar livre : {posicaoCasa}");
        }

    }
}
