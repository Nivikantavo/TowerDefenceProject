using UnityEngine;

public class PoisonedArrow : Arrow
{
    [SerializeField] private int _poisonDamag;
    [SerializeField] private int _poisoningDuration;
    [SerializeField] private int _poisonStep;
    public override void SpecialEffect(Enemy enemy)
    {
        if(!enemy.TryGetComponent(out Poison poison))
        {
            poison = enemy.gameObject.AddComponent<Poison>();
            poison.SetFields(_poisoningDuration, _poisonDamag, _poisonStep);
        }
        else
        {
            if(poison.enabled == true)
            {
                poison.enabled = false;
                poison.enabled = true;
            }
            else
            {
                poison.enabled = true;
            }
        }
    }

}
