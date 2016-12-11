using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    class Stats
    {
        public const float MaxAttackSpeed = 2.0f;

        public const float MaxArmor = 1000;

        public bool IsDead => Health.ActiveValue <= 0f;

        public Stat Health { get; set; } = new Stat("Health");

        public Stat Mana { get; set; } = new Stat("Mana");

        public Stat MovementSpeed { get; set; } = new Stat("Movement Speed")
        {
            BaselineValue = 0.1f
        };

        public Stat Armor { get; set; } = new Stat("Armor");

        public Stat MagicResist { get; set; } = new Stat("Magic Resist");

        public Stat AttackDamage { get; set; } = new Stat("Attack Damage");

        public Stat AttackSpeed { get; set; } = new Stat("Attack Speed");

        public Stat ArmorPenetration { get; set; } = new Stat("Armor Penetration");

        public Stat AbilityPower { get; set; } = new Stat("Ability Power");

        public Stat MagicPenetration { get; set; } = new Stat("Magic Penetration");

        public Stat AttackRadius { get; set; } = new Stat("Attack Radius")
        {
            BaselineValue = 100.0f
        };

        internal void TakeDamage(float damageAmount)
        {
            this.Health.ActiveModifier -= damageAmount;
        }

        internal int CalculateAttackCooldown()
        {
            return 1000 - (int)(1000 * (2.0f - AttackSpeed.ActiveValue));
        }
    }
}
