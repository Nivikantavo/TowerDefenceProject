using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private GameObject _shield;

    private int _shieldStrenght;

    private void Start()
    {
        _shieldStrenght = _shield.GetComponent<Shield>().Strenght;
    }
    void Update()
    {
        if (_shieldStrenght<=0)
            NeedTransit = true;
    }
}
