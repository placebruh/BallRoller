using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public GameObject GameOverPanel;
    
    public TextMeshProUGUI currentScoreText;

    int currentScore;

    void Start()
    {
        currentScore = 0;
        SetScore();
    }

    public void CallGameOver() 
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver() 
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()  
    {
        currentScore++;
        SetScore();
    }

    public void SetScore() 
    {
        currentScoreText.text = currentScore.ToString();
    }
}
