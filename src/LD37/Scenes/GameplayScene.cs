using Coldsteel;
using Coldsteel.Composition;
using Coldsteel.Fluent;
using Coldsteel.Rendering;
using LD37.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Scenes
{
    public class GameplayScene : ReflectiveSceneBuilder
    {
        public override Color BackgroundColor => Color.Black;

        public Billboard Billboard { get; set; } = new Billboard();

        public GameDirector GameDirector { get; private set; }

        public Layer FloorLayer { get; } = new Layer("floor", -20);

        public Layer ItemLayer { get; } = new Layer("item", -10);

        public Layer PointerLayer { get; } = new Layer("pointer", int.MaxValue)
        {
            IsCameraSticky = true
        };

        public MainCamera Camera { get; } = new MainCamera();

        public Pointer Pointer { get; } = new Pointer();

        public Champion Champion { get; } = new Champion();

        public Hand Hand { get; } = new Hand();

        public Sword Sword { get; } = new Sword();

        //public ChampionNexus ChampionNexus { get; } = new ChampionNexus();

        public GameObject Floor { get; } = new GameObject();

        protected override void Compose()
        {
            Progression.Reset();

            GameDirector = new GameDirector(
                new[]
                {
                    new Vector2(-700, 38),
                    new Vector2(650, 38),
                    new Vector2(-700, 1075),
                    new Vector2(650, 1075),
                }, null, Champion);

            Floor.Add(new SpriteRenderer("sprites/floor")
            {
                Layer = "floor"
            }).SetPosition(0, 1500);

            Champion.SetPosition(0, 600);
            //ChampionNexus.SetPosition(0, 600);

            Camera.AddComponent(new CameraFollowBehavior(Champion));

            Champion.Hand = Hand;
            Hand.SetParent(Champion);

            Champion.Sword = Sword;
            Sword.SetParent(Hand);
        }
    }
}
