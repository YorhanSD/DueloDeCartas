using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
    public string cena;
    public GameObject telaConfig;
    public void BotaoJogar()
    {
        SceneManager.LoadScene(cena);
    }
    public void BotaoConfiguracoes()
    {
        if(telaConfig != null) 
        {
            telaConfig.SetActive(true);
        }
    }
    public void BotaoVoltar()
    {
        if (telaConfig != null)
        {
            telaConfig.SetActive(false);
        }
    }
}
