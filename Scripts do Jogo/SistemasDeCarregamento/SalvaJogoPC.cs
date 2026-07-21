using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SalvaJogoPC : MonoBehaviour
{
    public bool jaSalvou = false;
    TelaPariamento telaPariamento;

    private void Awake()
    {
        telaPariamento = GetComponent<TelaPariamento>();
        carregaPersonagemEscolhido();
    }

    public void carregaPersonagemEscolhido()
    {
        SalvaEscolhaPersonagem personagemEscolhido = PersonagemSalvo();

        if (telaPariamento != null)
        {
            telaPariamento.mudaFoto(personagemEscolhido.GetPersonagemEscolhido());
            telaPariamento.mudaNome(personagemEscolhido.GetNomePersonagemEscolhido().ToString());
        }
    }

    public void Salvar(SalvaEscolhaPersonagem _newSave)
    {
        _newSave.GetPersonagemEscolhido();
        _newSave.GetNomePersonagemEscolhido();
        SalvarJogoBinario(_newSave);
        SalvaEscolhaPersonagem personagemEscolhido = PersonagemSalvo();
    }
 
    public void SalvaOponente(SalvaOponente _newSave)
    {
        _newSave.GetOponenteEscolhido();
        _newSave.GetOponenteEscolhido();
        SalvaOponenteBinario(_newSave);
        SalvaOponente oponenteEscolhido = OponenteSalvo();
    }

    public void SalvaOponenteEscolhido(int _id, bool _eOponente, string _nome, string _pais, string _especieRecessiva, string _especieDominante)
    {
        SalvaOponente newSave = new SalvaOponente();
        newSave.SetOponenteEscolhido(_id);
        newSave.SetEOponente(_eOponente);
        newSave.SetNomeOponenteEscolhido(_nome);
        newSave.SetPais(_pais);
        newSave.SetEspecieRecessiva(_especieRecessiva);
        newSave.SetEspecieDominente(_especieDominante);
        SalvaOponente(newSave);
    }
 
    public void SalvaPersonagemEscolhido(int _id, string _nome, string _pais, string _especieRecessiva, string _especieDominante)
    {
        SalvaEscolhaPersonagem newSave = new SalvaEscolhaPersonagem();
        newSave.SetPersonagemEscolhido(_id);
        newSave.SetNomePersonagemEscolhido(_nome);
        newSave.SetPais(_pais);
        newSave.SetEspecieRecessiva(_especieRecessiva);
        newSave.SetEspecieDominente(_especieDominante);
        Salvar(newSave);
    }

    public void SalvarJogoBinario(SalvaEscolhaPersonagem _newSave)
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;//AppData/LocalLow/SeuNome

        FileStream arquivo = File.Create(caminho + "/PersonagemSalvo.save");

        bF.Serialize(arquivo, _newSave);

        arquivo.Close();

        Debug.Log("Personagem Escolhido Salvo!");
    }

    public void SalvaOponenteBinario(SalvaOponente _newSave)
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;//AppData/LocalLow/SeuNome

        FileStream arquivo = File.Create(caminho + "/OponenteSalvo.save");

        bF.Serialize(arquivo, _newSave);

        arquivo.Close();

        Debug.Log("Oponente Salvo!");
    }
    
    public SalvaEscolhaPersonagem PersonagemSalvo()
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;

        FileStream arquivo;

        if (File.Exists(caminho + "/PersonagemSalvo.save"))
        {
            arquivo = File.Open(caminho + "/PersonagemSalvo.save", FileMode.Open);

            SalvaEscolhaPersonagem personagemEscolhido = (SalvaEscolhaPersonagem)bF.Deserialize(arquivo);

            arquivo.Close();

            Debug.Log("Personagem Escolhido Carregado");

            return personagemEscolhido;
        }

        return null;
    }

    public SalvaOponente OponenteSalvo()
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;

        FileStream arquivo;

        if (File.Exists(caminho + "/OponenteSalvo.save"))
        {
            arquivo = File.Open(caminho + "/OponenteSalvo.save", FileMode.Open);

            SalvaOponente oponenteEscolhido = (SalvaOponente)bF.Deserialize(arquivo);

            arquivo.Close();

            Debug.Log("Oponente Carregado");

            return oponenteEscolhido;
        }

        return null;
    }
   
}

