using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;
using static UnityEngine.EventSystems.EventTrigger;

public class IA_MapeamentoDeCases : MonoBehaviour
{
    public List<Casa> listaCase = new List<Casa>();

    BancoCards bancoCartas;

    Baralho_Oponente baralhoOponente;

    public SistemaCombate sistemaCombate;

    int numeroDeCasas = 16;

    IA_Oponente ai_Oponente;

    public bool atacou = false;

    [System.Obsolete]
    private void Start()
    {
        baralhoOponente = GetComponent<Baralho_Oponente>();

        bancoCartas = GetComponent<BancoCards>();

        sistemaCombate = GetComponent<SistemaCombate>();

        ai_Oponente = GetComponent<IA_Oponente>();

        NumeradorDasCasas();
    }
    public void NumeradorDasCasas()
    {
        for (int i = 0; i < numeroDeCasas; i++)
        {
            listaCase[i].SetCasaPosicao(i);
        }
    }

    //VERIFICAR POSICAO DAS CASAS!

    public void MovimentosPossiveis(int _posicaoCasa, CartaDaCena _carta)
    {
        switch (_posicaoCasa)
        {
            //SE ESTIVER NA CASA 15, A CARTA PODE SE MOVER ATÉ A CASA 13

            case 15:

                if (listaCase[13].GetCaseOcupadoJogador() == false && listaCase[13].GetCaseOcupadoOponente() == false && listaCase[13].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[15].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[13]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 14, A CARTA PODE SE MOVER ATÉ A CASA 12

            case 14:

                if (listaCase[12].GetCaseOcupadoJogador() == false && listaCase[12].GetCaseOcupadoOponente() == false && listaCase[12].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[14].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[12]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 13, A CARTA PODE SE MOVER ATÉ A CASA 11

            case 13:

                if (listaCase[11].GetCaseOcupadoJogador() == false && listaCase[11].GetCaseOcupadoOponente() == false && listaCase[11].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[13].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[11]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 12, A CARTA PODE SE MOVER ATÉ A CASA 10

            case 12:

                if (listaCase[10].GetCaseOcupadoJogador() == false && listaCase[10].GetCaseOcupadoOponente() == false && listaCase[10].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[12].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[10]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 11, A CARTA PODE SE MOVER ATÉ A CASA 9

            case 11:

                if (listaCase[9].GetCaseOcupadoJogador() == false && listaCase[9].GetCaseOcupadoOponente() == false && listaCase[9].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[11].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[9]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 10, A CARTA PODE SE MOVER ATÉ A CASA 8

            case 10:

                if (listaCase[8].GetCaseOcupadoJogador() == false && listaCase[8].GetCaseOcupadoOponente() == false && listaCase[8].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[10].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[8]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 9, A CARTA PODE SE MOVER ATÉ A CASA 7

            case 9:

                if (listaCase[7].GetCaseOcupadoJogador() == false && listaCase[7].GetCaseOcupadoOponente() == false && listaCase[7].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[9].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[7]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 8, A CARTA PODE SE MOVER ATÉ A CASA 6

            case 8:

                if (listaCase[6].GetCaseOcupadoJogador() == false && listaCase[6].GetCaseOcupadoOponente() == false && listaCase[6].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[8].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[6]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 7, A CARTA PODE SE MOVER ATÉ A CASA 5

            case 7:

                if (listaCase[5].GetCaseOcupadoJogador() == false && listaCase[5].GetCaseOcupadoOponente() == false && listaCase[5].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[7].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[5]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 6, A CARTA PODE SE MOVER ATÉ A CASA 4

            case 6:

                if (listaCase[4].GetCaseOcupadoJogador() == false && listaCase[4].GetCaseOcupadoOponente() == false && listaCase[4].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[6].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[4]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 5, A CARTA PODE SE MOVER ATÉ A CASA 3

            case 5:

                if (listaCase[3].GetCaseOcupadoJogador() == false && listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[5].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[3]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 4, A CARTA PODE SE MOVER ATÉ A CASA 2

            case 4:

                if (listaCase[2].GetCaseOcupadoJogador() == false && listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[4].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[2]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 3, A CARTA PODE SE MOVER ATÉ A CASA 1

            case 3:

                if (listaCase[1].GetCaseOcupadoJogador() == false && listaCase[1].GetCaseOcupadoOponente() == false && listaCase[1].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[3].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[1]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }
                break;

            //SE ESTIVER NA CASA 2, A CARTA PODE SE MOVER ATÉ A CASA 0

            case 2:

                if (listaCase[0].GetCaseOcupadoJogador() == false && listaCase[0].GetCaseOcupadoOponente() == false && listaCase[0].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[2].GetIDCartaOcupante())
                {
                    MoverCarta(_carta, listaCase[0]);
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;
        }
    }

    public void MoverCarta(CartaDaCena carta, Casa destino, bool ataque = false)
    {
        Casa origem = listaCase.Find(c => c.GetIDCartaOcupante() == carta.dados.ID);

        if (origem == null)
        {
            Debug.LogError($"Não encontrei a casa da carta {carta.dados.ID}");
            return;
        }

        /*
        // Limpa a casa antiga
        origem.SetIDCartaOcupante(-1);
        origem.SetCaseOcupadoOponente(false);

        // Atualiza a nova
        destino.SetIDCartaOcupante(carta.dados.ID);
        destino.SetCaseOcupadoOponente(true);
        */

        origem.CartaEntra(carta, destino.transform);

        Debug.Log($"Carta {carta.dados.ID} saiu da casa {origem.GetPosicaoCasa()} e foi para {destino.GetPosicaoCasa()}");
    }

    public void AtaquesPossiveis(int _possicaoCase, CartaDaCena _carta)
    {
        switch (_possicaoCase)
        {
            //SE ESTOU NA CASA (13) E HÁ CARTA DO JOGADOR NA CASA (11), ENTÃO PODE ATACAR.
            case 13:

                if (listaCase[11].GetCaseOcupadoOponente() == false && listaCase[11].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[13].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[11], true);
                }

                break;

            //SE ESTOU NA CASA (12) E HÁ CARTA DO JOGADOR NA CASA (10), ENTÃO PODE ATACAR.
            case 12:

                if (listaCase[10].GetCaseOcupadoOponente() == false && listaCase[10].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[12].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[10], true);
                }

                break;
            //SE ESTOU NA CASA(11) E HÁ CARTA DO JOGADOR NA CASA(9), ENTÃO PODE ATACAR.
            case 11:

                if (listaCase[9].GetCaseOcupadoOponente() == false && listaCase[9].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[11].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[9], true);
                }

                break;

            //SE ESTOU NA CASA (10) E HÁ CARTA DO JOGADOR NA CASA (8), ENTÃO PODE ATACAR.
            case 10:

                if (listaCase[8].GetCaseOcupadoOponente() == false && listaCase[8].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[10].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[8], true);
                }

                break;
            //SE ESTOU NA CASA (8) E HÁ CARTA DO JOGADOR NA CASA (6), ENTÃO PODE ATACAR.
            case 8:

                if (listaCase[6].GetCaseOcupadoOponente() == false && listaCase[6].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[8].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[6], true);
                }


                break;

            //SE ESTOU NA CASA (9) E HÁ CARTA DO JOGADOR NA CASA (7), ENTÃO PODE ATACAR.
            case 9:

                if (listaCase[7].GetCaseOcupadoOponente() == false && listaCase[7].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[9].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[7], true);
                }

                break;

            //SE ESTOU NA CASA (2) E HÁ CARTA DO JOGADOR NA CASA (0), ENTÃO PODE ATACAR.
            case 2:

                if (listaCase[0].GetCaseOcupadoOponente() == false && listaCase[0].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[2].GetIDCartaOcupante())
                {


                    MoverCarta(_carta, listaCase[0], true);
                }


                break;

            //SE ESTOU NA CASA (3) E HÁ CARTA DO JOGADOR NA CASA (1), ENTÃO PODE ATACAR.
            case 3:

                if (listaCase[1].GetCaseOcupadoOponente() == false && listaCase[1].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[3].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[1], true);
                }


                break;
            //SE ESTOU NA CASA (4) E HÁ CARTA DO JOGADOR NA CASA (2), ENTÃO PODE ATACAR.
            case 4:

                if (listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[4].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[2], true);
                }


                break;

            //SE ESTOU NA CASA (5) E HÁ CARTA DO JOGADOR NA CASA (3), ENTÃO PODE ATACAR.
            case 5:

                if (listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[5].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[3], true);
                }


                break;

            //SE ESTOU NA CASA (6) E HÁ CARTA DO JOGADOR NA CASA (4), ENTÃO PODE ATACAR.
            case 6:

                if (listaCase[4].GetCaseOcupadoOponente() == false && listaCase[4].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[6].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[4], true);
                }


                break;

            //SE ESTOU NA CASA (7) E HÁ CARTA DO JOGADOR NA CASA (5), ENTÃO PODE ATACAR.
            case 7:

                if (listaCase[5].GetCaseOcupadoOponente() == false && listaCase[5].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[7].GetIDCartaOcupante())
                {

                    MoverCarta(_carta, listaCase[5], true);
                }


                break;
        }

    }

}