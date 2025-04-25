using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderBoards : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();
    [SerializeField] private Transform scoreTextParent;
    [SerializeField] private GameObject scoreDisplayObj;
    //[SerializeField] private GameObject leaderboards;
    public float scores;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        LoadTimes();
    }

    public void AddRaceTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveTimes();
        
        DisplayLeaderboard();
    }

    private void SaveTimes()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i< bestTimes.Count )
            {
                PlayerPrefs.SetFloat("time" + i, bestTimes[i]);
            }
            PlayerPrefs.Save();
        }
    }

    private void LoadTimes()
    {
        bestTimes = new List<float>();
        
        for (int i = 0; i < 5; i++)
        {
            bestTimes.Add(PlayerPrefs.GetFloat("time" +i, 999999));
        }
    }

    public void DisplayLeaderboard()
    {
        foreach (Transform child in scoreTextParent)
        {
            Destroy(child.gameObject);
        }

        int scoreNum = 1;
        foreach (float score in bestTimes)
        {
            TMP_Text scoreText = Instantiate(scoreDisplayObj, Vector3.zero, Quaternion.identity, scoreTextParent)
                .GetComponent<TMP_Text>();
            scoreText.text = $"{scoreNum}. {score:F2}";
            scoreNum++;
            if (scoreNum > 5)
            {
                break;
            }
        }
    }
}
