using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IA_Oponente : MonoBehaviour
{
    public List<CartaDaCena> deckOponente = new List<CartaDaCena>();

    [SerializeField] Deck deck;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlaTurnos controlaTurnos;

    //ContadorDeMovimentos contadorDeMovimentos;

    [SerializeField] private string guardaCartaComMaiorAtaque;

    [SerializeField] private string guardaCartaComMenorAtaque;

    public bool iaPodeAtacar = false;

    public void Start()
    {
        deck = GetComponent<Deck>();
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        controlaTurnos = GetComponent<ControlaTurnos>();
        //contadorDeMovimentos = GetComponent<ContadorDeMovimentos>();
    }
    public void SetIDCartaOponente(int _ID)
    {
        //guardaIDCartaOponente = _ID;
    }

    public void SetCartaComMenosAtaque(string _cardNome)
    {
        guardaCartaComMenorAtaque = _cardNome;
    }
    public void SetCartaComMaiorAtaque(string _cardNome)
    {
        guardaCartaComMaiorAtaque = _cardNome;
    }
    //public int GetIDCartaOponente()
    //{
    //return guardaIDCartaOponente;
    //}

    public string GetCartaComMenosAtaque()
    {
        return guardaCartaComMenorAtaque;
    }
    public string GetCartaComMaiorAtaque()
    {
        return guardaCartaComMaiorAtaque;
    }
    public void ControleDeAcoes()
    {
        if (controlaTurnos == true)
        {
            //iaPodeAtacar = true;
            //MovimentaCartas();
            //Mapeamento();
            //ResetaMovimentos();
            //StartCoroutine(Intervalo());
            StartCoroutine(EsperaCartasAparecerem());
            //ChecaCardsAtivosDoPlayer();

        }
    }

    public void ResetaMovimentos()
    {
        foreach (CartaDaCena carta in deckOponente)
        {
            if (carta != null)
            {
                //carta.moveuSe = false;
            }
        }
    }

    public IEnumerator EsperaCartasAparecerem()
    {
        yield return new WaitForSeconds(1f);

        ChecaCardsAtivosDoPlayer();

        foreach (CartaDaCena carta in deckOponente)
        {
            if (carta != null)
            {
                ia_MapeamentoDeCases.VerificaPosicaoAtualDaCarta(carta.nome);

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    //public IEnumerator Intervalo()
    //{
        

        //yield return new WaitForSeconds(1f);

        //foreach (Card carta in deckOponente)
        //{
            //if(carta != null)
            //{
                //carta.podeAtacar = true;

                //ia_MapeamentoDeCases.VerificaPossicaoAtualDaCarta(carta.nome);

                //yield return new WaitForSeconds(0.2f);
            //}
        //}
        //for(int i = 0; i < contadorDeMovimentos.contadorMovOponente; i++)
        //{
        //ia_MapeamentoDeCases.VerificaPossicaoAtualDaCarta(deckOponente[i].nome);
        //}

        //yield return new WaitForSeconds(1f);

        //ChecaCardsAtivosDoPlayer();
    //}

    public void ChecaCardsAtivosDoPlayer()
    {
        foreach (CartaDados cardAtivo in deck.geralCardList)
        {
            if (cardAtivo.ativo == true)
            {
                Debug.Log("Cards ativos do jogador: " + cardAtivo.nome);

                //VerificaSeHaCartaOponenteComMaisAtaque(cardAtivo);

                VerificaCardPlayerComMenorAtaque(cardAtivo);
            }
        }
    }
    public void VerificaCardPlayerComMenorAtaque(CartaDados _cardAtivo)
    {
        foreach (CartaDados card in deck.geralCardList)
        {
            if (card.ataque < _cardAtivo.ataque && card.ativo == true)
            {
                //SetCartaComMenosAtaque(card.nome);

                VerificaSeHaCartaJogadorComMenosAtaque(card);

                //Ataque();

                Debug.Log("Chama o método para verificar se há carta do jogador mais fraca ainda");

                //Debug.Log("Card jogador ativo: " + card.nome);

                //break;
            }
            else
            {
                //SetCartaComMenosAtaque(_cardAtivo.nome);
                //VerificaSeHaCartaOponenteComMaisAtaque(_cardAtivo);
                VerificaSeHaCartaJogadorComMenosAtaque(_cardAtivo);
            }
            //else
            //{
            //SetCartaComMenosAtaque(_cardAtivo.nome);

            //VerificaSeHaCartaOponenteComMaisAtaque(_cardAtivo);

            //Debug.Log("Jogador só possui uma carta");

            //Debug.Log("Chama o método para verificar se há carta do oponente mais forte que a única carta do jogador");
            //}
            //else
            //{
            //SetCartaComMenosAtaqueDoJogador(_cardAtivo.nome);

            //VerificaSeHaCartaOponenteComMaisAtaque(card);
            //}

            //else
            //{
            //SetCartaComMenosAtaqueDoJogador(_cardAtivo.nome);

            //VerificaSeHaCartaOponenteComMaisAtaque(_cardAtivo);

            //Ataque();

            //Debug.Log("Card com menor ataque do jogador: " + _cardAtivo.nome);


            //}

            //break;

        }

    }

    public void VerificaSeHaCartaJogadorComMenosAtaque(Card _cardAtivo)
    {
        foreach (Card card in deck.geralCardList)
        {
            if (card.ataque < _cardAtivo.ataque && card.ativo == true)
            {
                if (card != null)
                {
                    SetCartaComMenosAtaque(card.nome);

                    VerificaSeHaCartaOponenteComMaisAtaque(card);

                    Debug.Log("Card com menor ataque entre todas as cartas do jogador : " + GetCartaComMenosAtaque());
                }

                //break;
            }
            else
            {
                if (_cardAtivo != null)
                {
                    SetCartaComMenosAtaque(_cardAtivo.nome);

                    //VerificaSeHaCartaOponenteComMaisAtaque(_cardAtivo);
                    VerificaCardOponenteComMaiorAtaque(_cardAtivo);
                    //LimpaCartaComMenorAtaque(GetCartaComMenosAtaque());

                    //Debug.Log("Jogador não possui cartas com menos ataque que : " + _cardAtivo.nome);
                }
            }
        }
    }

    //public void LimpaCartaComMenorAtaque(string _nome)
    //{
    //foreach(Card carta in deck.geralCardList)
    //{
    //if(carta.ativo == true && carta.nome != _nome)
    //{

    //}
    //}
    //}

    public void VerificaSeHaCartaOponenteComMaisAtaque(Card _cardMenorAtaque)
    {
        //MovimentaCarta(_cardMenorAtaque);

        foreach (Card _cardHekaib in deckOponente)
        {
            //JOGADOR PRECISA TER COLOCADO UMA CARTA EM CAMPO
            //if (_cardHekaib != null)
            //{
            //ia_MapeamentoDeCases.VerificaPossicaoAtualDaCarta(_cardHekaib);
            //}

            if (_cardHekaib.ataque > _cardMenorAtaque.ataque)
            {
                if (_cardHekaib != null)
                {
                    //SetCartaComMaiorAtaque(_cardHekaib.nome);

                    //SetCartaComMenosAtaqueDoJogador(_cardMenorAtaque.nome);

                    //Ataque();
                    //ia_MapeamentoDeCases.VerificaPossicaoAtualDaCarta(_cardHekaib.nome);

                    VerificaCardOponenteComMaiorAtaque(_cardHekaib);

                    Debug.Log("Chama o método verificar se a carta com ataque ainda maior");
                }
                //break;
            }
            else
            {
                //SetCartaComMenosAtaque(GetCartaComMenosAtaque());

                //Ataque();

                //if (_cardHekaib != null)
                //{
                //SetCartaComMaiorAtaque(_cardHekaib.nome);

                //Ataque();
                //}
                //ia_MapeamentoDeCases.VerificaPossicaoAtualDaCarta(_cardHekaib.nome);

                VerificaSeHaCartaJogadorComMenosAtaque(_cardMenorAtaque);

                //VerificaCardOponenteComMaiorAtaque(_cardMenorAtaque);

                //SetCartaComMaiorAtaque(_cardHekaib.nome);

                //Debug.Log("Oponente não possui cartas com ataque maior que as do jogador");
            }
        }
    }
    public void VerificaCardOponenteComMaiorAtaque(Card _cardHekaib)
    {

        foreach (Card _cardHekaibMaiorAtaque in deckOponente)
        {
            if (_cardHekaibMaiorAtaque.ataque > _cardHekaib.ataque)
            {
                //SetCartaComMaiorAtaque(null);

                //ia_MapeamentoDeCases.VerificaPossicaoAtualDaCarta(GetCartaComMaiorAtaque());

                if (_cardHekaibMaiorAtaque != null)
                {

                    SetCartaComMaiorAtaque(_cardHekaibMaiorAtaque.nome);

                    Debug.Log("Card com maior ataque entre todas as cartas do oponente : " + GetCartaComMaiorAtaque());
                }
            }


            //else
            //{
            //SetCartaComMaiorAtaque(_cardHekaib.nome);
            //}

            //else
            //{
            //if (_cardHekaib != null)
            //{
            //SetCartaComMaiorAtaque(_cardHekaib.nome);

            //Ataque();
            //}
            //}
            //else if (_cardHekaibMaiorAtaque.nome == GetCartaComMaiorAtaque())
            //{
            //SetCartaComMaiorAtaque(_cardHekaibMaiorAtaque.nome);

            //Ataque();
            //}
            //else
            //{
            //SetCartaComMaiorAtaque(_cardHekaib.nome);

            //Ataque();

            //Debug.Log("O oponente não possui cartas com ataque maior que este : " + GetCartaComMaiorAtaque());
            //}

            /*
            else
            {
                SetCartaComMaiorAtaque(_cardHekaib.nome);

                Ataque();

                Debug.Log("Card com maior ataque do oponente : " + GetCartaComMaiorAtaque());      
            }
            */

            /*
            else
            {
                //SetCartaComMaiorAtaque(_cardHekaib.nome);

                //Ataque();

                //Debug.Log("Card com maior ataque do oponente : " + GetCartaComMaiorAtaque());

                //break;
            }
            */
            //break;
        }
           
            //Ataque();
        
    }
    public void Ataque()
    {
        foreach (Card cardSalvoA in deckOponente)
        {
            if (cardSalvoA.nome == GetCartaComMaiorAtaque())
            {
                foreach (Card cardSalvoB in deck.geralCardList)
                {
                    if (cardSalvoB.nome == GetCartaComMenosAtaque() && cardSalvoB.ativo == true)
                    {
                        Debug.Log("Chama o método mover carta");

                        //for (int i = 0; i < contadorDeMovimentos.contadorDeAtaquesOponentes; i++)
                        //{
                        //iaPodeAtacar = true;

                        MoveCardOponente(cardSalvoA, cardSalvoB);
                        //StartCoroutine(EsperaAtaque(cardSalvoA, cardSalvoB));
                        //}

                    }
                }
            }

            //break;
        }
    }
    //public void MovimentaCarta(Card _card)
    //{
    //ia_MapeamentoDeCases.VerificaPossicaoAtualDaCarta(_card);
    //}

    //public IEnumerator EsperaAtaque(Card cardSalvoA, Card cardSalvoB)
    //{
    //yield return new WaitForSeconds(1f);

    //MoveCardOponente(cardSalvoA, cardSalvoB);
    //}

    public void MoveCardOponente(Card _cardOponenteComMaiorAtaque, Card _cardPlayerComMenorAtaque)
    {
        foreach (Case casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetNomeCartaJogador() == _cardPlayerComMenorAtaque.nome && _cardOponenteComMaiorAtaque.podeAtacar == true && _cardOponenteComMaiorAtaque.GetMoveuSe() == false)
            {
                //iaPodeAtacar = false;

                _cardOponenteComMaiorAtaque.podeAtacar = false;
                _cardOponenteComMaiorAtaque.SetMoveuSe(true);

                //Debug.Log($"Nome do case com a carta de menor ataque do jogador: {casa.gameObject.name}");

                if (_cardOponenteComMaiorAtaque != null && _cardPlayerComMenorAtaque != null)
                {

                    Debug.Log($"Card do oponente com maior ataque: {_cardOponenteComMaiorAtaque.nome} Card do jogador com menor ataque: {_cardPlayerComMenorAtaque.nome}");

                    _cardOponenteComMaiorAtaque.gameObject.transform.parent = casa.gameObject.transform;
                    _cardOponenteComMaiorAtaque.gameObject.transform.position = casa.gameObject.transform.position;

                    /*
                    if (_cardPlayerComMenorAtaque.vida <= 0 || _cardPlayerComMenorAtaque == null)
                    {
                        foreach (Card card in deck.geralCardList)
                        {
                            if (card.vida > 0 && card.ativo == true)
                            {
                                SetCartaComMenosAtaque(card.nome);

                                Debug.Log($"Nome do novo card de menor ataque do jogador: {_cardPlayerComMenorAtaque.nome}");

                                //break;
                            }
                        }
                    }
                    */
                    //break;
                }
            }

            /*
            else
            {
                if (_cardOponenteComMaiorAtaque.ataque < _cardPlayerComMenorAtaque.ataque || _cardOponenteComMaiorAtaque == null)
                {
                    foreach (Card card in deckOponente)
                    {
                        if (card.ataque > _cardPlayerComMenorAtaque.ataque && card != null)
                        {
                            SetCartaComMaiorAtaque(card.nome);

                            Debug.Log($"Nome do novo card de maior ataque do oponente: {_cardOponenteComMaiorAtaque.nome}");

                            //break;
                        }
                    }
                }
            }
            */
        }
    }
    /*
    if (_cardOponenteComMaiorAtaque.ataque <= _cardPlayerComMenorAtaque.ataque)
    {
        foreach (Card card in deck.geralCardList)
        {
            if (card.ataque < _cardOponenteComMaiorAtaque.ataque && card.cardAtivo == true)
            {
                SetCartaComMenosAtaqueDoJogador(card.nome);
            }
        }
    }

    if (_cardOponenteComMaiorAtaque.ataque <= _cardPlayerComMenorAtaque.ataque)
    {
        foreach (Card card in deckOponente)
        {
            if (card.ataque > _cardPlayerComMenorAtaque.ataque)
            {
                SetCartaComMaiorAtaque(card.nome);
            }
        }
    }
    */
}

