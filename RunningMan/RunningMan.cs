using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunningMan
{
    /// <summary>
    /// Running Man class for drawing running man and check jump
    /// </summary>
    public class RunningMan : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 pos;
        public Vector2 Velocity = Vector2.Zero;

        // variables for animation
        private List<Rectangle> frames;
        private int frameIndex = 0;
        private int delay;
        private int delayCounter;

        private const int COLS = 8;

        // check running man has jumped or not
        private bool hasJumped;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="pos"></param>
        public RunningMan(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 pos) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.pos = pos;
            this.delay = 2;
            hasJumped = true;

            createFrames();
        }

        /// <summary>
        /// method for cutting images and saving to list
        /// </summary>
        private void createFrames()
        {
            frames = new List<Rectangle>();
            for (int j = 0; j < COLS; j++)
            {
                int x = j * 78;
                Rectangle r = new Rectangle(x, 0, 78, 100);
                frames.Add(r);
            }
        }

        /// <summary>
        /// for making animaiton and jumping
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > 7)
                {
                    frameIndex = 0;
                }
                delayCounter = 0;
            }

            pos += Velocity;
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && hasJumped == false)
            {
                pos.Y -= 10f;
                Velocity.Y = -5f;
                hasJumped = true;
            }

            if (hasJumped == true)
            {
                Velocity.Y += 0.15f;
            }

            if (pos.Y >= 173)
            {
                hasJumped = false;
                Velocity.Y = 0f;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// drawing running man animation
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (frameIndex >= 0)
            {
                spriteBatch.Draw(tex, pos, frames[frameIndex], Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, 78, 100);
        }
    }
}
