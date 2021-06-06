using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float time = 3f;
    public int maxCount = 5;
    public bool start;
    public int enemyCount;
    public int Clearcount = 3;
    public float spwanTime = 1f;
    public float curTime;

    public Transform[] spawnPoints;
    public GameObject StartBtn;
    public GameObject ReplayBtn;
    public GameObject enemy;
    public TextMeshProUGUI Timetext;
    public TextMeshProUGUI Cleartext;

    public static GameManager _instance;
    private void Start()
    {

        _instance = this;
        Timetext.text = "3";
        Cleartext.text = Clearcount.ToString();
        ReplayBtn.SetActive(false);
    }
    private void Update()
    {
        if (start)
        {
            if (curTime >= spwanTime && enemyCount < maxCount)
            {
                int x = Random.Range(0, spawnPoints.Length);
                SpawnEnemy(x);
            }
            curTime += Time.deltaTime;
            if (time > 0)
            {
                time -= Time.deltaTime;
                Timetext.text = time.ToString("N0");
                Cleartext.text = Clearcount.ToString();
            }
        }
        if (time < 0 || Clearcount<1)
        {
            start = false;
            ReplayBtn.SetActive(true);
        }
       

    }
    public void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        enemyCount++;
        Instantiate(enemy, spawnPoints[ranNum]);

    }
    public void GameStartBtn()
    {
        StartBtn.SetActive(false);
        start=true;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
