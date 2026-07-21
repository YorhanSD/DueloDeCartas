using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SistemaCombate : MonoBehaviour
{
    Trava_Casas travaCasas;
    //MONOBEHAVIOUR NÃO PODE SER CRIADO COM NEW
    BancoCards bancoCartas;

    [SerializeField] private ControlaTurnos controlaTurnos;

    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    Case casa;

    ControlePontos controlePontos;

    Energia energia;

    public bool travarJogador = false;

    [System.Obsolete]
    public void Start()
    {
        travaCasas = GetComponent<Trava_Casas>();

        casa = FindObjectOfType<Case>();

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
            GravaUltimoID(ataca);

            ataca.SetPodeAtacar(false);
            ataca.SetMoveuSe(true);
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
        }
        else if (controlaTurnos.turnoOponente == true && ataca.CompareTag("Carta Oponente") && defende.CompareTag("Carta Jogador"))
        {

            GravaUltimoID(ataca);

            ataca.SetPodeAtacar(false);
            ataca.SetMoveuSe(true);
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
        }

    }


    void Retorno(CartaDaCena _ataca, CartaDaCena _defende)
    {
        if (_defende.dados.vidaAtual > 0)
        {
            foreach (Case casaB in ia_MapeamentoDeCases.listaCase)
            {
                if (casaB.GetUltimoID() == _ataca.dados.ID) //Casa mais próxima
                {
                    _ataca.transform.SetParent(casaB.gameObject.transform, false);
                    _ataca.transform.localPosition = Vector3.zero;
                    _ataca.SetMoveuSe(true);
                }
            }
        }
    }
    void GravaUltimoID(CartaDaCena _ataca)
    {
        foreach (Case casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetIDCartaOcupante() == _ataca.dados.ID)
            {
                casa.SetUltimoID(_ataca.dados.ID); //Grava o id da carta atacante na sua própria casa
            }
        }
    }
    void VerificaMorte(CartaDaCena _ataca, CartaDaCena _defende)
    {
        if (_defende.dados.vidaAtual <= 0)
        {
          MoveCartaParaACasaQueDestruiuOCard(_ataca, _defende);
        }
        else
        {
          Retorno(_ataca, _defende);
        }
    }
    public void MoveCartaParaACasaQueDestruiuOCard(CartaDaCena ataca, CartaDaCena defende)
    {
        Case casaDefensor = null;

        foreach (Case casa in ia_MapeamentoDeCases.listaCase)
        {
            if (casa.GetIDCartaOcupante() == defende.dados.ID)
            {
                casaDefensor = casa;
                break;
            }
        }

        if (casaDefensor == null) return;

        // MOVE atacante
        ataca.transform.SetParent(casaDefensor.transform);
        ataca.transform.localPosition = Vector3.zero;

        // ATUALIZA A CASA
        casaDefensor.SetIDCartaOcupante(ataca.dados.ID);

        if (ataca.CompareTag("Carta Jogador"))
        {
            casaDefensor.SetCaseOcupadoJogador(true);
            casaDefensor.SetCaseOcupadoOponente(false);
        }
        else
        {
            casaDefensor.SetCaseOcupadoOponente(true);
            casaDefensor.SetCaseOcupadoJogador(false);
        }

        // ATUALIZA OCUPANTE INTERNO
        casaDefensor.SetCartaOcupante(ataca);

        // REMOVE defensor
        bancoCartas.geralCartaRuntimeLista.Remove(defende.dados);
        bancoCartas.geralCartaCenaLista.Remove(defende);

        Destroy(defende.gameObject);

        ataca.SetMoveuSe(true);
    }

    public void VerificaCouraca(CartaDaCena _ataca, CartaDaCena _defende)
    {
        if (_defende.dados.couracaAtual <= 0)
        {
            ChecaEspecie(_ataca, _defende);
            //VerificaMorte(_ataca,_defende);
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
        }
        else
        {
            //_ataca.dados.vidaAtual -= _defende.dados.reacao;
            _ataca.uiCarta.AtualizarUI(_ataca.dados);
            //VerificaMorte(_defende, _ataca);
        }

        Debug.Log($"Atacante: {_ataca.dados.nome} sofre: {_defende.dados.reacao} de Dano de Reação da Carta: {_defende.dados.reacao}");
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
        else if(ataca.dados.especieSelecionada == "Tenebroso" && defende.dados.especieSelecionada == "Celestial")
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

