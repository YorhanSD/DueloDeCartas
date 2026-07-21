using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaPersonagem : MonoBehaviour
{
    SalvaJogoPC salvaJogoPC;
    CriaPersonagens criaPersonagens;

    public Image fotoPersonagem;
    public Text nomePersonagem;
    public Text idade;
    public Text pais;
    public Text profissao;
    public Text lore;
    public Text especieDominante;
    public bool clicouHistoria = false;
    public string carregaCenaPariamento;
    public GameObject tela;

    private int idSelecionado;
   

    void Start()
    {
        salvaJogoPC = GetComponent<SalvaJogoPC>();
        criaPersonagens = GetComponent<CriaPersonagens>();
    }

    public void Tela(Image _fotoPersonagem, string _nome, string _idade, string _pais, string _profissao, string _lore, string _especieDominante)
    {
        fotoPersonagem = _fotoPersonagem;
        nomePersonagem.text = " Nome: " + _nome;
        idade.text = " Idade: " + _idade;
        pais.text = " País: " + _pais;
        profissao.text = " Profissão: " + _profissao;
        lore.text = " Lore: " + _lore;
        especieDominante.text = _especieDominante;
    }

    public void BotaoHistoria()
    {
        clicouHistoria = !clicouHistoria;

        nomePersonagem.gameObject.SetActive(!clicouHistoria);
        idade.gameObject.SetActive(!clicouHistoria);
        pais.gameObject.SetActive(!clicouHistoria);
        profissao.gameObject.SetActive(!clicouHistoria);
        lore.gameObject.SetActive(clicouHistoria);
    }

    public void SetPersonagemSelecionado(int _ID)
    {
        idSelecionado = _ID;
    }

    public int GetPersonagemSelecionado()
    {
        return idSelecionado;
    }

    public void EspeciesSelecionadas(Personagem _personagem)
    {
        salvaJogoPC.SalvaPersonagemEscolhido(_personagem.id, _personagem.nome, _personagem.pais,_personagem.elencoRecessivo,_personagem.elencoDominante);
    }
    public void BotaoTudoPronto()
    {
        SceneManager.LoadScene(carregaCenaPariamento);
    }
    public void AbreTela()
    {
        tela.SetActive(true);
    }
    public void BotaoRetornar()
    {
        tela.SetActive(false);
    }
}
