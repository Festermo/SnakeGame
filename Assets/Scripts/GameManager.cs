using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Text crystalCounter;
    public Text foodCounter;
    public Snake snake;
    public GameObject endPanel;
    private float feverTimer = 0; //time from last eaten crystal
    private int crystalsInRow = 0;
    public int crystalScore { get; set; }
    public int foodScore { get; set; }

    IEnumerator Fever()
    {
        snake.inFever = true;
        snake.speed *= 3;
        yield return new WaitForSeconds(5);
        snake.inFever = false;
        snake.speed /= 3;
        crystalScore = 0;
        crystalCounter.text = "0";
    }

    public void EatCrystal()
    {
        crystalScore++;
        crystalCounter.text = (crystalScore * 10).ToString();
        if (feverTimer <= 3f)
            crystalsInRow += 1;
        else
            crystalsInRow = 1;
        feverTimer = 0;
        if (crystalsInRow > 3 && snake.inFever == false)
        {
            crystalsInRow = 0;
            StartCoroutine(Fever());
        }
    }

    public void increaseFoodScore()
    {
        foodScore++;
        foodCounter.text = foodScore.ToString();
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
    }

    private void Update()
    {
        feverTimer += Time.deltaTime;
    }
}
