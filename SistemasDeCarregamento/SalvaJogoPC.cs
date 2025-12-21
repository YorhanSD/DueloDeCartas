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
        //if (jaSalvou == false)
        //{
        _newSave.GetPersonagemEscolhido();
        _newSave.GetNomePersonagemEscolhido();
        _newSave.GetCampanhaPersonagem();
        SalvarJogoBinario(_newSave);
        SalvaEscolhaPersonagem personagemEscolhido = PersonagemSalvo();

        //jaSalvou = true;
        //}
    }

    public void SalvaPersonagemEscolhido(int _id, string _nome, string _campanha, string _pais)
    {
        SalvaEscolhaPersonagem newSave = new SalvaEscolhaPersonagem();
        newSave.SetPersonagemEscolhido(_id);
        newSave.SetNomePersonagemEscolhido(_nome);
        newSave.SetCampanhaPersonagem(_campanha);
        newSave.SetPais(_pais);
        Salvar(newSave);
    }

    public void SalvarJogoBinario(SalvaEscolhaPersonagem _newSave)
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;//AppData/LocalLow/SeuNome

        FileStream arquivo = File.Create(caminho + "/PlayerSave.save");

        bF.Serialize(arquivo, _newSave);

        arquivo.Close();

        Debug.Log("Jogo Salvo!");
    }

    public SalvaEscolhaPersonagem PersonagemSalvo()
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;

        FileStream arquivo;

        if (File.Exists(caminho + "/PlayerSave.save"))
        {
            arquivo = File.Open(caminho + "/PlayerSave.save", FileMode.Open);

            SalvaEscolhaPersonagem personagemEscolhido = (SalvaEscolhaPersonagem)bF.Deserialize(arquivo);

            arquivo.Close();

            Debug.Log("Jogo Carregado");

            return personagemEscolhido;
        }

        return null;
    }
}
