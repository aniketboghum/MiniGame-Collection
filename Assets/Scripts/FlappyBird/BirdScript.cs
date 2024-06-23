using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D _birdRigidBody;
    [SerializeField] private float _birdVelocityStrength;
    public bool IsBirdAlive { private set; get;} = true;

    void Start()
    {
        _birdRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsBirdAlive)    _birdRigidBody.velocity = Vector2.up * _birdVelocityStrength;   
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        // Destroy(GetComponent<Rigidbody2D>());
        GameManager.Instance.ShowGameOverPanel();
        IsBirdAlive = false;
        GameManager.Instance.ReserPlayerScore();
    }
}
