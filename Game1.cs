﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace snorlax
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly Random RNG = new Random();
        GamePadState pad1_curr;

        winggulls gull;
        background bgd;
        snorfig sface, smouth, sbody;

        float spawnRate, timeTillSpawn;
        int winggullsPerSpawn;


        winggulls[] gulls;
        const int winggulls = 50;
        const float BASESPAWNRATE = 5;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            gulls = new winggulls[winggulls];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            bgd = new background(Content.Load<Texture2D>("back"));
            //sface = new snorfig(Content.Load<Texture2D>("face"), 400, 500);
            sbody = new snorfig(Content.Load<Texture2D>("143"), 400, 500, Content.Load<Texture2D>("mouth"));
            
            for (int i = 0; i < gulls.Length; i++)
            {
                gulls[i] = new winggulls(Content.Load<Texture2D>("gull"), RNG.Next(0,1024), RNG.Next(100, 400), RNG.Next(-2, 2));

            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < gulls.Length; i++)
            {
                gulls[i].UpdateMe(1000, 300);
            }

            if (timeTillSpawn < 0)
            {
               

                //if the current spawn rate is half the base, it's time to reset and add an extra bauble
                if (spawnRate < BASESPAWNRATE / 2)
                {
                    spawnRate = BASESPAWNRATE;
                    winggullsPerSpawn++;
                }
                else
                {
                    //decrease the spawnRate so the next one will come slightly faster
                    spawnRate -= 0.2f;
                }

                timeTillSpawn = spawnRate;
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            bgd.DrawMe(_spriteBatch);
            //sface.DrawMe(_spriteBatch);
            sbody.DrawMe(_spriteBatch);
            //smouth.DrawMe(_spriteBatch);
            for (int i = 0; i < gulls.Length; i++)
            {

                gulls[i].DrawMe(_spriteBatch);
            }
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}