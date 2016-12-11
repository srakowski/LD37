using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class Stats
    {
        public Stat Health { get; set; } = new Stat();

        public bool IsDead => Health.Value <= 0;

        internal void TakeDamage(float value)
        {
            Health.ActiveModifier -= value;
        }

        public Stat AttackRadius { get; set; } = new Stat();

        public const float MaxAttackSpeed = 2.0f;

        public Stat AttackSpeed { get; set; } = new Stat();

        internal int CalculatedAttackCooldownWait()
        {
            return 800 - (int)(800 * (AttackSpeed.Value / MaxAttackSpeed));
        }

        internal static float ResolveDamage(Stats attacker, Stats attackee)
        {
            return attacker.AttackDamage.Value;
        }

        public Stat AttackDamage { get; set; } = new Stat();
    }
}
