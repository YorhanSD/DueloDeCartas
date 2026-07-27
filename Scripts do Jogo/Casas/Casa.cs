using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Casa : MonoBehaviour
{
    [SerializeField] EntraESaiCartas entraESaiCartas;

    private Coroutine coroutineEntrada;

    [SerializeField] private bool cartaSobreCasa;
    [SerializeField] private bool estaBloqueado = false;
    [SerializeField] private bool caseOcupadoPeloJogador = false;
    [SerializeField] private bool caseOcupadoPeloOponente = false;
    [SerializeField] private string nomeCartaDoJogador;
    [SerializeField] private string nomeCartaDoOponente;
    [SerializeField] private int idCartaOcupante = -1;
    [SerializeField] private int posicaoCasa = 0;
    [SerializeField] private int ultimoID;

    [Obsolete]
    public void Start()
    {
        entraESaiCartas = FindObjectOfType<EntraESaiCartas>();
    }
    public void SetUltimoID(int _ID)
    {
        ultimoID = _ID;
    }
    public int GetUltimoID()
    {
        return ultimoID;
    }
    public void SetIDCartaOcupante(int _cartaID)
    {
        idCartaOcupante = _cartaID;
    }
    public int GetIDCartaOcupante()
    {
        return idCartaOcupante;
    }
    public void SetEstaBloqueado(bool _estaBloqueado)
    {
        estaBloqueado = _estaBloqueado;
    }
    public bool GetEstaBloqueado()
    {
        return estaBloqueado;
    }
    public void SetCasaPosicao(int _possicaoCasa)
    {
        posicaoCasa = _possicaoCasa;
    }
    public int GetPosicaoCasa()
    {
        return posicaoCasa;
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

    [Obsolete]
    public void OnTriggerEnter2D(Collider2D carta)
    {
        if (!carta.CompareTag("Carta Jogador") && !carta.CompareTag("Carta Oponente"))
        {
            return;
        }

        if (carta.CompareTag("Carta Jogador") || carta.CompareTag("Carta Oponente"))
        {
            CartaDaCena _carta = carta.GetComponent<CartaDaCena>();

            cartaSobreCasa = true;
            CartaEstaSobreACasa(_carta);
        }
    }
    public void OnTriggerExit2D(Collider2D carta)
    {
        if (carta.CompareTag("Carta Jogador") || carta.CompareTag("Carta Oponente"))
        {
            CartaDaCena _carta = carta.GetComponent<CartaDaCena>();

            if (_carta.GetCartaMorte() == true)
                return;
            if (_carta.GetCartaEstaAtacando() == true)
                return;

            CartaSai(_carta);
        }
    }

    [Obsolete]
    public void CartaEstaSobreACasa(CartaDaCena _cartaEntrando)
    {
        if (_cartaEntrando.CompareTag("Carta Oponente")) //Quando uma carta do oponente entra na casa e já tem uma carta do jogador então:
        {
            if (GetIDCartaOcupante() != -1 && GetCaseOcupadoJogador())
            {
                _cartaEntrando.SetCartaEstaAtacando(true);
                //combateEmAndamento = true;
                entraESaiCartas.ProcuraCartaDentroDaCasa(this.GetIDCartaOcupante(), _cartaEntrando);
            }

            /*
            CartaDaCena defensor = FindObjectOfType<Baralho>().deckJogador.Find(c => c.dados.ID == GetIDCartaOcupante());

            if (defensor != null)
            {
                combateEmAndamento = true;
                entraESaiCartas.ChamaCombate(defensor, _cartaEntrando);
            }
            */

            if (GetCaseOcupadoJogador() == false && GetCaseOcupadoOponente() == false)
            {
                //combateEmAndamento = false;
                CartaEntra(_cartaEntrando, this.transform);
            }

        }
        else if (_cartaEntrando.CompareTag("Carta Jogador")) //Quando uma carta do jogador entra na casa e já tem uma carta do oponente então:
        {
            if (GetIDCartaOcupante() != -1 && GetCaseOcupadoOponente())
            {
                _cartaEntrando.SetCartaEstaAtacando(true);
                //combateEmAndamento = true;
                entraESaiCartas.ProcuraCartaDentroDaCasa(this.GetIDCartaOcupante(), _cartaEntrando);
            }
            /*
            CartaDaCena defensor = FindObjectOfType<Baralho_Oponente>().deckOponente.Find(c => c.dados.ID == GetIDCartaOcupante());

            if (defensor != null)
            {
                combateEmAndamento = true;
                entraESaiCartas.ChamaCombate(defensor, _cartaEntrando);
            }
            */

            //CartaDaCena jogador = FindObjectOfType<Baralho>().deckJogador.Find(c => c.dados.ID == GetIDCartaOcupante());

            if (GetCaseOcupadoJogador()) //Troca
            {
                
                //combateEmAndamento = false;
                entraESaiCartas.ChamaTroca(this.GetIDCartaOcupante(), _cartaEntrando);
            }

            if (GetEstaBloqueado() == false && GetCaseOcupadoOponente() == false && GetCaseOcupadoJogador() == false)
            {
                if (coroutineEntrada == null)
                {
                    //combateEmAndamento = false;
                    coroutineEntrada = StartCoroutine(CartaEspera(_cartaEntrando));
                }
            }
        }
    }
    public IEnumerator CartaEspera(CartaDaCena _cartaEntrando)
    {
        while (!entraESaiCartas.GetVerificaSeSoltouCarta())
        {
            if (!cartaSobreCasa)
            {
                coroutineEntrada = null;
                yield break;
            }

            yield return null;
        }

        if (_cartaEntrando == null)
        {
            coroutineEntrada = null;
            yield break;
        }

        CartaEntra(_cartaEntrando, this.transform);

        coroutineEntrada = null;
    }

    public void CartaEntra(CartaDaCena _cartaEntrando, Transform _casaTransfrom)
    {
        Debug.Log($"{_cartaEntrando.dados.nome} entrou na casa.");

        _cartaEntrando.SetEstaAtivada(true); // CARTA ENTROU, ENTÃO ESTÁ ATIVA

        if (_cartaEntrando.gameObject.CompareTag("Carta Jogador"))
        {
            //entraESaiCartas.ChamaMapeamentoJogador(_cartaEntrando);

            entraESaiCartas.LiberaCasaQueEntrou(GetPosicaoCasa());

            SetCaseOcupadoJogador(true);
        }

        if (_cartaEntrando.gameObject.CompareTag("Carta Oponente"))
        {
            SetCaseOcupadoOponente(true);
        }

        SetIDCartaOcupante(_cartaEntrando.dados.ID);

        entraESaiCartas.MovimentaCartaParaCasa(_cartaEntrando,_casaTransfrom);
    }
    public void CartaSai(CartaDaCena _cartaSaindo)
    {
        if (_cartaSaindo.GetEstaAtivada())// SE ELA ESTÁ ATIVA É PORQUE ENTROU
        {
            //SE A CARTA SAI, ELA DEIXA DE SER ATIVA

            if (GetIDCartaOcupante() != _cartaSaindo.dados.ID)
            {
                Debug.Log("Ignorando CartaSai. A carta não ocupa mais esta casa.");
                return;
            }

            DesocuparCasa(_cartaSaindo);
        }
    }

    public void DesocuparCasa(CartaDaCena _cartaDestruida)
    {
        _cartaDestruida.SetEstaAtivada(false);

        if (_cartaDestruida.gameObject.CompareTag("Carta Jogador"))
        {
            SetCaseOcupadoJogador(false);
        }

        if (_cartaDestruida.gameObject.CompareTag("Carta Oponente"))
        {
            SetCaseOcupadoOponente(false);
        }

        SetIDCartaOcupante(-1);

        GravaUltimoID(_cartaDestruida.dados.ID);
    }

    public void GravaUltimoID(int _ID)
    {
        SetUltimoID(_ID);
    }
}
