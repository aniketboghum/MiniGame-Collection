using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private Sprite _hitSprite;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private SpriteRenderer _moleSpriteRenderer;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnMouseDown()
    {
        _moleSpriteRenderer.sprite = _hitSprite;
        _animator.Play("anim1");
    }

    public void SetDefaultSprite()
    {
        _moleSpriteRenderer.sprite = _defaultSprite;
    }
}
