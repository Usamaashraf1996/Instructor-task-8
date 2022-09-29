using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> target;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool isGameActive;
    private float time = 8f;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        updatescore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= -10)
        {

            GameOver();
        }
        else if (score >= 10) {

            Win();
        }

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(time);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);
        }
    }
    public void updatescore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = "Score: " + score;

    }
    public void GameOver() { 
    
    isGameActive=false;
        gameOverText.gameObject.SetActive(true);
    }
    public void Win() { 
    
    WinText.gameObject.SetActive(true);
    }
    
   
}
