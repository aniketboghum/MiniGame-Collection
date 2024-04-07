using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D _BirdRigidBody;
    [SerializeField] private float BirdVelocityStrength;
    private bool isBirdAlive = true;

    void Start()
    {
        _BirdRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isBirdAlive)    _BirdRigidBody.velocity = Vector2.up * BirdVelocityStrength;   
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        GameManager.Instance.ShowGameOverPanel();
        isBirdAlive = false;
        // GameManager.ReserPlayerScore();
    }
}
