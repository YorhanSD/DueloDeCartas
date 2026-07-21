using UnityEngine;

public class Ultima_Casa : MonoBehaviour
{
    Regras_Jogo regrasJogo;

    [System.Obsolete]
    private void Start()
    {
        regrasJogo = FindObjectOfType<Regras_Jogo>();
    }

    public void OnTriggerEnter2D(Collider2D _carta)
    {
        if (_carta.gameObject.tag == "Carta Oponente" && this.gameObject.name == "Casa 0" || _carta.gameObject.tag == "Carta Oponente" && this.gameObject.name == "Casa 1")
        {
            regrasJogo.AtivaTela_Derrota();
        }

        if (_carta.gameObject.tag == "Carta Jogador" && this.gameObject.name == "Casa 14" || _carta.gameObject.tag == "Carta Jogador" && this.gameObject.name == "Casa 15")
        {
            regrasJogo.AtivaTela_Vitoria();
        }
    }
}
