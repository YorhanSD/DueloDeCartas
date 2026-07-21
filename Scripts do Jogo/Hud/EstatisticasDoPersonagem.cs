using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;

public class EstatisticasDoPersonagem : MonoBehaviour
{
    public CriaPersonagens criaPersonagens;
    public TelaPersonagem telaPersonagem;
    public BancoCards bancoCards;
    public MostraCarta mostraCarta;

    public TextMeshProUGUI textoEstatisticasOfensivas;
    public TextMeshProUGUI textoEstatisticasDefensivas;

    public TextMeshProUGUI textoBotaoEspecie;

    string guardaEspecieDominante;

    float resultadoDadoOfensivo;
    float resultadoDadoDefensivo;

    float resultadoDadoSecundarioOfensivo;
    float resultadoDadoSecundarioDefensivo;

    int contaClique = 0;

    public void Start()
    {
        telaPersonagem = GetComponent<TelaPersonagem>();
        mostraCarta = GetComponent<MostraCarta>();
    }
    public void botaoResetaCalculo()
    {
        resultadoDadoOfensivo = 0;
        resultadoDadoDefensivo = 0;
    }
    public void botaoMya()
    {
        contaClique = 0;

        foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
        {
            if (carta.cartaBase.especie == CartaOriginal.Especies.Espacial)
            {
                carta.cartaBase.especieDominante = true;
                mostraCarta.LeitorDeCartasDoVisor(carta);

                resultadoDadoOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }
        }

        guardaEspecieDominante = "Espacial";

        textoEstatisticasOfensivas.text = "Pontos Ofensivos em Média: " + (resultadoDadoSecundarioOfensivo + resultadoDadoOfensivo).ToString();
        textoEstatisticasDefensivas.text = "Pontos Defensivos em Média: " + (resultadoDadoSecundarioDefensivo + resultadoDadoDefensivo).ToString();
    }
    public void botaoMcDino()
    {
        contaClique = 1;

        foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
        {
            if (carta.cartaBase.especie == CartaOriginal.Especies.Extinto)
            {
                carta.cartaBase.especieDominante = true;
                mostraCarta.LeitorDeCartasDoVisor(carta);

                resultadoDadoOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }


        }

        guardaEspecieDominante = "Extinto";

        textoEstatisticasOfensivas.text = "Pontos Ofensivos em Média: " + (resultadoDadoSecundarioOfensivo + resultadoDadoOfensivo).ToString();
        textoEstatisticasDefensivas.text = "Pontos Defensivos em Média: " + (resultadoDadoSecundarioDefensivo + resultadoDadoDefensivo).ToString();
    }

    public void botaoHekaib()
    {
        contaClique = 2;

        foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
        {
            if (carta.cartaBase.especie == CartaOriginal.Especies.Tenebroso)
            {
                carta.cartaBase.especieDominante = true;
                mostraCarta.LeitorDeCartasDoVisor(carta);

                resultadoDadoOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }
        }

        guardaEspecieDominante = "Tenebroso";

        textoEstatisticasOfensivas.text = "Pontos Ofensivos em Média: " + (resultadoDadoSecundarioOfensivo + resultadoDadoOfensivo).ToString();
        textoEstatisticasDefensivas.text = "Pontos Defensivos em Média: " + (resultadoDadoSecundarioDefensivo + resultadoDadoDefensivo).ToString();
    }
    public void botaoDalila()
    {
        contaClique = 3;

        foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
        {
            if (carta.cartaBase.especie == CartaOriginal.Especies.Celestial)
            {
                carta.cartaBase.especieDominante = true;
                mostraCarta.LeitorDeCartasDoVisor(carta);

                resultadoDadoOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }
        }
        guardaEspecieDominante = "Celestial";

        textoEstatisticasOfensivas.text = "Pontos Ofensivos em Média: " + (resultadoDadoSecundarioOfensivo + resultadoDadoOfensivo).ToString();
        textoEstatisticasDefensivas.text = "Pontos Defensivos em Média: " + (resultadoDadoSecundarioDefensivo + resultadoDadoDefensivo).ToString();
    }

    public void botaoTrocaDeEspecie()
    {
        contaClique++;

        resultadoDadoSecundarioDefensivo = 0;
        resultadoDadoSecundarioOfensivo = 0;

        switch (contaClique)
        {
            case 0: //Espacial

                foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
                {
                    if (carta.cartaBase.especie == CartaOriginal.Especies.Espacial)
                    {
                        carta.cartaBase.especieRecessiva = true;
                        mostraCarta.LeitorDeCartasDoVisor(carta);

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
                    }
                }

                foreach (Personagem personagem in criaPersonagens.personagemList)
                {
                    if (telaPersonagem.GetPersonagemSelecionado() == personagem.id)
                    {
                        personagem.elencoDominante = guardaEspecieDominante;
                        personagem.elencoRecessivo = "Espacial";

                        telaPersonagem.EspeciesSelecionadas(personagem);

                        break;
                    }
                }

                textoBotaoEspecie.text = "Espacial";

                break;

            case 1: //Extinto

                foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
                {
                    if (carta.cartaBase.especie == CartaOriginal.Especies.Extinto)
                    {
                        carta.cartaBase.especieRecessiva = true;
                        mostraCarta.LeitorDeCartasDoVisor(carta);

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
                    }
                }

                foreach (Personagem personagem in criaPersonagens.personagemList)
                {
                    if (telaPersonagem.GetPersonagemSelecionado() == personagem.id)
                    {
                        personagem.elencoDominante = guardaEspecieDominante;
                        personagem.elencoRecessivo = "Extinto";

                        telaPersonagem.EspeciesSelecionadas(personagem);

                        break;
                    }
                }

                textoBotaoEspecie.text = "Extinto";

                break;

            case 2: //Tenebroso

                foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
                {
                    if (carta.cartaBase.especie == CartaOriginal.Especies.Tenebroso)
                    {
                        carta.cartaBase.especieRecessiva = true;
                        mostraCarta.LeitorDeCartasDoVisor(carta);

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
                    }
                }

                foreach (Personagem personagem in criaPersonagens.personagemList)
                {
                    if (telaPersonagem.GetPersonagemSelecionado() == personagem.id)
                    {
                        personagem.elencoDominante = guardaEspecieDominante;
                        personagem.elencoRecessivo = "Tenebroso";

                        telaPersonagem.EspeciesSelecionadas(personagem);

                        break;
                    }
                }

                textoBotaoEspecie.text = "Tenebroso";

                break;

            case 3: //Celestial

                foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
                {
                    if (carta.cartaBase.especie == CartaOriginal.Especies.Celestial)
                    {
                        carta.cartaBase.especieRecessiva = true;
                        mostraCarta.LeitorDeCartasDoVisor(carta);

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque + carta.cartaBase.reacao / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima + carta.cartaBase.couraca / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
                    }
                }

                foreach (Personagem personagem in criaPersonagens.personagemList)
                {
                    if (telaPersonagem.GetPersonagemSelecionado() == personagem.id)
                    {
                        personagem.elencoDominante = guardaEspecieDominante;
                        personagem.elencoRecessivo = "Celestial";

                        telaPersonagem.EspeciesSelecionadas(personagem);

                        break;
                    }
                }

                textoBotaoEspecie.text = "Celestial";

                break;
        }

        textoEstatisticasOfensivas.text = "Pontos Ofensivos em Média: " + (resultadoDadoSecundarioOfensivo + resultadoDadoOfensivo).ToString();
        textoEstatisticasDefensivas.text = "Pontos Defensivos em Média: " + (resultadoDadoSecundarioDefensivo + resultadoDadoDefensivo).ToString();

        if (contaClique > 2)
        {
            contaClique = -1;
        }
    }
}
