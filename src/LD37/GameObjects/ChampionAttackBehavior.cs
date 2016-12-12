using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class ChampionAttackBehavior : ChampionBehavior
    {
        private Coroutine _attackCooldown;
        private SoundEffect _hit1;
        private SoundEffect _hit2;
        private SoundEffect _hit3;
        private IEnumerator<SoundEffect> _nextHit;

        public override void Activate()
        {
            _hit1 = Content.Load<SoundEffect>("audio/hit1");
            _hit2 = Content.Load<SoundEffect>("audio/hit2");
            _hit3 = Content.Load<SoundEffect>("audio/hit3");
            _nextHit = NextHitSound();
        }

        private IEnumerator<SoundEffect> NextHitSound()
        {
            var rand = new Random();
            var hits = new[] { _hit1, _hit2, _hit3 };
            while (true)
            {
                yield return hits[rand.Next(0, hits.Length)];
            }
        }

        public override void Update()
        {
            if (_attackCooldown != null)
                return;

            if (Champion.SelectedAttackTarget != null)
            {
                if (Champion.SelectedAttackTarget.Stats.IsDead)
                {
                    Champion.SelectedAttackTarget = null;
                    AttackWithinProximity();
                    return;
                }
                else
                    TryAttackSelectedTarget();
            }
            else
            {
                AttackWithinProximity();
            }
        }

        private void TryAttackSelectedTarget()
        {
            if (Vector2.Distance(Champion.SelectedAttackTarget.Position, this.Transform.Position) <
                (Champion.Stats.AttackRadius.Value))
            {
                Attack(Champion.SelectedAttackTarget);
            }
        }

        private void AttackWithinProximity()
        {
            var attack = Scene.GameObjects.OfType<IChampionAttackable>()
                .FirstOrDefault(a => Vector2.Distance(Champion.Transform.Position, a.Position) < Champion.Stats.AttackRadius.Value);
            if (attack != null)
                Attack(attack);
        }

        private void Attack(IChampionAttackable attack)
        {
            _nextHit.MoveNext();
            _nextHit.Current.Play();
            
            Champion.Hand.Swing();

            var dmg = Stats.ResolveDamage(Champion.Stats, attack.Stats);
            attack.Stats.TakeDamage(dmg);

            _attackCooldown = StartCoroutine(AttackCooldown());
        }

        private IEnumerator AttackCooldown()
        {
            yield return WaitYieldInstruction.Create(Champion.Stats.CalculatedAttackCooldownWait());
            _attackCooldown = null;
        }

    }
}
