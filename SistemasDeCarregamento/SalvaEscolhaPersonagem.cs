using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SalvaEscolhaPersonagem
{
    private int idPersonagem;
    private string nomePersonagem;

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
}
