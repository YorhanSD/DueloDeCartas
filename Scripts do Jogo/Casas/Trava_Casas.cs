using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trava_Casas : MonoBehaviour
{
    public List<Bloqueador> listaBloqueadores = new List<Bloqueador>();
    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    //Bloqueador bloqueador;
    public GameObject[] bloqueadores;

    [System.Obsolete]
    void Start()
    {
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        //bloqueador = FindObjectOfType<Bloqueador>();
    }

    public void BloqueiaCasas(int posicaoCasa) 
    {
        for (int i = 0; i < 16; i++)
        {
            if (bloqueadores[i] != bloqueadores[posicaoCasa] && listaBloqueadores[i].GetDesativaBloqueador() == false) // Ativa todos os bloqueadores que não estão na posição a cima
            {
                listaBloqueadores[i].SetDesativaBloqueador(true);
                ia_MapeamentoDeCases.listaCase[i].SetEstaBloqueado(true);
                bloqueadores[i].SetActive(true);
            }
        }

        StartCoroutine(LiberaCasas(posicaoCasa));
    }

    public void DesbloqueiaCasa(int posicaoCasa)
    {
        bloqueadores[posicaoCasa].SetActive(false);
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
        yield return new WaitForSeconds(0.5f);

        // Se a posição da casa for um número par então:
        // Exemplo 6
        // As casas liberadas são estas:

        if (posicaoCasa % 2 == 0)
        {

            if (posicaoCasa != 14 && posicaoCasa != 15)
            {
                posicaoCasa += 2; //CASA 8
                bloqueadores[posicaoCasa].SetActive(false);
                ia_MapeamentoDeCases.listaCase[posicaoCasa].SetEstaBloqueado(false);
                //Debug.Log($"Número da casa da direita que deve ficar livre : {posicaoCasa}");
            }
            
            if (posicaoCasa != 0 && posicaoCasa != 1)
            {
                posicaoCasa -= 1; //CASA 7
                bloqueadores[posicaoCasa].SetActive(false);
                ia_MapeamentoDeCases.listaCase[posicaoCasa].SetEstaBloqueado(false);
                //Debug.Log($"Número da casa de baixo que deve ficar livre : {posicaoCasa}");
            }

            if (posicaoCasa != 0 && posicaoCasa != 1)
            {
                posicaoCasa -= 3; //CASA 4
                bloqueadores[posicaoCasa].SetActive(false);
                ia_MapeamentoDeCases.listaCase[posicaoCasa].SetEstaBloqueado(false);
                //Debug.Log($"Número da casa da esquerda que deve ficar livre : {posicaoCasa}");
            }
        }
        else if (posicaoCasa % 2 != 0)
        {
            // Se a posição da casa é um número ímpar então:
            // Exemplo 7
            // As casas liberadas são estas:


            if (posicaoCasa != 14 && posicaoCasa != 15)
            {
                posicaoCasa += 2; //CASA 9
                bloqueadores[posicaoCasa].SetActive(false);
                ia_MapeamentoDeCases.listaCase[posicaoCasa].SetEstaBloqueado(false);
                //Debug.Log($"Número da casa da direita que deve ficar livre : {posicaoCasa}");
            }
            
            if (posicaoCasa != 0 && posicaoCasa != 1)
            {
                posicaoCasa -= 3; //CASA 6
                bloqueadores[posicaoCasa].SetActive(false);
                ia_MapeamentoDeCases.listaCase[posicaoCasa].SetEstaBloqueado(false);
                //Debug.Log($"Número da casa de cima que deve ficar livre : {posicaoCasa}");
            }
            if (posicaoCasa != 0 && posicaoCasa != 1)
            {
                posicaoCasa -= 1; //CASA 5
                bloqueadores[posicaoCasa].SetActive(false);
                ia_MapeamentoDeCases.listaCase[posicaoCasa].SetEstaBloqueado(false);
                //Debug.Log($"Número da casa da esquerda que deve ficar livre : {posicaoCasa}");
            }
        }

    }
}
