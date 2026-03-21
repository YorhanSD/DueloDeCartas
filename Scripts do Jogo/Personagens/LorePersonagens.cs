using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LorePersonagens : MonoBehaviour
{
    CriaPersonagens criaPersonagens;

    public TextMeshProUGUI textoPersonagem;

    private void Start()
    {
        criaPersonagens = GetComponent<CriaPersonagens>();
    }
   
    /*
    public bool VerificaHistoria(int _id)
    {
        if(_id == 0)
        {
            HistoriaMya();
            return false;
        }
        else if(_id == 1) 
        {
            HistoriaMcDino();
            return false;
        }
        return false;
    }
    */

    public void HistoriaMya()
    {
        textoPersonagem.text = "Mya, é uma jogadora bem conhecida " +
            "entre os comperidores e é considerada por muitos, uma das principais promessas." +
            " Há algum tempo atrás, enfrentou umas das principais patrocinadoras e atual campeã do torneio, Pandora." +
            " Ao final da partida, Mya alegou ter sido prejudicada, mas na época abafaram o caso...";
    }

    public void HistoriaMcDino()
    {
        textoPersonagem.text = "Goyan é uma arquiolago que viaja o mundo desenterrando ossos, ele também aproveita essas viagens para" +
            " coletar cartas raras. Seu arsenal é repleto de cartas incomuns e poderosas.";
    }

    public void HistoriaCharlotte()
    {
        textoPersonagem.text = "Charlotte tem um péssimo temperamento e isso se deve à sua relação com seu pai, Phillip Manson." +
            " Manson a treinou desde muito pequena para que ela se tornasse a melhor, como um dia ele já havia sido." +
            " Com um rígido treinamento e privada de qualquer diversão, ela desenvolveu incriveis habilidades e bastante raiva de seu pai. " +
            " Já mais velha, Charlotte abandonou o treinamento e seguiu seu próprio caminho, escondendo seu sobrenome de todos.";
    }

    public void HistoriaHekaib()
    {
        textoPersonagem.text = "Hekaib é um competidor misterioso, pouco se sabe sobre sua vida, mas que por onde passa, deixa a sua marca." +
            " Seu estilo de jogo intimidador é bem conhecido, sua estratégia nas batalhas é parecida com a de Pandora, o que geram boatos" +
            " no qual ele seria um dicípulo dela.";
    }
}
