using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] protected float _shootDelay;
    [SerializeField] protected Player _player;

    protected Arrow Arrow;
    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public float ShootDelay => _shootDelay;


    private void OnEnable()
    {
        _player.CurrentArrowChanged += OnCurrentArrowChanged;
    }

    private void OnDisable()
    {
        _player.CurrentArrowChanged -= OnCurrentArrowChanged;
    }

    private void OnCurrentArrowChanged(Arrow arrow)
    {
        Arrow = arrow;
    }
    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBuyed = true;
    }
}
