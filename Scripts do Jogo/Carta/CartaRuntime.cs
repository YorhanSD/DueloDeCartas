using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CartaRuntime
{
    public int ID;
    public string especieSelecionada;
    public string nome;
    public int ataqueAtual;
    public int vidaAtual;
    public int vidaMaxima;
    public int couracaAtual;
    public int couracaMaxima;
    public int reacao;
    public int lucidez;

    public CartaDaCena cartaCena;
    public CartaOriginal cartaOriginal;
    public UICard uiCard;

    public void Inicializar(int ID)
    {
        //ID vem de fora
        this.ID = ID;
        especieSelecionada = cartaOriginal.especie.ToString();
        nome = cartaOriginal.nome;
        ataqueAtual = cartaOriginal.ataque;
        vidaAtual = cartaOriginal.vida;
        vidaMaxima = cartaOriginal.vidaMaxima;
        couracaAtual = cartaOriginal.couraca;
        couracaMaxima = cartaOriginal.couracaMaxima;
        reacao = cartaOriginal.reacao;
        lucidez = cartaOriginal.lucidez;
    }
}
