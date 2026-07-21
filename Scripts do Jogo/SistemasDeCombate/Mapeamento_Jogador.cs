using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapeamento_Jogador : MonoBehaviour
{
    public Trava_Casas travaCasas;
    public BancoCards bancoCartas;
    public SistemaCombate sistemaCombate;
    public IA_MapeamentoDeCases ia_MapeamentoDeCases;

   

    private void Start()
    {
        bancoCartas = GetComponent<BancoCards>();

        sistemaCombate = GetComponent<SistemaCombate>();

        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();

        travaCasas = GetComponent<Trava_Casas>();
    }
    public void VerificaPossicaoAtualDaCartaDoJogador(int _ID)
    {
        CartaDaCena _cartaCena = bancoCartas.geralCartaCenaLista.Find(c => c.dados.ID == _ID); //USAR DADOS, EM VEZ DE: CARTABASE
        Case _casa = ia_MapeamentoDeCases.listaCase.Find(c => c.GetIDCartaOcupante() == _ID);

        if (_cartaCena == null)
        {
            Debug.LogError($"Não encontrei a carta de ID {_ID}");
            return;
        }

        if (_casa == null)
        {
            Debug.LogError($"Não encontrei uma casa com o ID {_ID}");
            return;
        }

        // A CARTA NÃO DEVE SER ATIVA, POIS SÓ PASSA A SER ATIVA, QUANDO ENTRA NO CASE.
        // SENDO ASSIM NÃO PASSARIA NA VERIFICAÇÃO DO IF.

        if (_casa.GetIDCartaOcupante() == _cartaCena.dados.ID) //ACHA A CARTA QUE POSSUI ESSE ID
        {
            MovimentosPossiveisDoJogador(_casa.GetPosicaoCasa(), _cartaCena);

            //Debug.Log($"{_cartaCena.dados.nome} com o ID: {_cartaCena.dados.ID} se encontra na casa {_casa.GetPosicaoCasa()} que guarda o ID: {_casa.GetIDCartaOcupante()}");
        }
    }
    public void MovimentosPossiveisDoJogador(int _posicaoCase, CartaDaCena _carta)
    {
        switch (_posicaoCase)
        {
            //SE ESTIVER NA CASA 7, A CARTA PODE SE MOVER ATÉ A CASA 9
            // ZONA VERMELHA NÃO PODE RECUAR

            case 7:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[7].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[9].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[7].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            case 6:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[6].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[8].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[6].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 5, A CARTA PODE SE MOVER ATÉ A CASA 7
            // ZONA VERMELHA NÃO PODE RECUAR

            case 5:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[5].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[7].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[5].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 4, A CARTA PODE SE MOVER ATÉ A CASA 6

            case 4:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[4].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[6].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[4].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 3, A CARTA PODE SE MOVER ATÉ A CASA 5
            // -1 = CASA VAZIA

            case 3:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[3].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[5].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[3].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 2, A CARTA PODE SE MOVER ATÉ A CASA 4
            // -1 = CASA VAZIA

            case 2:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[2].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[4].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[2].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 1, A CARTA PODE SE MOVER ATÉ A CASA 3
            // -1 = CASA VAZIA
            // PRIMEIRA CASA

            case 1:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[1].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[3].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[1].GetPosicaoCasa());
                    
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 0, A CARTA PODE SE MOVER ATÉ A CASA 2
            // PRIMEIRA CASA

            case 0:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[0].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[2].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[0].GetPosicaoCasa());
                    
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 8, A CARTA PODE SE MOVER ATÉ A CASA 10
            //ZONA VERMELHA NÃO PODE RECUAR

            case 8:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[8].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[10].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[8].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 9, A CARTA PODE SE MOVER ATÉ A CASA 11

            case 9:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[9].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[11].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[9].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 11, A CARTA PODE SE MOVER ATÉ A CASA 13

            case 11:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[11].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[13].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[11].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 11, A CARTA PODE SE MOVER ATÉ A CASA 13

            case 12:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[12].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[14].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[12].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 11, A CARTA PODE SE MOVER ATÉ A CASA 13
            //ULTIMA CASA

            case 13:

                if (_carta.dados.ID == ia_MapeamentoDeCases.listaCase[13].GetIDCartaOcupante() && ia_MapeamentoDeCases.listaCase[15].GetCaseOcupadoOponente() == false)
                {
                    travaCasas.BloqueiaCasas(ia_MapeamentoDeCases.listaCase[13].GetPosicaoCasa());
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;


        }
    }
}




