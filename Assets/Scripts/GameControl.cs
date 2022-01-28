using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    PackageCollectScript packageCollectScript;

    [Header("Objects")]
    [SerializeField] GameObject packages;

    
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI gameInfoText;
   

    float timer;

    GameObject gameOverCanvas;

    private void Awake()
    {
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
        gameOverCanvas.SetActive(false);
    }
    private void Start()
    {
        packageCollectScript = FindObjectOfType<PackageCollectScript>();
    }
    private void Update()
    {
        TimerMethod();
      
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        timer = 0;
    }
    
     public void GameOver()
    {     
        gameOverCanvas.SetActive(true);
        FindObjectOfType<CarControllerScript>().enabled = false;
        gameInfoText.text = "Score: " + packageCollectScript.score + "\n"
                           + "Time: " + timer;
            
        timerText.enabled = false;
        
    }
    void TimerMethod()
    {
        timer += Time.deltaTime;
        timerText.text = "Timer: " + (int)timer;
    }
}
