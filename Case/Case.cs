using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Case : MonoBehaviour
{
    //[SerializeField] int caseID = 0;
    [SerializeField] private bool caseOcupadoPeloJogador = false;
    [SerializeField] private bool caseOcupadoPeloOponente = false;

    [SerializeField] private string nomeCartaDoJogador;
    [SerializeField] private string nomeCartaDoOponente;

    [SerializeField] private string ultimoCard;

    [SerializeField] private int possicaoCasa = 0;

    [SerializeField] Energia energia;

    [SerializeField] Mapeamento_Jogador mapeamentoJogador;

    Deck deck;

    public void Start()
    {
        deck = FindObjectOfType<Deck>();
        energia = FindObjectOfType<Energia>();
        mapeamentoJogador = FindObjectOfType<Mapeamento_Jogador>();
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

    public void SetUltimoCard(string _nome)
    {
        ultimoCard = _nome;
    }

    public string GetUltimoCard()
    {
        return ultimoCard;
    }
    public void OnTriggerEnter2D(Collider2D _carta)
    {
        if (GetCaseOcupadoJogador() == false && _carta.gameObject.tag == "Card Player")
        {
            SetCaseOcupadoJogador(true);
            SetNomeCartaJogador(_carta.gameObject.name);
            SetUltimoCard(null);

            _carta.gameObject.transform.parent = this.transform;
            _carta.gameObject.transform.position = this.transform.position;

            //this.gameObject.tag = "Ocupado";

            //mapeamentoJogador.VerificaPossicaoAtualDaCartaDoJogador(GetNomeCartaJogador());

            energia.RetiraEnergiaJogador(30);

            foreach (Card carta in deck.geralCardList)
            {
                if (carta.nome == _carta.gameObject.name)
                {
                    //Debug.Log("Nome da Carta no Deck: " + carta.nome + " Nome do Coringa: " + _cardNome);

                    carta.SetMoveuSe(true);
                }
            }

            //energia.TiraEnergia(10);
        }

        //if(GetCaseOcupado() == true && carta.gameObject.tag == "Card Player")
        //{
            //if (carta.gameObject.name != GetUltimoCard())
            //{
                //SetCaseOcupado(true);
                //SetNomeCarta(carta.name);
            //}
        //}

        if (GetCaseOcupadoOponente() == false && _carta.gameObject.tag == "Card Oponente")
        {
            SetCaseOcupadoOponente(true);
            //SetCaseOcupadoJogador(false);
            SetNomeCartaOponente(_carta.gameObject.name);
            SetUltimoCard(null);

            energia.RetiraEnergiaOponente(30);

            //carta.gameObject.transform.parent = this.transform;
            //carta.gameObject.transform.position = this.transform.position;
        }
    }
    public void OnTriggerExit2D(Collider2D carta)
    {
        if (GetCaseOcupadoJogador() == true && carta.gameObject.tag == "Card Player")
        {
            if (carta.gameObject.name == GetNomeCartaJogador())
            {
                SetCaseOcupadoJogador(false);
                SetNomeCartaJogador(null);
                SetUltimoCard(carta.gameObject.name);

                //this.gameObject.tag = "Slot Player";
            }
        }

        if (GetCaseOcupadoOponente() == true && carta.gameObject.tag == "Card Oponente")
        {
            if (carta.gameObject.name == GetNomeCartaOponente())
            {
                SetCaseOcupadoOponente(false);
                SetNomeCartaOponente(null);
                SetUltimoCard(carta.gameObject.name);
            }
        }


        //if (GetCaseOcupado() == false && carta.gameObject.tag == "Card Player" || carta.gameObject.tag == "Card Oponente")
        //{
        //SetCaseOcupado(true);
        //SetNomeCarta(carta.gameObject.name);
        //SetUltimoCard(null);

        //carta.gameObject.transform.parent = this.transform;
        //carta.gameObject.transform.position = this.transform.position;
        //}

        //if (GetCaseOcupado() == true && carta.gameObject.tag == "Card Oponente")
        //{
        //SetCaseOcupado(false);
        //SetNomeCarta(null);
        //SetUltimoCard(carta.gameObject.name);
        //}
    }
}
