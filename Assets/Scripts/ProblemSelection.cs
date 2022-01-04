using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProblemSelection : MonoBehaviour
{
    public static ProblemSelection instance;

    public int selectedProblem { private set; get; } = 1;
    [SerializeField] Text problemText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateProblemText();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void UpdateProblemText()
    {
        problemText.text = selectedProblem.ToString();
    }

    public void UpdateSelectedProblem(int addValue)
    {
        selectedProblem += addValue;
        if (selectedProblem < 1 || selectedProblem > 9)
        {
            selectedProblem -= addValue;
            return;
        }
        UpdateProblemText();
    }

    public void OpenProblem()
    {
        SceneManager.LoadScene(selectedProblem);
    }

    public void SetSelectedProblem(int id)
    {
        selectedProblem = id;
        UpdateProblemText();
    }
}
