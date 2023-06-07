using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System.Data;

public class Spawn : MonoBehaviour
{
    public List<GameObject> gameObjectList;
    //public TextMeshProUGUI scoreText;
    private int score = 0;
    bool gameOver = false;
    private int gameOverCounter = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
    //    scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        while (!gameOver)
        {
        //    scoreText.text = "Score:" + score;
            if (gameOverCounter < 0)
            {
                gameOver = true;
            }
        }

    }
    public void UpdateScore(int value, int reduceChances)
    {
    //    score = score + value;
        gameOverCounter = gameOverCounter - reduceChances;
    //    Debug.Log(score);
    }
    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, gameObjectList.Count);
            Instantiate(gameObjectList[index]);
        }
    }
}
