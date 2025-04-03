using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void RaceEvent();

    public static event RaceEvent raceStart, racePenalty, raceFinish, gameQuit;
    public static void CallRaceStart()
    {
        //onHit?.Invoke(); pārbaudīt, vai nav null
        if (raceStart != null)
            raceStart();
    }
    public static void CallRacePenalty()
    {
        if (racePenalty != null)
            racePenalty();
    }
    public static void CallRaceFinish()
    {
        if (raceFinish != null)
            raceFinish();
    }
    public static void CallGameQuit()
    {
        if (gameQuit!=null)
            gameQuit();
    }
}
