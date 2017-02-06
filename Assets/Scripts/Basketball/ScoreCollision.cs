﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreCollision : MonoBehaviour {

    private bool ballHasHitScoreCircle;
    public ComboManager comboManagerScript;
    public FlamesManager flamesManagerScript;

    void Start()
    {
        ballHasHitScoreCircle = false;
    }
                                
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("ScoreCircle") && !ballHasHitScoreCircle)
        {
            ScoreManager.successfulShotsInARow++;
            ScoreManager.score += ScoreManager.successfulShotsInARow * ScoreManager.points;
            ballHasHitScoreCircle = true;
            if (SceneManager.GetActiveScene().name == "NormalMode") {
                BallsManager.balls++;
            }
            else
            {
                TimerManager.timeLeft += 5f;
            }
            comboManagerScript.showText();
            flamesManagerScript.EnableFlames();
        }
        else if(other.collider.CompareTag("Environment") && !ballHasHitScoreCircle)
        {
            ScoreManager.successfulShotsInARow = 0;
            flamesManagerScript.DisableFlames();
        }
    }
}
