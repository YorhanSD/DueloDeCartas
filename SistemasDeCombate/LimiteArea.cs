using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteArea : MonoBehaviour
{
    public GameObject area;

    private void OnTriggerEnter2D(Collider2D cardOponente)
    {
        if (cardOponente.gameObject.tag == "Card Oponente")
        {
            area.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D cardOponente)
    {
        if (cardOponente.gameObject.tag == "Card Oponente")
        {
            area.SetActive(false);
        }
    }
}
