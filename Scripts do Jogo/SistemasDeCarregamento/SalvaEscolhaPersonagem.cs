using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SalvaEscolhaPersonagem
{
    private int idPersonagem;
    private string nomePersonagem;
    private string pais;
    private string especieRecessiva;
    private string especieDominante;

    public void SetEspecieDominente(string _especieDominante)
    {
        especieDominante = _especieDominante;
    }
    public string GetEspecieDominante()
    {
        return especieDominante;
    }
    public void SetEspecieRecessiva(string _especieRecessiva)
    {
        especieRecessiva = _especieRecessiva;
    }
    public string GetEspecieRecessiva()
    {
        return especieRecessiva;
    }
    public void SetNomePersonagemEscolhido(string _nomePersonagem)
    {
        nomePersonagem = _nomePersonagem;
    }
    public string GetNomePersonagemEscolhido()
    {
        return nomePersonagem;
    }
    public void SetPersonagemEscolhido(int _idPersonagem)
    {
        idPersonagem = _idPersonagem;
    }
    public int GetPersonagemEscolhido() 
    {  
        return idPersonagem; 
    }
    public string GetPais()
    {
        return pais;
    }
    public void SetPais(string _pais)
    {
        pais = _pais;
    }
}
