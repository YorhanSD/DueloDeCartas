using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TransicaoAssincrona : MonoBehaviour
{
    SalvaJogoPC salvaJogoPC;
    public string cena;
    public Slider barraCarregamento;
    public TextMeshProUGUI porcentagemCarregamento;
    float multiplicador;

    private void Start()
    {
        salvaJogoPC = GetComponent<SalvaJogoPC>();
        StartCoroutine(CarregamentoAssincrono());
    }
    public IEnumerator CarregamentoAssincrono()
    {
        yield return new WaitForSeconds(5f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(salvaJogoPC.PersonagemSalvo().GetCampanhaPersonagem());
        while (!asyncOperation.isDone) {
            multiplicador = asyncOperation.progress * 100f;
            porcentagemCarregamento.text = multiplicador.ToString() + "%";
            Debug.Log("Carregamento: " + (asyncOperation.progress * 100f) + "%");
            this.barraCarregamento.value = asyncOperation.progress;
            yield return null;
        }
    }
}
