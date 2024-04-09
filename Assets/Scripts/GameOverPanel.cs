using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highScoreText;

    public void OnPlayAgainButtonClicked()
    {
        GameManager.Instance.OpenScene((int) GameManager.CurrentScene);
    }

    public void SetHighScore()
    {
        _highScoreText.text += GameManager.Instance.GetHighScore();
    }
}
