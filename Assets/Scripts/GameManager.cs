using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObtenerPreguntas("https://opentdb.com/api.php?amount=50&category=25&difficulty=medium&type=multiple"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private IEnumerator ObtenerPreguntas(string pagWeb)
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Función corrutinta prueba");
    }

}
