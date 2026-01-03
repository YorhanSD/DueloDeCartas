using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    //MONOBEHAVIOUR NÃO PODE SER CRIADO COM NEW
    BancoCards bancoCartas;

    [SerializeField] private ControlaTurnos controlaTurnos;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    ControlePontos controlePontos;

    Energia energia;

    public bool travarJogador = false;

    [System.Obsolete]
    public void Start()
    {
        bancoCartas = GetComponent<BancoCards>();

        controlaTurnos = GetComponent<ControlaTurnos>();

        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();

        controlePontos = FindObjectOfType<ControlePontos>();

        energia = GetComponent<Energia>();
    }

    private void Update()
    {
        if (energia.barraEnergiaJogador.value < 30)
        {
            travarJogador = true;
        }
        else
        {
            travarJogador = false;
        }
    }

    [System.Obsolete]
    public void UmContraUm(int IDDefensor, int IDAtacante)
    {
        CartaDaCena ataca = bancoCartas.geralCartaCenaLista.Find(c => c.dados.ID == IDDefensor);
        CartaDaCena defende = bancoCartas.geralCartaCenaLista.Find(c => c.dados.ID == IDAtacante);

        if (ataca == null || defende == null) return;

        if (controlaTurnos.turnoOponente == false && ataca.CompareTag("Card Player") && defende.CompareTag("Card Oponente"))
        {
            ataca.SetPodeAtacar(false);
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual;

            if (defende.uiCarta != null)
            {
                defende.uiCarta.AtualizarUI(defende.dados);
            }
            else
            {
                Debug.LogError($"Carta {defende.name} está sem UI ligada!");
            }

            VerificaMorte(defende);

            Debug.Log($"Defensor: {defende.dados.nomeAtual} Atacante: {ataca.dados.nomeAtual}");

            Debug.Log($"Card defensor: {defende.dados.nomeAtual} recebe {ataca.dados.ataqueAtual} de dano");

            if (defende.dados.vidaAtual > 0)
            {
                foreach (Case casa in ia_MapeamentoDeCases.listaCase)
                {
                    if (casa.GetUltimoID() == ataca.dados.ID)
                    {
                        ataca.transform.SetParent(casa.gameObject.transform, false);
                        ataca.transform.localPosition = Vector3.zero;
                    }
                }
            }
            else
            {
                //Mover isso para o método morte
                foreach (Case casa in ia_MapeamentoDeCases.listaCase)
                {
                    if (casa.GetIDCartaOcupante() == defende.dados.ID)
                    {
                        casa.SetIDCartaOcupante(ataca.dados.ID );
                        //casa.SetUltimoID(ataca.dados.ID);

                        Debug.Log($"{ataca.dados.nomeAtual} tomou a casa de {defende.dados.nomeAtual}");
                    }
                }
            }
        }
        else if (controlaTurnos.turnoOponente == true && ataca.CompareTag("Card Oponente") && defende.CompareTag("Card Player"))
        {
            ataca.SetPodeAtacar(false);
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual;

            if (defende.uiCarta != null)
            {
                defende.uiCarta.AtualizarUI(defende.dados);
            }
            else
            {
                Debug.LogError($"Carta {defende.name} está sem UI ligada!");
            }

            VerificaMorte(defende);

            if (defende.dados.vidaAtual > 0)
            {
                foreach (Case casaB in ia_MapeamentoDeCases.listaCase)
                {
                    if (casaB.GetUltimoID() == ataca.dados.ID)
                    {
                        ataca.transform.SetParent(casaB.gameObject.transform, false);
                        ataca.transform.localPosition = Vector3.zero;
                    }
                }

            }
            else
            {
                foreach (Case casa in ia_MapeamentoDeCases.listaCase)
                {
                    if (casa.GetIDCartaOcupante() == defende.dados.ID)
                    {
                        casa.SetIDCartaOcupante(ataca.dados.ID);
                        //casa.SetUltimoID(ataca.dados.ID);
                    }
                }
            }
        }

    }
    void VerificaMorte(CartaDaCena carta)
    {
        if (carta.dados.vidaAtual <= 0)
        {
            // Remove UI
            //bancoCartas.geralCartaUILista.RemoveAll(ui => ui.idUI == carta.dados.ID);

            // Remove runtime
            bancoCartas.geralCartaRuntimeLista.Remove(carta.dados);

            // Remove da cena
            bancoCartas.geralCartaCenaLista.Remove(carta);

            Destroy(carta.gameObject);
        }
    }
    /*
    void AtualizaUI(CartaDaCena carta)
    {
        foreach (UICard ui in bancoCartas.geralCartaUILista)
        {
            if (ui.idUI == carta.dados.ID)
            {
                ui.vidaUI = carta.dados.vidaAtual;
                break;
            }
        }
    }
    */
}

