using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_MapeamentoDeCases : MonoBehaviour
{
    public List<Case> listaCase = new List<Case>();

    SistemaCombate sistemaCombate;
    Deck deck;

    int numeroDeCasas = 16;

    IA_Oponente ai_Oponente;

    [System.Obsolete]
    private void Start()
    {
        sistemaCombate = FindObjectOfType<SistemaCombate>();

        deck = GetComponent<Deck>();

        ai_Oponente = GetComponent<IA_Oponente>();

        for (int i = 0; i < numeroDeCasas; i++)
        {
            listaCase[i].SetCasaPossicao(i);
        }
    }
    public void VerificaPosicaoAtualDaCarta(CartaDaCena _cardOponente)
    {
        foreach (Case casa in listaCase)
        {
            if (casa.GetNomeCartaOponente() == _cardOponente.dados.nomeAtual)
            {
                foreach (CartaDaCena cartaCena in sistemaCombate.listaCenaCartas)
                {
                    if (cartaCena.dados.nomeAtual == _cardOponente.dados.nomeAtual)
                    {
                        
                        MovimentosPossiveis(casa.GetPossicaoCasa(), cartaCena);

                        AtaquesPossiveis(casa.GetPossicaoCasa(), cartaCena);
                    }
                }
            }
        }
    }

    public void MovimentosPossiveis(int _possicaoCase, CartaDaCena _carta)
    {
        switch (_possicaoCase)
        {
            case 12:

                if (listaCase[10].GetCaseOcupadoOponente() == false && listaCase[10].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[10].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[10].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[10].GetPossicaoCasa()}");
                }
                else if (listaCase[11].GetCaseOcupadoOponente() == false && listaCase[11].GetCaseOcupadoJogador() == false
                    && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[11].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[11].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[11].GetPossicaoCasa()}");
                }

                break;

            case 13:

                if (listaCase[10].GetCaseOcupadoOponente() == false && listaCase[10].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[10].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[10].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[10].GetPossicaoCasa()}");
                }
                else if (listaCase[11].GetCaseOcupadoOponente() == false && listaCase[11].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[11].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[11].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[11].GetPossicaoCasa()}");
                }

                break;

            case 10:

                if (listaCase[8].GetCaseOcupadoOponente() == false && listaCase[8].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[8].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[8].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);


                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[8].GetPossicaoCasa()}");
                }
                else if (listaCase[9].GetCaseOcupadoOponente() == false && listaCase[9].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[9].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[9].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[9].GetPossicaoCasa()}");
                }

                break;

            case 11:

                if (listaCase[8].GetCaseOcupadoOponente() == false && listaCase[8].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[8].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[8].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[8].GetPossicaoCasa()}");
                }
                else if (listaCase[9].GetCaseOcupadoOponente() == false && listaCase[9].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[9].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[9].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[9].GetPossicaoCasa()}");
                }

                break;

            case 8:

                if (listaCase[0].GetCaseOcupadoOponente() == false && listaCase[0].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[0].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[0].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[0].GetPossicaoCasa()}");
                }
                else if (listaCase[1].GetCaseOcupadoOponente() == false && listaCase[1].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[1].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[1].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[1].GetPossicaoCasa()}");
                }

                break;

            case 9:

                if (listaCase[0].GetCaseOcupadoOponente() == false && listaCase[0].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[0].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[0].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[0].GetPossicaoCasa()}");
                }
                else if (listaCase[1].GetCaseOcupadoOponente() == false && listaCase[1].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[1].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[1].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[1].GetPossicaoCasa()}");
                }

                break;

            case 0:

                if (listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[2].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[2].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);


                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[2].GetPossicaoCasa()}");
                }
                else if (listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[3].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[3].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[3].GetPossicaoCasa()}");
                }

                break;

            case 1:

                if (listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[2].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[2].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[2].GetPossicaoCasa()}");
                }
                else if (listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[3].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[3].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);


                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[3].GetPossicaoCasa()}");
                }

                break;

            case 2:

                if (listaCase[4].GetCaseOcupadoOponente() == false && listaCase[4].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[4].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[4].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);



                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[4].GetPossicaoCasa()}");
                }
                else if (listaCase[5].GetCaseOcupadoOponente() == false && listaCase[5].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {


                    _carta.gameObject.transform.parent = listaCase[5].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[5].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[5].GetPossicaoCasa()}");
                }

                break;

            case 3:

                if (listaCase[4].GetCaseOcupadoOponente() == false && listaCase[4].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {


                    _carta.gameObject.transform.parent = listaCase[4].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[4].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[4].GetPossicaoCasa()}");
                }
                else if (listaCase[5].GetCaseOcupadoOponente() == false && listaCase[5].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {


                    _carta.gameObject.transform.parent = listaCase[5].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[5].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[5].GetPossicaoCasa()}");
                }

                break;

            case 4:

                if (listaCase[6].GetCaseOcupadoOponente() == false && listaCase[6].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {


                    _carta.gameObject.transform.parent = listaCase[6].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[6].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[6].GetPossicaoCasa()}");
                }
                else if (listaCase[7].GetCaseOcupadoOponente() == false && listaCase[7].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {

                    _carta.gameObject.transform.parent = listaCase[7].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[7].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);


                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[7].GetPossicaoCasa()}");
                }

                break;

            case 5:

                if (listaCase[6].GetCaseOcupadoOponente() == false && listaCase[6].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[6].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[6].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[6].GetPossicaoCasa()}");
                }
                else if (listaCase[7].GetCaseOcupadoOponente() == false && listaCase[7].GetCaseOcupadoJogador() == false && _carta.GetMoveuSe() == false)
                {
                    _carta.gameObject.transform.parent = listaCase[7].gameObject.transform;
                    _carta.gameObject.transform.position = listaCase[7].gameObject.transform.position;

                    _carta.SetPodeAtacar(false);
                    _carta.SetMoveuSe(true);

                    Debug.Log($"{_carta.gameObject.name} se moveu para {listaCase[7].GetPossicaoCasa()}");
                }

                break;



        }
    }
    public void AtaquesPossiveis(int _possicaoCase, CartaDaCena _carta)
    {
        switch (_possicaoCase)
        {
            case 10:

                if (listaCase[10].GetCaseOcupadoOponente() == true && listaCase[10].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[11].GetCaseOcupadoOponente() == true && listaCase[11].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[8].GetCaseOcupadoOponente() == false && listaCase[8].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else if (listaCase[10].GetCaseOcupadoOponente() == true && listaCase[10].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[11].GetCaseOcupadoOponente() == true && listaCase[11].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[9].GetCaseOcupadoOponente() == false && listaCase[9].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;

            case 11:

                if (listaCase[10].GetCaseOcupadoOponente() == true && listaCase[10].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[11].GetCaseOcupadoOponente() == true && listaCase[11].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[8].GetCaseOcupadoOponente() == false && listaCase[8].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                
                    ai_Oponente.Ataque();
                }
                else if (listaCase[10].GetCaseOcupadoOponente() == true && listaCase[10].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[11].GetCaseOcupadoOponente() == true && listaCase[11].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[9].GetCaseOcupadoOponente() == false && listaCase[9].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                   
                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;

            case 9:

                if (listaCase[8].GetCaseOcupadoOponente() == true && listaCase[8].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[9].GetCaseOcupadoOponente() == true && listaCase[9].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[0].GetCaseOcupadoOponente() == false && listaCase[0].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    

                    ai_Oponente.Ataque();
                }
                else if (listaCase[8].GetCaseOcupadoOponente() == true && listaCase[8].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[9].GetCaseOcupadoOponente() == true && listaCase[9].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[1].GetCaseOcupadoOponente() == false && listaCase[1].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    
                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;

            case 8:

                if (listaCase[8].GetCaseOcupadoOponente() == true && listaCase[8].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[9].GetCaseOcupadoOponente() == true && listaCase[9].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[0].GetCaseOcupadoOponente() == false && listaCase[0].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                   
                    ai_Oponente.Ataque();
                }
                else if (listaCase[8].GetCaseOcupadoOponente() == true && listaCase[8].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[9].GetCaseOcupadoOponente() == true && listaCase[9].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[1].GetCaseOcupadoOponente() == false && listaCase[1].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;

            case 0:

                if (listaCase[0].GetCaseOcupadoOponente() == true && listaCase[0].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[1].GetCaseOcupadoOponente() == true && listaCase[1].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else if (listaCase[0].GetCaseOcupadoOponente() == true && listaCase[0].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[1].GetCaseOcupadoOponente() == true && listaCase[1].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;

            case 1:

                if (listaCase[0].GetCaseOcupadoOponente() == true && listaCase[0].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[1].GetCaseOcupadoOponente() == true && listaCase[1].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[2].GetCaseOcupadoOponente() == false && listaCase[2].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else if (listaCase[0].GetCaseOcupadoOponente() == true && listaCase[0].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[1].GetCaseOcupadoOponente() == true && listaCase[1].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[3].GetCaseOcupadoOponente() == false && listaCase[3].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;

            case 2:

                if (listaCase[0].GetCaseOcupadoOponente() == true && listaCase[0].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[1].GetCaseOcupadoOponente() == true && listaCase[1].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[4].GetCaseOcupadoOponente() == false && listaCase[4].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
              
                    ai_Oponente.Ataque();
                }
                else if (listaCase[0].GetCaseOcupadoOponente() == true && listaCase[0].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[1].GetCaseOcupadoOponente() == true && listaCase[1].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[5].GetCaseOcupadoOponente() == false && listaCase[5].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;

            case 3:

                if (listaCase[2].GetCaseOcupadoOponente() == true && listaCase[2].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[3].GetCaseOcupadoOponente() == true && listaCase[3].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[4].GetCaseOcupadoOponente() == false && listaCase[4].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    //_carta.moveuSe = true;
                    //_carta.podeAtacar = true;

                    ai_Oponente.Ataque();
                }
                else if (listaCase[2].GetCaseOcupadoOponente() == true && listaCase[2].GetNomeCartaOponente() == _carta.gameObject.name || listaCase[3].GetCaseOcupadoOponente() == true && listaCase[3].GetNomeCartaOponente() == _carta.gameObject.name && listaCase[5].GetCaseOcupadoOponente() == false && listaCase[5].GetCaseOcupadoJogador() == true && _carta.GetMoveuSe() == false)
                {
                    //_carta.moveuSe = true;     
                    //_carta.podeAtacar = true;

                    ai_Oponente.Ataque();
                }
                else
                {
                    _carta.SetMoveuSe(true);
                    _carta.SetPodeAtacar(false);
                }

                break;
        }
    }
   
}
