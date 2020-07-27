using EdwinGameDev;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreTextField;
    public ScriptableEvent requestScoreUpdate;
    public IntScriptableEvent receiveScoreUpdate;

    private void OnEnable()
    {
        receiveScoreUpdate.OnTriggered += UpdateScore;

        // Request event
        requestScoreUpdate.Trigger();
    }

    private void OnDisable()
    {
        receiveScoreUpdate.OnTriggered -= UpdateScore;
    }

    public void UpdateScore(int score)
    {
        scoreTextField.text = $"{score}";
    }
}
