using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;
    [SerializeField] private float _DeadZone = -45;

    void Update()
    {
        transform.position += _MovementSpeed * Time.deltaTime * Vector3.left;
        if (transform.position.x < _DeadZone) Destroy(gameObject);
    }
}
