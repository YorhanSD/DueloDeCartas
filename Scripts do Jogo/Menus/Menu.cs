using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string carregaModoDeJogo;
    public string cenaReinicio;
    public GameObject telaConfiguracoes;
    public GameObject telaVersao;

    public void BotaoReinicio()
    {
        if (cenaReinicio == null)
            return;
        SceneManager.LoadScene(cenaReinicio);
    }
    public void BotaoJogar()
    {
        if (carregaModoDeJogo == null)
            return;
        SceneManager.LoadScene(carregaModoDeJogo);
    }
    public void BotaoSair()
    {
        Debug.Log("Saindo do jogo...");

        Application.Quit();
    }
    public void BotaoConfiguracoes()
    {
        if (telaConfiguracoes == null)
            return;
        telaConfiguracoes.SetActive(true);
    }
    public void BotaoVersao()
    {
        if (telaVersao == null)
            return;
        telaVersao.SetActive(true);
    }
}
