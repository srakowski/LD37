using Coldsteel.Fluent;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class GameFlowBehavior : Behavior
    {
        private Song _gameSong;

        public GameDirector Director => GameObject as GameDirector;

        private List<CreepSpawn> _currentCreepSpawns = new List<CreepSpawn>();

        private List<ArrowSpawn> _arrowSpans = new List<ArrowSpawn>();

        private List<Vector2> _arrowSpawnLocs = new List<Vector2>();

        private List<Vector2> _potLocations = new List<Vector2>();

        private List<Pot> _pots = new List<Pot>();

        public override void Activate()
        {
            _gameSong = Content.Load<Song>("audio/gamesong");
            MediaPlayer.Play(_gameSong);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            StartCoroutine(StartGame());
            for (var x = -600; x < 650; x += 100)
                _arrowSpawnLocs.Add(new Vector2(x, -96));

            _potLocations.Add(new Vector2(0, 100));
            _potLocations.Add(new Vector2(-600, 600));
            _potLocations.Add(new Vector2(600, 600));
            _potLocations.Add(new Vector2(0, 1100));
        }

        private IEnumerator StartGame()
        {
            while (true)
            {
                yield return WaitYieldInstruction.Create(5000);
                foreach (var loc in Director.CreepSpawnerLocations)
                {
                    var cs = new CreepSpawn(Director.Champion, Progression.WaveLevel)
                        .SetPosition(loc) as CreepSpawn;
                    _currentCreepSpawns.Add(cs);
                    Scene.Add(cs);
                }

                var locs = _arrowSpawnLocs.OrderBy(s => Guid.NewGuid());
                var e = locs.GetEnumerator();
                for (int i = 0; i < MathHelper.Clamp(Progression.WaveLevel, 0, 3); i++)
                {
                    e.MoveNext();
                    var aspawn = new ArrowSpawn().SetPosition(e.Current);
                    Scene.Add(aspawn);
                    _arrowSpans.Add(aspawn as ArrowSpawn);
                }

                var locs2 = _potLocations.OrderBy(s => Guid.NewGuid());
                var e2 = locs2.GetEnumerator();
                var potsToSpawn = MathHelper.Clamp(Progression.WaveLevel, 0, 3);
                for (var i = 0; i < potsToSpawn; i++)
                {
                    e2.MoveNext();
                    var pert = new Pot().SetPosition(e2.Current) as Pot;
                    _pots.Add(pert);
                    Scene.Add(pert);
                }

                yield return WaitYieldInstruction.Create(1000);

                foreach (var ar in _arrowSpans)
                    ar.IsEnabled = true;

                yield return WaitYieldInstruction.Create(1000);

                foreach (var ar in _currentCreepSpawns)
                    ar.IsEnabled = true;                

                while (!_currentCreepSpawns.TrueForAll(t => t.IsDestroyed))
                {
                    if (Director.Champion.IsDestroyed)
                    {
                        StartCoroutine(GameOver());
                        break;
                    }
                    yield return WaitYieldInstruction.Create(1000);
                }

                ClearScene();

                if (Director.Champion.IsDestroyed)
                {
                    StartCoroutine(GameOver());
                    break;
                }

                Progression.WaveLevel++;
            }
        }

        private void ClearScene()
        {
            _arrowSpans.ForEach(a => Destroy(a));
            _arrowSpans.Clear();
            _currentCreepSpawns.Clear();
        }

        private IEnumerator GameOver()
        {
            yield return WaitYieldInstruction.Create(1000);
            SceneManager.Start("GameplayScene");
        }
    }
}
