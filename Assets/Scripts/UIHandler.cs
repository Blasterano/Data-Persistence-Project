using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandler : MonoBehaviour
{
    public TMP_InputField nameText;
    public TextMeshProUGUI bestScore;

    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = "Best Score: " + DataManager.instance.highScoreName.ToString() + ": " + DataManager.instance.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Name()
    {
        DataManager.instance.playerName = nameText.text;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
