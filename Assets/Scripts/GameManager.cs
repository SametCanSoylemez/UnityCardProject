using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    const int QUESTION_COUNT = 4;

    char[,] answers = new char[QUESTION_COUNT, 2];

    void Start()
    {
        answers[0, 0] = '4';

        answers[1, 0] = '2';
        answers[1, 1] = '8';

        answers[2, 0] = '1';
        answers[2, 1] = '9';

        answers[3, 0] = '5';
    }

    public bool[] CheckAnswers(TMP_InputField[] answerInputs)
    {
        bool[] results = new bool[QUESTION_COUNT];

        for(int i = 0; i < answerInputs.Length; i++)
        {
            if (answerInputs[i].text.Length == 1 && answers[i, 1] == 0)
            {
                if (answerInputs[i].text[0] == answers[i, 0]) results[i] = true;
                else results[i] = false;
            }
            else if (answerInputs[i].text.Length > 1)
            {
                int number = 0;
                int lastNumber = -1;
                bool[] check = new bool[2];

                for (int j = 0; j < answerInputs[i].text.Length; j++)
                {
                    if (char.IsNumber(answerInputs[i].text[j]))
                    {
                        if (number > 1)
                        {
                            check[0] = false;
                            check[1] = false;
                            break;
                        }
                        if (lastNumber != 0 && answerInputs[i].text[j] == answers[i, 0])
                        {
                            lastNumber = 0;
                            check[number] = true;
                        }
                        else if (lastNumber != 1 && answerInputs[i].text[j] == answers[i, 1])
                        {
                            lastNumber = 1;
                            check[number] = true;
                        }
                        number++;
                    }
                }

                if (check[0] && check[1]) results[i] = true;
                else results[i] = false;
            }
            else results[i] = false;
        }

        return results;
    }
}