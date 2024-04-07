using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void OnClickPlayAgainButton()
    {
        GameManager.Instance.OpenScene((int) GameManager.CurrentScene);
    }
}
