using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    private int _score;
    private Text _textScore;

    private void Start() {
        _textScore = GetComponent<Text>();
        _textScore.text = _score.ToString("0000000000");
    }

    public void IncreaseScore(int scoreIncrease) {
        _score += scoreIncrease;
        _textScore.text = _score.ToString("0000000000");
    }
}
