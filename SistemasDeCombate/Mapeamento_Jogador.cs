using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapeamento_Jogador : MonoBehaviour
{
    BancoCards bancoCartas;

    SistemaCombate sistemaCombate;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    Deck deck;

    private void Start()
    {
        bancoCartas = GetComponent<BancoCards>();

        sistemaCombate = GetComponent<SistemaCombate>();

        deck = GetComponent<Deck>();

        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
    }
    public void VerificaPossicaoAtualDaCartaDoJogador(string _nome)
    {
        foreach (Case casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetNomeCartaJogador() == _nome)
            {
                foreach (CartaDaCena cartaCena in bancoCartas.geralCartaCenaLista)
                {
                    // A CARTA NÃO DEVE SER ATIVA, POIS SÓ PASSA A SER ATIVA, QUANDO ENTRA NO CASE.
                    // SENDO ASSIM NÃO PASSARIA NA VERIFICAÇÃO DO IF.

                    if (cartaCena.dados.nomeAtual == _nome)
                    {
                       
                        //MovimentosPossiveisDoJogador(casa.GetPossicaoCasa(), cartaCena);
                    }
                }
            }
        }
    }
    public void MovimentosPossiveisDoJogador(int _possicaoCase, CartaDaCena _carta)
    {
        switch (_possicaoCase)
        {
            case 12:

                if (ia_MapeamentoDeCases.listaCase[14].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[15].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 13:


                if (ia_MapeamentoDeCases.listaCase[14].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[15].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 10:

                if (ia_MapeamentoDeCases.listaCase[12].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[13].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 11:

                if (ia_MapeamentoDeCases.listaCase[12].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[13].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 8:

                if (ia_MapeamentoDeCases.listaCase[10].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[11].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 9:

                if (ia_MapeamentoDeCases.listaCase[10].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[11].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 0:

                if (ia_MapeamentoDeCases.listaCase[8].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[9].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 1:

                if (ia_MapeamentoDeCases.listaCase[8].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[9].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 2:

                if (ia_MapeamentoDeCases.listaCase[0].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[1].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 3:

                if (ia_MapeamentoDeCases.listaCase[0].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[1].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 4:

                if (ia_MapeamentoDeCases.listaCase[2].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[3].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;

            case 5:

                if (ia_MapeamentoDeCases.listaCase[2].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }
                else if (ia_MapeamentoDeCases.listaCase[3].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.SetPodeAtacar(true);
                    _carta.SetMoveuSe(true);
                }

                break;
        }


    }
}
