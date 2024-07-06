using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoleController : MonoBehaviour
{
    [SerializeField] private GameObject[] _moles;
#if UNITY_EDITOR
    [SerializeField] private float _gameTime =  5f;
#else
    [SerializeField] private float _gameTime =  60f;
#endif
    [SerializeField] private float _visibilityTime;

    // [SerializeField] private Text _timerText;

    void Start()
    {
        StartCoroutine(SpawnMoles());
    }

    void Update()
    {
        _gameTime -= Time.deltaTime;
        // _timerText.text = string.Format("Time: {0:00.0}", _gameTime);
    }

    IEnumerator SpawnMoles()
    {
        while (true) 
        {
            while (GameManager.Instance.IsCurrentGamePaused)
            {
                yield return null;
            }

            var numberOfMolesToSpawn = UnityEngine.Random.Range(1, 4);

            for (int i=0; i<numberOfMolesToSpawn; i++)
            {
                var moleIndex = UnityEngine.Random.Range(0, _moles.Length);
                StartCoroutine(SpawnMole(moleIndex));
            }

            if (_gameTime <= 0f)
            {
                StopAllCoroutines();
                GameManager.Instance.ResetPlayerScore();
                GameManager.Instance.ShowGameOverPanel();
            }
                       
            yield return new WaitForSecondsRealtime(1);
        }
    }

    IEnumerator SpawnMole(int moleIndex)
    {
        _moles[moleIndex].GetComponent<Mole>().SetDefaultSprite();
        Animator animator = _moles[moleIndex].GetComponent<Animator>();
        animator.Play("anim0");
        _moles[moleIndex].GetComponent<BoxCollider2D>().enabled = true;

        yield return new WaitForSecondsRealtime(_visibilityTime);

        animator.Play("anim1");
        _moles[moleIndex].GetComponent<BoxCollider2D>().enabled = false;

        yield break;
    }
}