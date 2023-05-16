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
    /// Back to main class to draw back to main string
    /// </summary>
    public class BackToMain : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Vector2 pos;
        private string message;
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
        public BackToMain(Game game, SpriteBatch spriteBatch, SpriteFont font, Vector2 pos, string message, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.pos = pos;
            this.message = message;
            this.color = color;
        }

        /// <summary>
        /// draw string
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
