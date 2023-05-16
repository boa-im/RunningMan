using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMan
{
    /// <summary>
    /// individualSocreBoard Class to draw score board when user hit obstacle
    /// </summary>
    public class individualScoreBoard : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="pos"></param>
        public individualScoreBoard(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 pos) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.pos = pos;
        }

        /// <summary>
        /// draw score board
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
