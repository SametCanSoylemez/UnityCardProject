using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    const int QUESTION_COUNT = 4;

    GameManager gm;
    [SerializeField] TMP_InputField[] inputs = new TMP_InputField[QUESTION_COUNT];
    [SerializeField] GameObject finishPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void FinishGameButton()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        bool[] answers = gm.CheckAnswers(inputs);
        SetInputColours(answers);
    }

    void SetInputColours(bool[] ans)
    {
        bool allTrue = true;

        for (int i = 0; i < ans.Length; i++)
        {
            if (ans[i]) inputs[i].image.color = Color.green;
            else
            {
                inputs[i].image.color = Color.red;
                allTrue = false;
            }
        }

        if (allTrue) StartCoroutine(OpenFinishPanel());
    }

    IEnumerator OpenFinishPanel()
    {
        yield return new WaitForSeconds(1f);
        finishPanel.SetActive(true);
    }
}