using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipes;
    [SerializeField] private float _spawnrate = 2;
    private float _timer = 0;
    [SerializeField] private float _heightOffset = 10;
    void Start()
    {
        SpawnPipes();
    }
    void Update()
    {
        if (_timer < _spawnrate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipes();
            _timer = 0;
        }
    }
    void SpawnPipes()
    {
        var lowPoint = transform.position.y - _heightOffset;
        var highPoint = transform.position.y + _heightOffset;
        Instantiate(_pipes, new Vector3(transform.position.x, Random.Range(lowPoint, highPoint), 0), Quaternion.identity);
    }
}
