using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IA_Oponente : MonoBehaviour
{
    Baralho_Oponente baralhoOponente;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlaTurnos controlaTurnos;

    public bool iaPodeAtacar = false;

    [System.Obsolete]
    public void Start()
    {
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        controlaTurnos = GetComponent<ControlaTurnos>();
        baralhoOponente = GetComponent<Baralho_Oponente>();
    }

    public void ControleDeAcoes()
    {
        ProcuraAlvo();
        Movimento();
    }

    //CHECA TODAS AS CARTAS ATIVAS DO JOGADOR
    public void ProcuraAlvo()
    {
        for (int i = 0; i < baralhoOponente.deckOponente.Count; i++) //PERCORRE TODO O BARALHO PROCURANDO CARTAS QUE PODEM ATACAR
        {
            CartaDaCena carta = baralhoOponente.deckOponente[i];

            if (carta == null)
                continue;

            if (carta.GetPodeAtacar() == false)
                continue;

            Casa casa = ia_MapeamentoDeCases.listaCase.Find( c => c.GetIDCartaOcupante() == carta.dados.ID);

            if (casa == null)
                continue;

            ia_MapeamentoDeCases.AtaquesPossiveis( casa.GetPosicaoCasa(), carta);
        }
    }
    public void Movimento()
    {
        for (int i = 0; i < baralhoOponente.deckOponente.Count; i++) //PERCORRE TODO O BARALHO PROCURANDO CARTAS QUE PODEM MOVER-SE
        {
            CartaDaCena carta = baralhoOponente.deckOponente[i];

            if (carta == null)
                continue;

            if (carta.GetMoveuSe() == true)
                continue;

            Casa casa = ia_MapeamentoDeCases.listaCase.Find(
                c => c.GetIDCartaOcupante() == carta.dados.ID);

            if (casa == null)
                continue;

            ia_MapeamentoDeCases.MovimentosPossiveis( casa.GetPosicaoCasa(), carta);
        }
    }
    
}

