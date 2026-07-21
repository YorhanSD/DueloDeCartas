using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Case : MonoBehaviour
{
    [HideInInspector] private CartaDaCena cartaOcupante;

    [SerializeField] private bool estaBloqueado = false;

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

    Trava_Casas travaCasas;

    [System.Obsolete]
    public void Start()
    {
        idCartaOcupante = -1;
        bancoCartas = FindObjectOfType<BancoCards>();
        sistemaCombate = FindObjectOfType<SistemaCombate>();
        ia_MapeamentoDeCases = FindObjectOfType<IA_MapeamentoDeCases>();
        mapeamentoJogador = FindObjectOfType<Mapeamento_Jogador>();
        travaCasas = FindObjectOfType<Trava_Casas>();
    }
    public void SetEstaBloqueado(bool _estaBloqueado)
    {
        estaBloqueado = _estaBloqueado;
    }
    public bool GetEstaBloqueado()
    {
        return estaBloqueado;
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
        if (_carta.gameObject.tag == null)
            return;

        if (_carta.CompareTag("Carta Jogador") || _carta.CompareTag("Carta Oponente"))
        {
            OcuparCasa(_carta.GetComponent<CartaDaCena>());
        }
    }
    public void OnTriggerExit2D(Collider2D _carta)
    {
        if (_carta.gameObject.tag == null)
            return;

        if (_carta.CompareTag("Carta Jogador") || _carta.CompareTag("Carta Oponente"))
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

        if (_cartaEntrando.CompareTag("Carta Oponente")) //Quando uma carta do oponente entra na casa e já tem uma carta do jogador então:
        {
            if (GetCaseOcupadoJogador() == true)
            {
                sistemaCombate.UmContraUm(cartaOcupante.dados.ID, _cartaEntrando.dados.ID);
                return;
            }

            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                SetCaseOcupadoOponente(true);
                SetIDCartaOcupante(cartaOcupante.dados.ID);

                _cartaEntrando.SetEstaAtivada(true);
            }

        }
        else if (_cartaEntrando.CompareTag("Carta Jogador")) //Quando uma carta do jogador entra na casa e já tem uma carta do oponente então:
        {
            if (GetCaseOcupadoOponente() == true)
            {
                sistemaCombate.UmContraUm(cartaOcupante.dados.ID, _cartaEntrando.dados.ID);
                Debug.Log($"Carta entrando: {_cartaEntrando.dados.nome}");
                Debug.Log($"Carta que já está na casa: {cartaOcupante.dados.nome}");
                return;
            }

            if (GetEstaBloqueado() == false)
            {
                if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
                {
                    SetCaseOcupadoJogador(true);
                    SetIDCartaOcupante(cartaOcupante.dados.ID);

                    if (cartaOcupante != null)
                    {
                        mapeamentoJogador.VerificaPossicaoAtualDaCartaDoJogador(cartaOcupante.dados.ID);
                    }

                    travaCasas.BloqueiaCasas(GetPosicaoCasa());

                    _cartaEntrando.transform.SetParent(this.transform, false);
                    _cartaEntrando.transform.localPosition = Vector3.zero;

                    _cartaEntrando.SetMoveuSe(true);
                    _cartaEntrando.SetEstaAtivada(true);
                }
            }
        }
    }
    public IEnumerator esperaCalculoDeDano(CartaDaCena _cartaEntrando)
    {
        yield return new WaitForSeconds(0.1f);

        if (cartaOcupante == null)
        {
            cartaOcupante = _cartaEntrando;
        }

        if (GetEstaBloqueado() == false)
        {
            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                SetCaseOcupadoJogador(true);
                SetIDCartaOcupante(cartaOcupante.dados.ID);

                if (cartaOcupante != null)
                {
                    mapeamentoJogador.VerificaPossicaoAtualDaCartaDoJogador(cartaOcupante.dados.ID);
                }

                travaCasas.BloqueiaCasas(GetPosicaoCasa());

                _cartaEntrando.transform.SetParent(this.transform, false);
                _cartaEntrando.transform.localPosition = Vector3.zero;

                _cartaEntrando.SetMoveuSe(true);
                _cartaEntrando.SetEstaAtivada(true);
            }
        }
        /*
        else if (_cartaEntrando.CompareTag("Carta Oponente"))
        {
            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                SetCaseOcupadoOponente(true);
                SetIDCartaOcupante(cartaOcupante.dados.ID);

                _cartaEntrando.SetEstaAtivada(true);
            }
        }
        */
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
    }
    public void SetCartaOcupante(CartaDaCena carta)
    {
        cartaOcupante = carta;
    }
}
