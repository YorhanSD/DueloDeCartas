using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Case : MonoBehaviour
{
    [HideInInspector] private CartaDaCena cartaOcupante;

    [SerializeField] IA_MapeamentoDeCases ia_MapeamentoDeCases;
    [SerializeField] Mapeamento_Jogador mapeamentoJogador;

    [SerializeField] SistemaCombate sistemaCombate;
    [SerializeField] BancoCards bancoCartas;

    [SerializeField] private bool caseOcupadoPeloJogador = false;
    [SerializeField] private bool caseOcupadoPeloOponente = false;

    [SerializeField] private string nomeCartaDoJogador;
    [SerializeField] private string nomeCartaDoOponente;

    [SerializeField] private int idCartaOcupante;

    [SerializeField] private int ultimoID;

    [SerializeField] private int posicaoCasa = 0;

    //private int gravaID;

    [System.Obsolete]
    public void Start()
    {
        idCartaOcupante = -1;
        bancoCartas = FindObjectOfType<BancoCards>();
        sistemaCombate = FindObjectOfType<SistemaCombate>();
        ia_MapeamentoDeCases = FindObjectOfType<IA_MapeamentoDeCases>();
        mapeamentoJogador = FindObjectOfType<Mapeamento_Jogador>();
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
        if (_carta.CompareTag("Card Player") || _carta.CompareTag("Card Oponente"))
        {
            OcuparCasa(_carta.GetComponent<CartaDaCena>());
        }
    }
    public void OnTriggerExit2D(Collider2D _carta)
    {
        if (_carta.CompareTag("Card Player") || _carta.CompareTag("Card Oponente"))
        {
            DesocuparCasa(_carta.GetComponent<CartaDaCena>());
        }
    }

    public void OcuparCasa(CartaDaCena _cartaEntrando)
    {
        if (cartaOcupante == null)
        {
            cartaOcupante = _cartaEntrando;
        }

        if (_cartaEntrando.CompareTag("Card Player"))
        {
            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                SetCaseOcupadoJogador(true);
                SetIDCartaOcupante(cartaOcupante.dados.ID);

                if (cartaOcupante != null)
                {
                    mapeamentoJogador.VerificaPossicaoAtualDaCartaDoJogador(cartaOcupante.dados.ID);
                }

                _cartaEntrando.transform.SetParent(this.transform, false);
                _cartaEntrando.transform.localPosition = Vector3.zero;

                _cartaEntrando.SetMoveuSe(true);
                _cartaEntrando.SetEstaAtivada(true);
            }
        }
        else if (_cartaEntrando.CompareTag("Card Oponente"))
        {
            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                //if (cartaOcupante == null)
                //{
                    //cartaOcupante = _cartaEntrando;
                //}
                //else if (cartaOcupante != _cartaEntrando)
                //{
                    //sistemaCombate.UmContraUm(cartaOcupante.dados.ID, _cartaEntrando.dados.ID);
                //}

                SetCaseOcupadoOponente(true);
                SetIDCartaOcupante(cartaOcupante.dados.ID);

                _cartaEntrando.SetEstaAtivada(true);
            }
        }

        if (_cartaEntrando.CompareTag("Card Oponente")) //Quando uma carta do oponente entra na casa e já tem uma carta do jogador então:
        {
            if (GetCaseOcupadoJogador() == true)
            {
                sistemaCombate.UmContraUm(cartaOcupante.dados.ID, _cartaEntrando.dados.ID);
            }
        }
        else if (_cartaEntrando.CompareTag("Card Player")) //Quando uma carta do jogador entra na casa e já tem uma carta do oponente então:
        {
            if (GetCaseOcupadoOponente() == true)
            {
                sistemaCombate.UmContraUm(cartaOcupante.dados.ID, _cartaEntrando.dados.ID);
            }
        }
    }

    public void DesocuparCasa(CartaDaCena _cartaSaindo)
    {
        if (cartaOcupante == null) return;

        // se a carta que está saindo não é mais a ocupante, ignore
        if (_cartaSaindo != cartaOcupante)
            return;

        cartaOcupante = null;

        SetCaseOcupadoJogador(false);
        SetCaseOcupadoOponente(false);

        SetIDCartaOcupante(-1);

        SetUltimoID(_cartaSaindo.dados.ID);

        //Debug.Log("Casa liberada");

        /*
        if (_cartaSaindo.CompareTag("Card Player"))
        {
            if (_cartaSaindo.dados.ID == GetIDCartaOcupante() && GetCaseOcupadoJogador() == false)
            {
                cartaOcupante = null;
                SetCaseOcupadoJogador(false);
                SetIDCartaOcupante(-1);
            }
        }
        else if(_cartaSaindo.CompareTag("Card Oponente"))
        {
            if (_cartaSaindo.dados.ID == GetIDCartaOcupante() && GetCaseOcupadoOponente() == false)
            {
                cartaOcupante = null;
                SetCaseOcupadoOponente(false);
                SetIDCartaOcupante(-1);
            }
        }
        */
    }
    public void SetCartaOcupante(CartaDaCena carta)
    {
        cartaOcupante = carta;
    }
}
