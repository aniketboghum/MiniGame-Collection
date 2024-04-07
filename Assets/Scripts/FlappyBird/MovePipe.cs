using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;
    [SerializeField] private float _DeadZone = -45;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += (Vector3.left * _MovementSpeed) * Time.deltaTime;
        if (transform.position.x < _DeadZone) Destroy(gameObject);
    }
}
