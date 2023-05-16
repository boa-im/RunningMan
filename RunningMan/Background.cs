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
    /// Background class to draw background and scrolling
    /// </summary>
    public class Background : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos1, pos2;
        public Vector2 speed;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public Background(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            pos1 = position;
            pos2 = new Vector2(pos1.X + tex.Width, pos1.Y);
            this.speed = speed;
        }

        /// <summary>
        /// scrolling background
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            pos1 -= speed;
            pos2 -= speed;
            if (pos1.X < tex.Width)
                pos1.X = pos2.X + tex.Width;
            if (pos2.X < -tex.Width)
                pos2.X = -pos1.X;

            base.Update(gameTime);
        }

        /// <summary>
        /// draw background
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, pos1, Color.White);
            spriteBatch.Draw(tex, pos2, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
