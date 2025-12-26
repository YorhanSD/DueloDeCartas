using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Case : MonoBehaviour
{
    [SerializeField] SistemaCombate sistemaCombate;
    [SerializeField] private bool caseOcupadoPeloJogador = false;
    [SerializeField] private bool caseOcupadoPeloOponente = false;

    [SerializeField] private string nomeCartaDoJogador;
    [SerializeField] private string nomeCartaDoOponente;

    [SerializeField] private int ultimoID;

    [SerializeField] private int possicaoCasa = 0;

    Deck deck;

    [System.Obsolete]
    public void Start()
    {
        sistemaCombate = FindObjectOfType<SistemaCombate>();
        deck = FindObjectOfType<Deck>();
    }
    public void SetCasaPossicao(int _possicaoCasa)
    {
        possicaoCasa = _possicaoCasa;
    }
    public int GetPossicaoCasa()
    {
        return possicaoCasa;
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
        if (GetCaseOcupadoJogador() == false && _carta.gameObject.tag == "Card Player")
        {
            SetCaseOcupadoJogador(true);
            SetNomeCartaJogador(_carta.gameObject.name);
            //SetUltimoID(null);

            _carta.gameObject.transform.parent = this.transform;
            _carta.gameObject.transform.position = this.transform.position;

            this.gameObject.tag = "Ocupado";
        }

        if (GetCaseOcupadoOponente() == false && _carta.gameObject.tag == "Card Oponente")
        {
            SetCaseOcupadoOponente(true);
            SetNomeCartaOponente(_carta.gameObject.name);
            //SetUltimoID(null);
        }
    }
    public void OnTriggerExit2D(Collider2D _carta)
    {
        if (GetCaseOcupadoJogador() == true && _carta.gameObject.tag == "Card Player")
        {
            if (_carta.gameObject.name == GetNomeCartaJogador())
            {
                SetCaseOcupadoJogador(false);
                SetNomeCartaJogador(null);
                foreach (CartaDaCena cartaCena in sistemaCombate.listaCenaCartas)
                {
                    if (cartaCena.dados.nomeAtual == _carta.gameObject.name)
                    {
                        SetUltimoID(cartaCena.dados.ID);
                    }
                }

                this.gameObject.tag = "Slot Player";
            }
        }

        if (GetCaseOcupadoOponente() == true && _carta.gameObject.tag == "Card Oponente")
        {
            if (_carta.gameObject.name == GetNomeCartaOponente())
            {
                SetCaseOcupadoOponente(false);
                SetNomeCartaOponente(null);
                foreach (CartaDaCena cartaCena in sistemaCombate.listaCenaCartas)
                {
                    if (cartaCena.dados.nomeAtual == _carta.gameObject.name)
                    {
                        SetUltimoID(cartaCena.dados.ID);
                    }
                }
            }
        }
    }
}
