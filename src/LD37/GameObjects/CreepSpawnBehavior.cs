using Coldsteel.Fluent;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class CreepSpawnBehavior : Behavior
    {
        private Coroutine _spawnTask = null;

        public bool IsActive { get; set; } = true;

        public int TimeBetweenCreepSpawns { get; set; } = 1000;

        public int TimeBetweenWaves { get; set; } = 30000;

        public int NumCreepsToSpawn { get; private set; } = 10;

        public bool IsDestroyed => GameObject?.IsDestroyed ?? true;

        private ICreepAttackable _ultimateTarget;

        private SoundEffect _spawnSound;

        public CreepSpawnBehavior(ICreepAttackable ultimateTarget, int level)
        {
            _ultimateTarget = ultimateTarget;
            TimeBetweenCreepSpawns = MathHelper.Clamp(level * 1000, 0, 5000);
            NumCreepsToSpawn = MathHelper.Clamp(level, 1, 20);
        }

        public override void Activate()
        {
            _spawnSound = Content.Load<SoundEffect>("audio/spawn");
        }

        public override void Update()
        {
            CheckDestroyed();
            if (IsActive && _spawnTask == null && !IsDestroyed)
                _spawnTask = StartCoroutine(SpawnCreeps());
        }

        private void CheckDestroyed()
        {
            if (IsDestroyed && _spawnTask != null)
            {
                _spawnTask.Stop();
                _spawnTask = null;
            }
        }
        private IEnumerator SpawnCreeps()
        {
            while (true)
            {
                if ((GameObject as CreepSpawn).IsEnabled)
                {
                    // Spawn wave.
                    for (var i = 0; i < NumCreepsToSpawn; i++)
                    {
                        _spawnSound.Play();
                        SpawnCreep();
                        yield return WaitYieldInstruction.Create(TimeBetweenCreepSpawns);
                    }
                    // Wait to spawn next wave.
                    yield return WaitYieldInstruction.Create(TimeBetweenWaves);
                }
                else
                {
                    yield return WaitYieldInstruction.Create(1000);
                }
            }
        }

        private void SpawnCreep()
        {
            var newCreep = new Creep(_ultimateTarget);
            newCreep.SetPosition(this.Transform.Position);
            Scene.Add(newCreep);
        }
    }
}
