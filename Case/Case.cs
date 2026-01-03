using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Case : MonoBehaviour
{
    public CartaDaCena cartaOcupante;

    [SerializeField] SistemaCombate sistemaCombate;
    [SerializeField] BancoCards bancoCartas;

    [SerializeField] private bool caseOcupadoPeloJogador = false;
    [SerializeField] private bool caseOcupadoPeloOponente = false;

    [SerializeField] private string nomeCartaDoJogador;
    [SerializeField] private string nomeCartaDoOponente;

    [SerializeField] private int idCartaOcupante;

    [SerializeField] private int ultimoID;

    [SerializeField] private int posicaoCasa = 0;

    [System.Obsolete]
    public void Start()
    {
        idCartaOcupante = -1;
        bancoCartas = FindObjectOfType<BancoCards>();
        sistemaCombate = FindObjectOfType<SistemaCombate>();
    }
    public void SetIDCartaOcupante(int _cartaID)
    {
        idCartaOcupante = _cartaID;
    }
    public int GetIDCartaOcupante()
    {
        return idCartaOcupante;
    }
    public void SetCasaPosicao(int _possicaoCasa)
    {
        posicaoCasa = _possicaoCasa;
    }
    public int GetPosicaoCasa()
    {
        return posicaoCasa;
    }
    public void SetCaseOcupadoOponente(bool _caseOcupado)
    {
        caseOcupadoPeloOponente = _caseOcupado;
    }
    public bool GetCaseOcupadoOponente()
    {
        return caseOcupadoPeloOponente;
    }
    public void SetCaseOcupadoJogador(bool _caseOcupado)
    {
        caseOcupadoPeloJogador = _caseOcupado;
    }
    public bool GetCaseOcupadoJogador()
    {
        return caseOcupadoPeloJogador;
    }
    public void SetNomeCartaOponente(string _nomeCarta)
    {
        nomeCartaDoOponente = _nomeCarta;
    }
    public string GetNomeCartaOponente()
    {
        return nomeCartaDoOponente;
    }
    public void SetNomeCartaJogador(string _nomeCarta)
    {
        nomeCartaDoJogador = _nomeCarta;
    }
    public string GetNomeCartaJogador()
    {
        return nomeCartaDoJogador;
    }
    public void SetUltimoID(int _ID)
    {
        ultimoID = _ID;
    }
    public int GetUltimoID()
    {
        return ultimoID;
    }
    public void OnTriggerEnter2D(Collider2D _carta)
    {
        CartaDaCena cartaEntrando = _carta.GetComponent<CartaDaCena>();
        OcuparCasa(cartaEntrando);
    }
    public void OnTriggerExit2D(Collider2D _carta)
    {
        CartaDaCena cartaSaindo = _carta.GetComponent<CartaDaCena>();
        DesocuparCasa(cartaSaindo);
    }

    public void OcuparCasa(CartaDaCena _cartaEntrando)
    {
        if (_cartaEntrando == null) return;
        cartaOcupante = _cartaEntrando;

        if (cartaOcupante.CompareTag("Card Player"))
        {
            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                SetNomeCartaJogador(cartaOcupante.dados.nomeAtual);
                SetCaseOcupadoJogador(true);
                SetIDCartaOcupante(cartaOcupante.dados.ID);

                cartaOcupante.transform.SetParent(this.transform, false);
                cartaOcupante.transform.localPosition = Vector3.zero;

                this.gameObject.tag = "Ocupado";
            }
            else if (GetCaseOcupadoOponente())
            {
                SetUltimoID(cartaOcupante.dados.ID);
            }
        }
        if (_cartaEntrando.CompareTag("Card Oponente"))
        {
            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                SetNomeCartaOponente(cartaOcupante.gameObject.name);
                SetCaseOcupadoOponente(true);
                SetIDCartaOcupante(cartaOcupante.dados.ID);
            }
            else if (GetCaseOcupadoJogador())
            {
                SetUltimoID(cartaOcupante.dados.ID);
            }
        }
    }

    public void DesocuparCasa(CartaDaCena _cartaSaindo)
    {
        if (_cartaSaindo == null) return;
        cartaOcupante = _cartaSaindo;

        if (GetCaseOcupadoJogador() && cartaOcupante.CompareTag("Card Oponente")) return;

        if (GetCaseOcupadoJogador() && cartaOcupante.CompareTag("Card Player"))
        {
            SetUltimoID(cartaOcupante.dados.ID);

            this.gameObject.tag = "Slot Player";

            if (cartaOcupante == null)
            {
                //Lógica de ataque ainda funciona com base nos nomes
                //Corrigir futuramente
                //SetUltimoID(cartaOcupante.dados.ID);
                SetCaseOcupadoJogador(false);
                SetIDCartaOcupante(-1);
                SetNomeCartaJogador(null);
            }
        }

        if (GetCaseOcupadoOponente() && cartaOcupante.CompareTag("Card Player")) return;

        if (GetCaseOcupadoOponente() && cartaOcupante.CompareTag("Card Oponente"))
        {
            SetUltimoID(cartaOcupante.dados.ID);

            if (cartaOcupante == null)
            {
                //Lógica de ataque ainda funciona com base nos nomes
                //Corrigir futuramente
                //SetUltimoID(cartaOcupante.dados.ID);
                SetCaseOcupadoOponente(false);
                SetIDCartaOcupante(-1);
                SetNomeCartaOponente(null);
            }
        }

    }
}
