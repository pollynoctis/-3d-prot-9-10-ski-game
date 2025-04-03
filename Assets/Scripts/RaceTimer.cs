using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private LeaderBoards leaderboards;
    [SerializeField] private float penaltyTime = 1f;
    
    private bool timerRunning = false;
    private float raceTime = 0f;
    

    private void OnEnable()
    {
        GameManager.raceStart += StartRaceTimer;
        GameManager.raceFinish += StopRaceTimer;
        GameManager.racePenalty += RacePenalty;
    }
    private void OnDisable()
    {
        GameManager.raceStart -= StartRaceTimer;
        GameManager.raceFinish -= StopRaceTimer;
        GameManager.racePenalty -= RacePenalty;

    }

    private void StartRaceTimer()
    {
        raceTime = 0f;
        timerRunning = true;
        print("race started");
    }

    private void StopRaceTimer()
    {
        timerRunning = false;
        GameData.Instance.racesCompleted++;
        leaderboards.AddRaceTime(raceTime);
        
        print("Race finished. Race time: " + raceTime);
        print("Races completed: " + GameData.Instance.racesCompleted);
    }

    private void RacePenalty()
    {
        raceTime += penaltyTime;
        print("penalty");
    }


    private void FinishUI()
    {
        
    }

    private void Update()
    {
        if (timerRunning)
        {
            raceTime += Time.deltaTime;
        }
    }
}
