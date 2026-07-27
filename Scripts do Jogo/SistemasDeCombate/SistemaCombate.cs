using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SistemaCombate : MonoBehaviour
{

    //MONOBEHAVIOUR NÃO PODE SER CRIADO COM NEW
    BancoCards bancoCartas;

    public EntraESaiCartas entraESaiCartas;

    [SerializeField] private ControlaTurnos controlaTurnos;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    [SerializeField] Casa casa;

    public ControlePontos controlePontos;

    Energia energia;

    public bool travarJogador = false;

    [System.Obsolete]
    public void Start()
    {
        entraESaiCartas = GetComponent<EntraESaiCartas>();

        casa = FindObjectOfType<Casa>();

        bancoCartas = GetComponent<BancoCards>();

        controlaTurnos = GetComponent<ControlaTurnos>();

        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();

        controlePontos = FindObjectOfType<ControlePontos>();

        energia = GetComponent<Energia>();
    }

    public void UmContraUm(int IDDefensor, int IDAtacante)
    {
        CartaDaCena ataca = bancoCartas.geralCartaCenaLista.Find(c => c.dados.ID == IDAtacante);
        CartaDaCena defende = bancoCartas.geralCartaCenaLista.Find(c => c.dados.ID == IDDefensor);

        if (ataca == null || defende == null) return;

        if (controlaTurnos.turnoOponente == false && ataca.CompareTag("Carta Jogador") && defende.CompareTag("Carta Oponente"))
        {
            ChamaGravaUltimoID(ataca);

            //ataca.SetPodeAtacar(false);
            //ataca.SetMoveuSe(true);
            VerificaCouraca(ataca, defende);
            DanoPorReacao(ataca, defende);
            defende.PrintaDados(defende.dados);

            if (defende.uiCarta != null)
            {
                defende.uiCarta.AtualizarUI(defende.dados);
            }
            else
            {
                Debug.LogError($"Carta {defende.printNome} está sem UI ligada!");
            }

            VerificaMorte(ataca, defende);
            ataca.SetCartaEstaAtacando(false);
            //CartaQueFoiAtacada(defende);
        }
        else if (controlaTurnos.turnoOponente == true && ataca.CompareTag("Carta Oponente") && defende.CompareTag("Carta Jogador"))
        {
            ChamaGravaUltimoID(ataca);

            VerificaCouraca(ataca, defende);
            DanoPorReacao(ataca, defende);
            defende.PrintaDados(defende.dados);

            if (defende.uiCarta != null)
            {
                defende.uiCarta.AtualizarUI(defende.dados);
            }
            else
            {
                Debug.LogError($"Carta {defende.printNome} está sem UI ligada!");
            }

            VerificaMorte(ataca, defende);
            ataca.SetCartaEstaAtacando(false);
            //CartaQueFoiAtacada(defende);
        }
    }

    void Retorno(CartaDaCena _ataca, CartaDaCena _defende)
    {
        if (_defende.dados.vidaAtual > 0)
        {
            foreach (Casa casaB in ia_MapeamentoDeCases.listaCase)
            {
                if (casaB.GetUltimoID() == _ataca.dados.ID) //Casa mais próxima
                {
                    casaB.CartaEntra(_ataca, casaB.transform);
                    //Volta para casa com ultimo id
                }
            }
        }
    }
    
    void ChamaGravaUltimoID(CartaDaCena _ataca)
    {
        foreach (Casa casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetIDCartaOcupante() == _ataca.dados.ID)
            {
                casa.GravaUltimoID(_ataca.dados.ID); //Grava o id da carta atacante na sua própria casa
            }
        }
    }

    public void MoveAteCasaQueDestruiuCarta(CartaDaCena _ataca, CartaDaCena _defende)
    {
        foreach (Casa casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetIDCartaOcupante() == _defende.dados.ID)
            {
                casa.DesocuparCasa(_defende);

                casa.CartaEntra(_ataca, casa.transform);

                break;
            }
        }
    }
    void VerificaMorte(CartaDaCena _ataca, CartaDaCena _defende)
    {
        if (_defende.dados.vidaAtual <= 0)
        {
            _defende.SetCartaMorreu(true);

            MoveAteCasaQueDestruiuCarta(_ataca,_defende);

            // REMOVE defensor
            bancoCartas.geralCartaRuntimeLista.Remove(_defende.dados);
            bancoCartas.geralCartaCenaLista.Remove(_defende);

            Destroy(_defende.gameObject); 
        }
        else
        {
            Retorno(_ataca, _defende);
        }
    }
    public void MoveCartaParaACasaQueDestruiuOCard(CartaDaCena ataca, CartaDaCena defende)
    {

        foreach (Casa casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetIDCartaOcupante() == defende.dados.ID)
            {
               
            }
        }

        // MOVE atacante
        
        //ataca.transform.SetParent(casaDefensor.transform);
        //ataca.transform.localPosition = Vector3.zero;

        // ATUALIZA A CASA
        //casaDefensor.SetIDCartaOcupante(ataca.dados.ID);

        

        //ataca.SetMoveuSe(true);
    }

    public void VerificaCouraca(CartaDaCena _ataca, CartaDaCena _defende)
    {
        if (_defende.dados.couracaAtual <= 0)
        {
            ChecaEspecie(_ataca, _defende);
        }
        else
        {
            _defende.dados.couracaAtual -= 10;
        }
    }

    public void DanoPorReacao(CartaDaCena _ataca, CartaDaCena _defende)
    {
        if (_ataca.dados.couracaAtual > 0)
        {
            _ataca.dados.couracaAtual -= 10;

            _ataca.uiCarta.AtualizarUI(_ataca.dados);
        }
        else
        {
            _ataca.dados.vidaAtual -= _defende.dados.reacao;

            _ataca.uiCarta.AtualizarUI(_ataca.dados);

            VerificaMorte(_defende,_ataca);
        }

        Debug.Log($"Atacante: {_ataca.dados.nome} sofre: {_defende.dados.reacao} de Dano de Reação da Carta: {_defende.dados.nome}");
    }

    public void ChecaEspecie(CartaDaCena ataca, CartaDaCena defende)
    {
        if (ataca.dados.especieSelecionada == "Celestial" && defende.dados.especieSelecionada == "Tenebroso")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual * 2; //Multiplica o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual * 2}] de dano [Super Eficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else if (ataca.dados.especieSelecionada == "Tenebroso" && defende.dados.especieSelecionada == "Celestial")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual / 2; //Divide o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual / 2}] de dano [Ineficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else if (ataca.dados.especieSelecionada == "Extinto" && defende.dados.especieSelecionada == "Celestial")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual * 2; //Multiplica o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual * 2}] de dano [Super Eficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else if (ataca.dados.especieSelecionada == "Celestial" && defende.dados.especieSelecionada == "Extinto")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual / 2; //Divide o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual / 2}] de dano [Ineficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else if (ataca.dados.especieSelecionada == "Espacial" && defende.dados.especieSelecionada == "Extinto")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual * 2; //Multiplica o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual * 2}] de dano [Super Eficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else if (ataca.dados.especieSelecionada == "Extinto" && defende.dados.especieSelecionada == "Celestial")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual / 2; //Divide o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual / 2}] de dano [Ineficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else if (ataca.dados.especieSelecionada == "Tenebroso" && defende.dados.especieSelecionada == "Espacial")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual * 2; //Multiplica o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual * 2}] de dano [Super Eficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else if (ataca.dados.especieSelecionada == "Espacial" && defende.dados.especieSelecionada == "Tenebroso")
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual / 2; //Divide o Dano por 2

            Debug.Log($"Atacante: {ataca.dados.nome} tem a espécie: {ataca.dados.especieSelecionada}");
            Debug.Log($"Defensor: {defende.dados.nome} tem a espécie: {defende.dados.especieSelecionada}");

            Debug.Log($"{ataca.dados.nome} com o ID: {ataca.dados.ID} aplica [{ataca.dados.ataqueAtual / 2}] de dano [Ineficaz] a {defende.dados.nome} com o ID: {defende.dados.ID}");
        }
        else
        {
            defende.dados.vidaAtual -= ataca.dados.ataqueAtual;
        }
    }
}

