using Coldsteel.Fluent;
using Coldsteel.Scripting;
using LD37.GameObjects;
using LD37.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class NexusBehavior : Behavior
    {
        private Coroutine _spawnTask = null;

        private ICreepFactory _creepFactory;

        public bool IsActive { get; set; } = false;

        public int TimeBetweenCreepSpawns { get; set; } = 1000;

        public int TimeBetweenWaves { get; set; } = 30000;

        public int NumCreepsToSpawn { get; private set; } = 30;

        public CreepLevel CreepLevelToBeSpawned { get; }

        public bool IsDestroyed => GameObject?.IsDestroyed ?? true;

        public Nexus Nexus => GameObject as Nexus;

        public NexusBehavior(ICreepFactory creepFactory, CreepLevel creepLevelToSpawn)
        {
            this.CreepLevelToBeSpawned = creepLevelToSpawn;
            this._creepFactory = creepFactory;
        }

        public override void Update()
        {
            CheckDestroyed();
            if (IsActive && _spawnTask == null)
                _spawnTask = StartCoroutine(SpawnCreeps());
        }

        private void CheckDestroyed()
        {
            if (!Nexus.Stats.IsDead)
                return;

            _spawnTask.Stop();
            SceneManager.ActiveScene.Add(new NexusRubble()
                .SetPosition(GameObject.Transform.Position));
            Destroy(GameObject);
        }
        
        private IEnumerator SpawnCreeps()
        {
            while (true)
            {
                // Spawn wave.
                for (var i = 0; i < NumCreepsToSpawn; i++)
                {
                    SpawnCreep();
                    yield return WaitYieldInstruction.Create(TimeBetweenCreepSpawns);
                }

                // Wait to spawn next wave.
                yield return WaitYieldInstruction.Create(TimeBetweenWaves);
            }
        }

        private void SpawnCreep()
        {
            var newCreep = _creepFactory.Create(CreepLevelToBeSpawned);
            newCreep.SetPosition(this.Transform.Position);
            SceneManager.ActiveScene.Add(newCreep);
        }
            
    }
}
