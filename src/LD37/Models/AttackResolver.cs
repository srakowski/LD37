using System;
using System.Collections.Generic;
using System.Text;
using LD37.GameObjects;

namespace LD37.Models
{
    static class AttackResolver
    {
        internal static void ResolvePhysicalAttack(IAttackable attacker, IAttackable attacked)
        {
            var damageAmount = attacker.Stats.AttackDamage.ActiveValue;

            var armorPen = attacker.Stats.ArmorPenetration.ActiveValue;

            var armor = attacked.Stats.Armor.ActiveValue;

            var resistence = .75f * ((armor * armorPen) / Stats.MaxArmor);

            damageAmount -= (damageAmount * resistence);

            attacked.Stats.TakeDamage(damageAmount);
        }
    }
}
