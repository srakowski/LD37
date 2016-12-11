using Coldsteel;
using Coldsteel.Composition;
using Coldsteel.Fluent;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using LD37.Behaviors;
using Microsoft.Xna.Framework;
using System.Collections;
using System;
using System.Collections.Generic;
using LD37.GameObjects;
using System.Linq;

namespace LD37.Scenes
{
    public class GameplayScene : ReflectiveSceneBuilder
    {
        public override Color BackgroundColor => Color.Black;

        public Layer Hud { get; } = new Layer("hud", int.MaxValue)
        {
            IsCameraSticky = true
        };

        public GameObject Camera { get; } = new GameObjects.MainCamera();

        public GameObject Player { get; } = new Player();

        public GameObject Champion { get; } = new Champion()
            .SetPosition(1000, 640);

        public GameObject Lane1 { get; private set; }

        public GameObject Lane1_Nexus1 { get; private set; }

        public GameObject Lane1_Tower1 { get; } = new Tower()
            .SetPosition(800, 600);

        public GameObject Lane1_Tower2 { get; } = new Tower();

        public GameObject ChampionNexus { get; } = new ChampionNexus();

        protected override void Compose()
        {
            (Player as Player).Champion = Champion as Champion;
            (Player as Player).Camera = Camera;

            var lane1 = new Lane(
                this.Champion as Champion,
                this.Lane1_Tower1 as Tower,
                this.Lane1_Tower2 as Tower,
                this.ChampionNexus as ChampionNexus);
            lane1.SetPosition(100, 100);
            this.Lane1 = lane1;

            Lane1_Nexus1 = Nexus.CreateNexus(1, lane1);
            lane1.PushNexus(Lane1_Nexus1 as Nexus);
            Lane1_Nexus1.SetParent(lane1);
        }


        //private const int NumLanes = 3;
        //private const int NumNexus = 6;
        //private const int LaneWidth = 600;
        //private const int NexusSementHeight = 600;
        //private const int WallThickness = 48;

        //public override Color BackgroundColor => Color.Black;

        //public GameObject TopWall { get; } = new Wall(0, 0, NumLanes * LaneWidth, WallThickness);

        //public GameObject RightWall { get; } = new Wall(NumLanes * LaneWidth, 0, WallThickness, NexusSementHeight * NumNexus + WallThickness);

        //public GameObject BottomWall { get; } = new Wall(0, NexusSementHeight * NumNexus, NumLanes * LaneWidth, WallThickness);

        //public GameObject LeftWall { get; } = new Wall(0, 0, WallThickness, NexusSementHeight * NumNexus);

        //public GameObject LaneDiv1 { get; } = new Wall(LaneWidth, NexusSementHeight, WallThickness, (NumNexus - 2) * NexusSementHeight);

        //public GameObject LaneDiv2 { get; } = new Wall(LaneWidth * 2, NexusSementHeight, WallThickness, (NumNexus - 2) * NexusSementHeight);

        //public GameObject Player { get; set; } = new Player();



        //public Layer Ground { get; } = new Layer("ground", -10);

        //public GameObject World { get; private set; }



        //public IEnumerable<GameObject> WorldGameObjects { get; private set; }

        //protected override void Compose()
        //{
        //    var worldGameObjects = new List<GameObject>();
        //    World = GameObjects.World.Create(3, worldGameObjects);
        //    WorldGameObjects = worldGameObjects;
        //}


        //public override Color BackgroundColor => Color.Black;

        //public GameObject Champion { get; } = new GameObject()
        //    .SetPosition(100, 100)
        //    .Add(new SpriteRenderer("sprites/champion"))
        //    .Add(new RigidBody())
        //    .Add(new BoxCollider(-24, -24, 48, 48));

        //public GameObject Player { get; } = new GameObject()
        //    .Add(new SpriteRenderer("sprites/pointer"));

        //public GameObject EnemySpawnNexus { get; } = new GameObject()
        //    .SetPosition(300, 300)
        //    .Add(new SpriteRenderer("sprites/enexus"));

        //protected override void Compose()
        //{
        //    var champ = new Champion()
        //    {
        //        Stats = new Stats()
        //        {
        //            MovementSpeed = new Stat()
        //            {
        //                BaselineValue = 0.3f
        //            }
        //        }
        //    };


        //    var championBehavior = new ChampionBehavior(champ);
        //    Champion.Add(championBehavior);
        //    Player.Add(new PlayerBehavior()
        //    {
        //        Champion = championBehavior
        //    });

        //    EnemySpawnNexus.Add(new SpawnCreepBehavior(new World()));
        //}
    }
}
