using UnityEngine;
public class ScoreIncreamentScript : MonoBehaviour
{    
    void OnTriggerEnter2D(Collider2D bird)
    {
        if (bird.gameObject.layer == 3)    GameManager.Instance.IncrementPlayerScore(1);
    }
}
