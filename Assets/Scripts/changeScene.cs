using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;

public class changeScene : MonoBehaviour
{
    public void bubbleRetry()
    {
        SceneManager.LoadScene("Level1");
    }

    public void toMenu()
    {
        SceneManager.LoadScene("List");
    }

    public void tetrisRetry()
    {
        SceneManager.LoadScene("Level");
    }

    public void startBubble()
    {
        Debug.Log("aa");
        SceneManager.LoadScene("Level1");
    }

    public void startTetris()
    {
        SceneManager.LoadScene("Level");
    }

    public void startGhost()
    {
        SceneManager.LoadScene("Ghost");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //play모드를 false로
#elif UNITY_WEBPLAYER
            Application.OpenURL("http://google.com"); // 구글 웹 전환
#else
            Application.Quit(); // 어플리케이션 종료
#endif
    }
}
