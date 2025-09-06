using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int ID;

    public string nome;

    public int vida;

    public int ataque;

    public int resistencia;

    public Vector3 posicaoCarta;
    public enum Tipo {magico, natural, espacial, extinto}

    public bool cardAtivo;

    private void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
            cardAtivo = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D _card)
    {
        if (_card.gameObject.tag.Equals("Slot Player") && gameObject.tag == "Card Player")
        {
            this.transform.parent = _card.transform;
            this.transform.position = _card.transform.position;

            posicaoCarta = _card.transform.position;
        }
    }
}
