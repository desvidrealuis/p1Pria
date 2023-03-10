using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(ObtenerPreguntas("https://opentdb.com/api.php?amount=10&category=21&type=boolean"));
    }

    private IEnumerator ObtenerPreguntas(string pagWeb) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(pagWeb)) {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = pagWeb.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result) {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Preguntas preguntasDescargadas = JsonUtility.FromJson<Preguntas>(webRequest.downloadHandler.text);
                    Debug.Log($"Preguntas solicitadas: "+ preguntasDescargadas.results.Count);
                    Debug.Log($"Dificultad: {preguntasDescargadas.results[0].difficulty}" + "\n" +
                    $"Cuestión: {preguntasDescargadas.results[0].question}" + "\n" +
                    $"Respuesta correcta: {preguntasDescargadas.results[0].correct_answer}" + "\n" +
                    $"Respuestea incorrecta: {preguntasDescargadas.results[0].incorrect_answers[0]}");
                    break;
            }
        }
    }
}