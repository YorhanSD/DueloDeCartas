using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EstatisticasDoPersonagem : MonoBehaviour
{
    public BancoCards bancoCards;
    public MostraCarta mostraCarta;

    public TextMeshProUGUI textoEstatisticasOfensivas;
    public TextMeshProUGUI textoEstatisticasDefensivas;

    public TextMeshProUGUI textoBotaoEspecie;

    float resultadoDadoOfensivo;
    float resultadoDadoDefensivo;

    float resultadoDadoSecundarioOfensivo;
    float resultadoDadoSecundarioDefensivo;

    int contaClique = 0;

    public void Start()
    {
        mostraCarta = GetComponent<MostraCarta>();
    }
    public void resetaCalculo()
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

                resultadoDadoOfensivo += carta.cartaBase.ataque / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }
        }

        textoEstatisticasOfensivas.text = "Pontos Ofensivos em Média: " + (resultadoDadoSecundarioOfensivo + resultadoDadoOfensivo).ToString();
        textoEstatisticasDefensivas.text = "Pontos Defensivos em Média: " + (resultadoDadoSecundarioDefensivo + resultadoDadoDefensivo).ToString();
    }
    public void botaoMcDino()
    {
        contaClique = 1;

        foreach (CartaDaCena carta in bancoCards.geralCartaCenaLista)
        {
            if(carta.cartaBase.especie == CartaOriginal.Especies.Extinto)
            {
                carta.cartaBase.especieDominante = true;
                mostraCarta.LeitorDeCartasDoVisor(carta);

                resultadoDadoOfensivo += carta.cartaBase.ataque / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }
        }

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

                resultadoDadoOfensivo += carta.cartaBase.ataque / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }
        }

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

                resultadoDadoOfensivo += carta.cartaBase.ataque / 3;
                resultadoDadoDefensivo += carta.cartaBase.vidaMaxima / 3;
            }
            else
            {
                mostraCarta.LimpaCartasDominantes(carta);
            }
        }

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

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
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

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
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

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
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

                        resultadoDadoSecundarioOfensivo += carta.cartaBase.ataque / 3;
                        resultadoDadoSecundarioDefensivo += carta.cartaBase.vidaMaxima / 3;
                    }
                    else
                    {
                        mostraCarta.LimpaCartasRecessoras(carta);
                    }
                }

                textoBotaoEspecie.text = "Celestial";

                break;
        }

        textoEstatisticasOfensivas.text = "Pontos Ofensivos em Média: " + (resultadoDadoSecundarioOfensivo + resultadoDadoOfensivo).ToString();
        textoEstatisticasDefensivas.text = "Pontos Defensivos em Média: " + (resultadoDadoSecundarioDefensivo + resultadoDadoDefensivo).ToString();

        if(contaClique > 2)
        {
            contaClique = -1;
        }
}
}
