using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TelaPariamento : MonoBehaviour
{
    public TextMeshProUGUI nome;

    public GameObject[] fotos;

    SalvaJogoPC salvaJogoPC;

    private void Awake()
    {
        salvaJogoPC = GetComponent<SalvaJogoPC>();

        if (salvaJogoPC != null)
        {
            mudaFoto(salvaJogoPC.PersonagemSalvo().GetPersonagemEscolhido());
            mudaNome(salvaJogoPC.PersonagemSalvo().GetNomePersonagemEscolhido());
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
}
