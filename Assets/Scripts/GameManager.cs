using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObtenerPreguntas("https://opentdb.com/api.php?amount=10&category=21&type=boolean"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ObtenerPreguntas(string pagWeb)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(pagWeb))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = pagWeb.Split('/');
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
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
        
    }

}