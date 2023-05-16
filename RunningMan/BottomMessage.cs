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
    /// BottomMessage class for letting users know press esc button and saving successfully
    /// </summary>
    public class BottomMessage : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Vector2 pos;
        private string msg;
        private Color color;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="font"></param>
        /// <param name="msg"></param>
        /// <param name="color"></param>
        public BottomMessage(Game game, SpriteBatch spriteBatch, SpriteFont font, string msg, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.msg = msg;
            this.pos = new Vector2((900 - font.MeasureString(msg).X) / 2, 360 - font.MeasureString(msg).Y);
            this.color = color;
        }

        /// <summary>
        /// draw string
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, msg, pos, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
