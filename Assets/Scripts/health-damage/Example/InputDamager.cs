using UnityEngine;

/// <summary>
/// Dummy class - DO NOT USE - It's purpose is just to demonstrate how to use the DealDamage
/// </summary>
public class InputDamager : DamageComponent
{
    [SerializeField] private DamageableEntity damageable;
    [SerializeField] KeyCode damageKey = KeyCode.A;
    private void Update()
    {
        if (Input.GetKeyDown(damageKey))
        {
            DealDamage(damageable);
        }
    }
}
