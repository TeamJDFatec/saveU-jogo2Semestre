using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Placar : MonoBehaviour
{
    [System.Serializable]
    public class PlacarJogador
    {
        public string gamChave;
        public string gamNome;
        public string gamPontos;


        public PlacarJogador(){}

        public PlacarJogador(string gamNome, string gamPontos)
        {
            this.gamNome = gamNome;
            this.gamPontos = gamPontos;
        }

    }

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<PlacarJogador> placarJogador = new List<PlacarJogador>();

    private static string BaseURI = "http://ticdemestre.com.br/estacao/";
	private static string GetURI = "game_view.php?game_chave=saveu";

    private int maxRanking = 10;

    private string texto;

    private void Awake() 
    { 
        BuscaPlacar(); 
        //PreenchePlacar();
    }

    void PreenchePlacar()
    {

        entryContainer = transform.Find("PlacarContainer");
        entryTemplate = entryContainer.Find("PlacarTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateAltura = 20f;

        Debug.Log(BaseURI + GetURI);
        Debug.Log(placarJogador.Count);

        for (int i = 0; i < placarJogador.Count; i++)
        {
            if (i == maxRanking)
            {
                break;
            }

            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateAltura * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;

            string rankingString;

            switch (rank)
            {
                
                default:
                    rankingString = rank + "TH";
                    break;
                case 1: rankingString = "1ST"; break;
                case 2: rankingString = "2ND"; break;
                case 3: rankingString = "3RD"; break;
            }

            entryTransform.Find("posicaoTexto").GetComponent<Text>().text = rankingString;
            entryTransform.Find("pontosTexto").GetComponent<Text>().text = placarJogador[i].gamPontos;
            entryTransform.Find("nomeTexto").GetComponent<Text>().text = placarJogador[i].gamNome;
        }

    }

    public void BuscaPlacar()
	{	
		StartCoroutine(GetRequest(BaseURI + GetURI));
	}

    IEnumerator GetRequest(string GetUri)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(GetUri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = GetUri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    //Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(pages[page] + "{\nReceived: " + webRequest.downloadHandler.text + "}");
                    texto = webRequest.downloadHandler.text;
                    
                    //Debug.Log(texto);

                    var list = Newtonsoft.Json.JsonConvert.DeserializeObject<PlacarJogador[]>(texto);

                    foreach (var value in list)
                    {
                        //Debug.Log(value.gamChave.ToString());
                        //Debug.Log(value.gamNome.ToString());
                        //Debug.Log(value.gamPontos.ToString());

                        string nome = value.gamNome.ToString();
                        string pontos = value.gamPontos.ToString();

                        placarJogador.Add(new PlacarJogador(nome, pontos));
                        //score.text = "\n\n" + value.gamNome.ToString() + " - " + value.gamPontos.ToString();
                    }

                    break;
            }
        }

        PreenchePlacar();
    }
	
    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }

}
