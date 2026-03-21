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
    private string campanha;

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
    public string GetCampanhaPersonagem()
    {
        return campanha;
    }
    public void SetCampanhaPersonagem(string _campanha)
    {
        campanha = _campanha;
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
