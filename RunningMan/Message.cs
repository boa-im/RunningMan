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
    /// Message class to show string to help page and about page
    /// </summary>
    public class Message : DrawableGameComponent
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
        /// <param name="message"></param>
        /// <param name="color"></param>
        public Message(Game game, SpriteBatch spriteBatch, SpriteFont font, string message, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.pos = new Vector2((900 - font.MeasureString(message).X) / 2, (360 - font.MeasureString(message).Y) / 2);
            this.message = message;
            this.color = color;
        }

        /// <summary>
        /// draw string with message
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
