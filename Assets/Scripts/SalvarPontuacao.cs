using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class SalvarPontuacao : MonoBehaviour
{
    public TMP_InputField inputNome;

    private GameOver gameOver;
    private string nome;

    private static string BaseURI = "http://ticdemestre.com.br/estacao/";
	private static string PostURI = "game_add.php?game_chave=abc";

    void Start()
    {
        gameOver = GameObject.FindGameObjectWithTag("TelaGameOver").GetComponent<GameOver>();
    }

    public void Salvar()
    {
        nome = inputNome.text;
        string url = BaseURI + PostURI + "&gam_nome= " + nome + "&gam_pontos=" + ControladorPontuacao.Pontuacao.ToString();
        Debug.Log(url);

        StartCoroutine(PostRequest(url));
        Esconder();
        gameOver.Exibir();
    }

    public void Exibir()
    {
        this.gameObject.SetActive(true);
        
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
        
    }

    IEnumerator PostRequest(string PostUri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(PostUri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = PostUri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + "{\nReceived: " + webRequest.downloadHandler.text + "}");
                    //texto = webRequest.downloadHandler.text;
                   
                    break;
            }
        }

    }

}
