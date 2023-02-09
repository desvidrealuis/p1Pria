using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Pregunta {
    public string category;
    public string type;
    public string difficulty;
    public string question;
    public string correct_answer;
    public string[] incorrect_answers;
}
