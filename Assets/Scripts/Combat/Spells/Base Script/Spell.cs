using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Spell")]
public class Spell : ItemObject
{
    [SerializeField] string name;

    [SerializeField] int damage;
    [SerializeField] float speed;

    [SerializeField] float cooldown;
    [SerializeField] float castTime;

    [SerializeField] Sprite spellIcon;
    [SerializeField] GameObject spellEffect;
    [SerializeField] GameObject projectile;

    public string Name { get { return name; } }
    public int Damage { get { return damage; } }
    public float Speed { get { return speed; } }
    public float Cooldown { get { return cooldown; } }
    public float CastTime { get { return castTime; } }
    public Sprite SpellIcon { get { return spellIcon; } }
    public GameObject SpellEffect { get { return spellEffect; } }

    public GameObject Projectile { get { return projectile; } }

    public virtual void Cast(GameObject caster, GameObject target, Vector3 targetPosition)
    {
        // Intentionally left blank, to be overridden in child classes
    }

}