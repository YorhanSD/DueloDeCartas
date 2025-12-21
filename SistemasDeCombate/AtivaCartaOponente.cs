using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AtivaCartaOponente : MonoBehaviour
{
    public GameObject[] cartaOponente;

    public IEnumerator SpawnaCartas()
    {
        if(cartaOponente[0] != null && cartaOponente[1] != null && cartaOponente[2] != null)
        {
            cartaOponente[0].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            cartaOponente[1].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            cartaOponente[2].SetActive(true);
        }
        
        //Debug.Log("Spawnou");

        //Debug.Log("Get Carta Oponente : " + checaSlotsPlayer.GetCaseCardOponente().nome);
        //Debug.Log("Get Carta Player : " + checaSlotsPlayer.GetCaseCardPlayer().nome);
    }
}
