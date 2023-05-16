using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunningMan
{
    /// <summary>
    /// Obstacle class to draw obstacles
    /// </summary>
    public class Obstacle : DrawableGameComponent
    {
        private Game1 game;
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 OriginalPos;
        public Vector2 pos;
        public Vector2 speed;

        Random random = new Random();
        int Obstacles = 0;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="Position"></param>
        /// <param name="Speed"></param>
        public Obstacle(Game1 game, SpriteBatch spriteBatch, Texture2D tex, Vector2 Position, Vector2 Speed) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.OriginalPos = Position;
            this.pos = Position;
            this.speed = Speed;
            this.Obstacles = random.Next(1, 4);
        }

        /// <summary>
        /// moving obstacles
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            pos -= speed;

            if (pos.X + tex.Width*Obstacles <= 0)
            {
                pos = OriginalPos;
                Obstacles = random.Next(1, 3 + game.level);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// draw obstacles
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            for(int i = 0; i< Obstacles; i++)
            {
                spriteBatch.Draw(tex, new Vector2(pos.X + tex.Width * i, pos.Y), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// for getting bounds to check running man hit an obstacle
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, tex.Width * Obstacles, tex.Height);
        }
    }
}
