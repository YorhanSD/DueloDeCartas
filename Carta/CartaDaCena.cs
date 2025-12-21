using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CartaDaCena : MonoBehaviour
{
    private Case slot;

    //public Vector3 posicaoCarta;

    //public enum Personagem {Mya = 0, McDino, Hekaib};
    //public enum Arquetipo {Magico = 0, Natural, Espacial, Extinto, Tenebroso};
    //public enum Tipo {Combatente = 0, Produtor, Defesa};
    //public enum Funcao {Atacante = 0, Defensor = 1, Neutro = 2};

    private bool acoplado;

    public bool ativo = false;

    public bool podeAtacar = true;

    [SerializeField] private bool moveuSe = false;
    
    //private void OnTriggerEnter2D(Collider2D _collider)
    //{
        //if (_collider.gameObject.tag == "Slot Player" && this.gameObject.tag == "Card Player")
        //{
            //ativo = !ativo;
            //moveuSe = true;
        //}

        //if (_collider.gameObject.tag == "Baralho" && this.gameObject.tag == "Card Player")
        //{
            //moveuSe = false;
            //ativo = false;
        //}
    //}
    
    //private void OnTriggerExit2D(Collider2D _collider)
    //{
        //if (_collider.gameObject.tag == "Slot Player" && this.gameObject.tag == "Card Player")
        //{
            //ativo = !ativo;
        //}
    //}

    private void Update()
    {
        //if (vida <= 0)
        //{
            //Destroy(gameObject);
            //this.gameObject.SetActive(false);
            //ativo = false;
            //moveuSe = false;
        //}
    }
 
    public bool GetMoveuSe()
    {
        return moveuSe;
    }
    public void SetMoveuSe(bool _moveuSe)
    {
        moveuSe = _moveuSe;
    }
}
