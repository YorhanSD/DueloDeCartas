using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class IA_MapeamentoDeCases : MonoBehaviour
{
    public List<Case> listaCase = new List<Case>();

    BancoCards bancoCartas;

    Baralho_Oponente baralhoOponente;

    public SistemaCombate sistemaCombate;

    public Trava_Casas travaCasas;

    int numeroDeCasas = 16;

    IA_Oponente ai_Oponente;

    public bool atacou = false; 

    [System.Obsolete]
    private void Start()
    {
        travaCasas = GetComponent<Trava_Casas>();

        baralhoOponente = GetComponent<Baralho_Oponente>();

        bancoCartas = GetComponent<BancoCards>();

        sistemaCombate = FindObjectOfType<SistemaCombate>();

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
    public void VerificaPosicaoAtualDaCarta(int _IDCartaOponente)
    {
        CartaDaCena _cartaOponente = baralhoOponente.deckOponente.Find(c => c.dados.ID == _IDCartaOponente);
        Case _casa = listaCase.Find(c => c.GetIDCartaOcupante() == _IDCartaOponente);

        if (_casa != null && _cartaOponente != null)
        {
            if (_casa.GetIDCartaOcupante() == _IDCartaOponente)
            {
                Debug.Log($"A carta: {_cartaOponente.dados.nome} se encontra na casa {_casa.GetPosicaoCasa()}");

                if (_cartaOponente.GetMoveuSe() == false)
                {
                    MovimentosPossiveis(_casa.GetPosicaoCasa(), _cartaOponente);
                }

                if (_cartaOponente.GetPodeAtacar() == true)
                {
                    AtaquesPossiveis(_casa.GetPosicaoCasa(), _cartaOponente);
                }
                
            }
            else
            {
                Debug.Log($"Não foram encontrados movimentos possíveis!");
            }
        }


    }

    //VERIFICAR POSICAO DAS CASAS!
    public void MovimentosPossiveis(int _posicaoCasa, CartaDaCena _carta)
    {
        switch (_posicaoCasa)
        {
            //SE ESTIVER NA CASA 13, A CARTA PODE SE MOVER ATÉ A CASA 11
            case 13:

                if (listaCase[11].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[13].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[11].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;
                    

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[11].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;
            //SE ESTIVER NA CASA 12, A CARTA PODE SE MOVER ATÉ A CASA 10
            case 12:

                if (listaCase[10].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[12].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[10].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[10].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 10, A CARTA PODE SE MOVER ATÉ A CASA 8
            case 10:

                if (listaCase[8].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[10].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[8].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[8].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 11, A CARTA PODE SE MOVER ATÉ A CASA 9
            case 11:

                if (listaCase[9].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[11].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[9].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[9].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 8, A CARTA PODE SE MOVER ATÉ A CASA 6
            case 8:

                if (listaCase[6].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[8].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[6].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[6].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 9, A CARTA PODE SE MOVER ATÉ A CASA 7
            case 9:

                if (listaCase[7].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[9].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[7].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[7].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //ULTIMA CASA
            //SE ESTIVER NA CASA 0, NÃO PODE MAIS AVANÇAR

            //case 0:

                //if (listaCase[2].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[0].GetIDCartaOcupante())
                //{
                    //_carta.transform.SetParent(listaCase[2].gameObject.transform, false);
                    //_carta.transform.localPosition = Vector3.zero;

                    //_carta.SetMoveuSe(true);

                    //Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[2].GetPosicaoCasa()}");
                //}
                //else
                //{
                    //Debug.Log($"{_carta.gameObject} não pode se mover!");
                //}

                //break;

            //ULTIMA CASA
            //SE ESTIVER NA CASA 1, NÃO PODE MAIS AVANÇAR

            //case 1:

                //if (listaCase[3].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[1].GetIDCartaOcupante())
                //{
                    //_carta.transform.SetParent(listaCase[3].gameObject.transform, false);
                    //_carta.transform.localPosition = Vector3.zero;

                    //_carta.SetMoveuSe(true);

                    //Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[3].GetPosicaoCasa()}");
                //}
                //else
                //{
                    //Debug.Log($"{_carta.gameObject} não pode se mover!");
                //}

                //break;

            //SE ESTIVER NA CASA 2, A CARTA PODE SE MOVER ATÉ A CASA 0

            case 2:

                if (listaCase[0].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[2].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[0].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[0].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 3, A CARTA PODE SE MOVER ATÉ A CASA 1

            case 3:

                if (listaCase[1].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[3].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[1].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[1].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }
                break;

            //SE ESTIVER NA CASA 4, A CARTA PODE SE MOVER ATÉ A CASA 2

            case 4:

                if (listaCase[2].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[4].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[2].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[2].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;

            //SE ESTIVER NA CASA 5, A CARTA PODE SE MOVER ATÉ A CASA 3

            case 5:

                if (listaCase[3].GetIDCartaOcupante() == -1 && _carta.dados.ID == listaCase[5].GetIDCartaOcupante())
                {
                    _carta.transform.SetParent(listaCase[3].gameObject.transform, false);
                    _carta.transform.localPosition = Vector3.zero;

                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[3].GetPosicaoCasa()}");
                }
                else
                {
                    Debug.Log($"{_carta.gameObject} não pode se mover!");
                }

                break;
        }
    }
    public void AtaquesPossiveis(int _possicaoCase, CartaDaCena _carta)
    {
        switch (_possicaoCase)
        {
            //SE ESTOU NA CASA (13) E HÁ CARTA DO JOGADOR NA CASA (11), ENTÃO PODE ATACAR.
            case 13:

                if (listaCase[11].GetCaseOcupadoOponente() == false && listaCase[11].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[13].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[11]);
                }

                break;

            //SE ESTOU NA CASA (12) E HÁ CARTA DO JOGADOR NA CASA (10), ENTÃO PODE ATACAR.
            case 12:

                if (listaCase[10].GetCaseOcupadoOponente() == false && listaCase[10].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[12].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[10]);
                }

                break;
            //SE ESTOU NA CASA(11) E HÁ CARTA DO JOGADOR NA CASA(9), ENTÃO PODE ATACAR.
            case 11:

                if (listaCase[9].GetCaseOcupadoOponente() == false && listaCase[9].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[11].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[9]);
                }

                break;

            //SE ESTOU NA CASA (10) E HÁ CARTA DO JOGADOR NA CASA (8), ENTÃO PODE ATACAR.
            case 10:

                if (listaCase[8].GetCaseOcupadoOponente() == false && listaCase[8].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[10].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[8]);
                }
               
                break;
            //SE ESTOU NA CASA (8) E HÁ CARTA DO JOGADOR NA CASA (6), ENTÃO PODE ATACAR.
            case 8:

                if (listaCase[6].GetCaseOcupadoOponente() == false && listaCase[6].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[8].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[6]);
                }
                

                break;

            //SE ESTOU NA CASA (9) E HÁ CARTA DO JOGADOR NA CASA (7), ENTÃO PODE ATACAR.
            case 9:

                if (listaCase[7].GetCaseOcupadoOponente() == false && listaCase[7].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[9].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[7]);
                }
                
                break;

            //SE ESTOU NA CASA (0)
            //ULTIMA CASA

            //case 0:

                //if (listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[0].GetIDCartaOcupante())
                //{
                   //ai_Oponente.Ataque();
                //}
               

                //break;

            //SE ESTOU NA CASA (1)
            //ULTIMA CASA

            //case 1:

                //if (listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[1].GetIDCartaOcupante())
                //{
                    //ai_Oponente.Ataque();
                //}
                

                //break;

            //SE ESTOU NA CASA (2) E HÁ CARTA DO JOGADOR NA CASA (0), ENTÃO PODE ATACAR.
            case 2:

                if (listaCase[0].GetCaseOcupadoOponente() == false && listaCase[0].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[2].GetIDCartaOcupante())
                {

                    ai_Oponente.Ataque(_carta, listaCase[0]);
                }
               

                break;

            //SE ESTOU NA CASA (3) E HÁ CARTA DO JOGADOR NA CASA (1), ENTÃO PODE ATACAR.
            case 3:

                if (listaCase[1].GetCaseOcupadoOponente() == false && listaCase[1].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[3].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[1]);
                }
                

                break;
            //SE ESTOU NA CASA (4) E HÁ CARTA DO JOGADOR NA CASA (2), ENTÃO PODE ATACAR.
            case 4:

                if (listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[4].GetIDCartaOcupante())
                {

                    ai_Oponente.Ataque(_carta, listaCase[2]);
                }
                

                break;

            //SE ESTOU NA CASA (5) E HÁ CARTA DO JOGADOR NA CASA (3), ENTÃO PODE ATACAR.
            case 5:

                if (listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false && _carta.dados.ID == listaCase[5].GetIDCartaOcupante())
                {
                    ai_Oponente.Ataque(_carta, listaCase[3]);
                }
                

                break;
        }

    }

}