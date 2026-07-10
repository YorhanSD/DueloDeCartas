using UnityEngine;

public class MostraCarta : MonoBehaviour
{
    public EstatisticasDoPersonagem estatisticasDoPersonagem;
    public BancoCards bancoCards;
    void Start()
    {
        estatisticasDoPersonagem = GetComponent<EstatisticasDoPersonagem>();
        bancoCards = GetComponent<BancoCards>();
    }
   
    public void LeitorDeCartasDoVisor(CartaDaCena cartaLeitura)
    {
        foreach (CartaDaCena cartaCena in bancoCards.geralCartaCenaLista)
        {
            if(cartaLeitura.cartaBase.ID == cartaCena.cartaBase.ID) //Usar cartaBase, pois Print não funciona nesse caso
            {
                Debug.Log($"Nome: {cartaLeitura.cartaBase.nome} ID: {cartaLeitura.cartaBase.ID}");
                bancoCards.geralCartaCenaLista[cartaCena.cartaBase.ID].gameObject.SetActive(true);
            }
        }
    }
    public void LimpaCartasDominantes(CartaDaCena cartaLeitura)
    {
        foreach (CartaDaCena cartaCena in bancoCards.geralCartaCenaLista)
        {
            if (cartaLeitura.cartaBase.ID == cartaCena.cartaBase.ID && cartaLeitura.cartaBase.especieDominante == true)
            {
                cartaLeitura.cartaBase.especieDominante = false;
                bancoCards.geralCartaCenaLista[cartaCena.cartaBase.ID].gameObject.SetActive(false);
            }
        }
    }
    public void LimpaCartasRecessoras(CartaDaCena cartaLeitura)
    {
        foreach (CartaDaCena cartaCena in bancoCards.geralCartaCenaLista)
        {
            if (cartaLeitura.cartaBase.ID == cartaCena.cartaBase.ID && cartaLeitura.cartaBase.especieRecessiva == true && cartaLeitura.cartaBase.especieDominante == false)
            {
                cartaLeitura.cartaBase.especieRecessiva = false;
                bancoCards.geralCartaCenaLista[cartaCena.cartaBase.ID].gameObject.SetActive(false);
            }
        }
    }
}
