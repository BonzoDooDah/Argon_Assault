using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {
    private int _score;

    public void IncreaseScore(int scoreIncrease) {
        _score += scoreIncrease;
        Debug.Log(_score);
    }
}
