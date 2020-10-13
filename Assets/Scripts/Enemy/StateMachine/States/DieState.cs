using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class DieState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider;

    private WaitForSeconds _faidInStep = new WaitForSeconds(0.01f);

    private float _boxOffDelay = 1f;
    private float _faidInDelay = 5f;
    private float _timer = 0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        Die();
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _boxOffDelay)
            _boxCollider.enabled = false;

        if (_timer >= _faidInDelay)
            StartCoroutine(FadeIn());
    }

    private void Die()
    {
        _animator.Play("Die");
    }

    private IEnumerator FadeIn()
    {
        var color = _spriteRenderer.color;

        
        for (int i = 0; i < 255; i++)
        {
            color.a -= 0.01f;

            _spriteRenderer.color = color;

            yield return _faidInStep;
        }
        Destroy(gameObject);
    }
}
