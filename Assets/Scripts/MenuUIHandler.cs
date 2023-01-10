using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_InputField playersName;
    public void Awake()
    {
        scoreText.text = Manager.instance.bestScoreText;
    }
    private void Update()
    {
        Manager.instance.playersNameB = playersName.text;
    }
    public void StartGame()
    {
        Debug.Log(Manager.instance.playersNameB);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Manager.instance.Save();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
