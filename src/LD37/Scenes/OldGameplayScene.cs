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
    public class OldGameplayScene : ReflectiveSceneBuilder
    {
        private const int DistY = 1000;

        public override Color BackgroundColor => Color.Black;

        public Layer Hud { get; } = new Layer("hud", int.MaxValue)
        {
            IsCameraSticky = true
        };

        public GameObject Camera { get; private set; }

        public GameObject Player { get; } = new Player();

        public GameObject Champion { get; } = new Champion()
            .SetPosition(0, 1600);

        public GameObject Lane1 { get; private set; }
        public GameObject Lane1_Nexus1 { get; private set; }
        public GameObject Lane1_Nexus2 { get; private set; }
        public GameObject Lane1_Nexus3 { get; private set; }
        public GameObject Lane1_Nexus4 { get; private set; }
        public GameObject Lane1_Tower1 { get; } = new Tower();
        public GameObject Lane1_Tower2 { get; } = new Tower();

        public GameObject Lane2 { get; private set; }
        public GameObject Lane2_Nexus1 { get; private set; }
        public GameObject Lane2_Nexus2 { get; private set; }
        public GameObject Lane2_Nexus3 { get; private set; }
        public GameObject Lane2_Nexus4 { get; private set; }
        public GameObject Lane2_Tower1 { get; } = new Tower();
        public GameObject Lane2_Tower2 { get; } = new Tower();

        public GameObject Lane3 { get; private set; }
        public GameObject Lane3_Nexus1 { get; private set; }
        public GameObject Lane3_Nexus2 { get; private set; }
        public GameObject Lane3_Nexus3 { get; private set; }
        public GameObject Lane3_Nexus4 { get; private set; }
        public GameObject Lane3_Tower1 { get; } = new Tower();
        public GameObject Lane3_Tower2 { get; } = new Tower();

        public GameObject ChampionNexus { get; } = new ChampionNexus()
            .SetPosition(0, 1300);

        protected override void Compose()
        {
            Camera = new MainCamera()
                .Add(new FollowBehavior(Champion));

            (Player as Player).Champion = Champion as Champion;
            (Player as Player).Camera = Camera;

            var lane1 = new Lane(
                this.Champion as Champion,
                this.Lane1_Tower1 as Tower,
                this.Lane1_Tower2 as Tower,
                this.ChampionNexus as ChampionNexus);
            lane1.SetPosition(-1000, 0);
            this.Lane1 = lane1;
            Lane1_Nexus1 = Nexus.CreateNexus(1, lane1);
            lane1.PushNexus(Lane1_Nexus1 as Nexus);
            Lane1_Nexus1.SetParent(lane1);
            Lane1_Nexus2 = Nexus.CreateNexus(2, lane1).SetPosition(0, -DistY);
            lane1.PushNexus(Lane1_Nexus2 as Nexus);
            Lane1_Nexus2.SetParent(lane1);
            Lane1_Nexus3 = Nexus.CreateNexus(3, lane1).SetPosition(0, 2 * -DistY);
            lane1.PushNexus(Lane1_Nexus3 as Nexus);
            Lane1_Nexus3.SetParent(lane1);
            Lane1_Nexus4 = Nexus.CreateNexus(4, lane1).SetPosition(0, 3 * -DistY);
            lane1.PushNexus(Lane1_Nexus4 as Nexus);
            Lane1_Nexus4.SetParent(lane1);

            Lane1_Tower1.SetParent(lane1).SetPosition(0, 1000);
            Lane1_Tower2.SetParent(lane1).SetPosition(400, 650);

            var lane2 = new Lane(
                this.Champion as Champion,
                this.Lane2_Tower1 as Tower,
                this.Lane2_Tower2 as Tower,
                this.ChampionNexus as ChampionNexus
                );
            lane2.SetPosition(0, 0);
            this.Lane2 = lane2;
            Lane2_Nexus1 = Nexus.CreateNexus(1, lane2);
            lane2.PushNexus(Lane2_Nexus1 as Nexus);
            Lane2_Nexus1.SetParent(lane2);            
            Lane2_Nexus2 = Nexus.CreateNexus(2, lane2).SetPosition(0, -DistY);
            lane2.PushNexus(Lane2_Nexus2 as Nexus);
            Lane2_Nexus2.SetParent(lane2);
            Lane2_Nexus3 = Nexus.CreateNexus(3, lane2).SetPosition(0, 2 * -DistY);
            lane2.PushNexus(Lane2_Nexus3 as Nexus);
            Lane2_Nexus3.SetParent(lane2);
            Lane2_Nexus4 = Nexus.CreateNexus(4, lane2).SetPosition(0, 3 * -DistY);
            lane2.PushNexus(Lane2_Nexus4 as Nexus);
            Lane2_Nexus4.SetParent(lane2);

            Lane2_Tower1.SetParent(lane2).SetPosition(-200, 500);
            Lane2_Tower2.SetParent(lane2).SetPosition(200, 500);


            var lane3 = new Lane(
                this.Champion as Champion,
                this.Lane3_Tower1 as Tower,
                this.Lane3_Tower2 as Tower,
                this.ChampionNexus as ChampionNexus
                );
            lane3.SetPosition(1000, 0);
            this.Lane3 = lane3;
            Lane3_Nexus1 = Nexus.CreateNexus(1, lane3);
            lane3.PushNexus(Lane3_Nexus1 as Nexus);
            Lane3_Nexus1.SetParent(lane3);
            Lane3_Nexus2 = Nexus.CreateNexus(2, lane3).SetPosition(0, -DistY);
            lane3.PushNexus(Lane3_Nexus2 as Nexus);
            Lane3_Nexus2.SetParent(lane3);
            Lane3_Nexus3 = Nexus.CreateNexus(3, lane3).SetPosition(0, 2 * -DistY);
            lane3.PushNexus(Lane3_Nexus3 as Nexus);
            Lane3_Nexus3.SetParent(lane3);
            Lane3_Nexus4 = Nexus.CreateNexus(4, lane3).SetPosition(0, 3 * -DistY);
            lane3.PushNexus(Lane3_Nexus4 as Nexus);
            Lane3_Nexus4.SetParent(lane3);

            Lane3_Tower1.SetParent(lane3).SetPosition(0, 1000);
            Lane3_Tower2.SetParent(lane3).SetPosition(-400, 650);

        }
    }
}
