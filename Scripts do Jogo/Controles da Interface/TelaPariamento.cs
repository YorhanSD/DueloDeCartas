using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TelaPariamento : MonoBehaviour
{
    public TextMeshProUGUI nome;

    public TextMeshProUGUI pais;

    public TextMeshProUGUI nomeOponente;

    public TextMeshProUGUI paisOponente;

    public GameObject[] fotos;
    public GameObject[] fotosOponentes;

    SalvaJogoPC salvaJogoPC;

    private void Awake()
    {
        salvaJogoPC = GetComponent<SalvaJogoPC>();

        if (salvaJogoPC != null)
        {
            mudaFoto(salvaJogoPC.PersonagemSalvo().GetPersonagemEscolhido());
            mudaNome(salvaJogoPC.PersonagemSalvo().GetNomePersonagemEscolhido());
            mudaPais(salvaJogoPC.PersonagemSalvo().GetPais());

            mudaFotoOponente(salvaJogoPC.OponenteSalvo().GetOponenteEscolhido());
            mudaNomeOponente(salvaJogoPC.OponenteSalvo().GetNomeOponenteEscolhido());
            mudaPaisOponente(salvaJogoPC.OponenteSalvo().GetPais());
        }
        else
        {
            Debug.Log("SalvaJogoPC é nulo");
        }
    }
    public void mudaFoto(int _id)
    {
        if (fotos != null)
        {
            fotos[_id].SetActive(true);
        }
    }
    public void mudaNome(string _nome)
    {
        if (nome != null)
        {
            nome.text = _nome;
        }
    }
    public void mudaPais(string _pais)
    {
        if (pais != null)
        {
            pais.text = _pais;
        }
    }

    public void mudaFotoOponente(int _idOponente)
    {
        if (fotosOponentes != null)
        {
            fotosOponentes[_idOponente].SetActive(true);
        }
    }
    public void mudaNomeOponente(string _nomeOponente)
    {
        if (nomeOponente != null)
        {
            nomeOponente.text = _nomeOponente;
        }
    }
    public void mudaPaisOponente(string _paisOponente)
    {
        if (paisOponente != null)
        {
            paisOponente.text = _paisOponente;
        }
    }
}
