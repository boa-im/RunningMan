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
    /// ScoreString Class to draw score when user hits an obstacle
    /// </summary>
    public class ScoreString : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        public Vector2 pos;
        public string message;
        private Color color;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="font"></param>
        /// <param name="pos"></param>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public ScoreString(Game game, SpriteBatch spriteBatch, SpriteFont font, Vector2 pos, string message, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.pos = pos;
            this.message = message;
            this.color = color;
        }

        /// <summary>
        /// draw drawstring
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, pos, color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
