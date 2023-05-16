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
    /// Buttons class for drawing 3 buttons with string in main page and pause page
    /// </summary>
    public class Buttons : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Texture2D tex;
        private Vector2 pos1, pos2, pos3;
        private string msg1;
        private string msg2;
        private string msg3;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="font"></param>
        /// <param name="tex"></param>
        /// <param name="pos"></param>
        /// <param name="msg1"></param>
        /// <param name="msg2"></param>
        /// <param name="msg3"></param>
        public Buttons(Game game, SpriteBatch spriteBatch, SpriteFont font, Texture2D tex, Vector2 pos, string msg1, string msg2, string msg3) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.tex = tex;
            this.pos1 = pos;
            this.pos2 = new Vector2(pos1.X + tex.Width + 100, pos1.Y);
            this.pos3 = new Vector2(pos1.X + tex.Width * 2 + 200, pos1.Y);
            this.msg1 = msg1;
            this.msg2 = msg2;
            this.msg3 = msg3;
        }

        /// <summary>
        /// draw buttons and draw strings
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos1, Color.White);
            spriteBatch.DrawString(font, msg1, new Vector2(pos1.X + (tex.Width - font.MeasureString(msg1).X) / 2, pos1.Y + (tex.Height - font.MeasureString(msg1).Y) / 2), Color.Black);
            spriteBatch.Draw(tex, pos2, Color.White);
            spriteBatch.DrawString(font, msg2, new Vector2(pos2.X + (tex.Width - font.MeasureString(msg2).X) / 2, pos1.Y + (tex.Height - font.MeasureString(msg1).Y) / 2), Color.Black);
            spriteBatch.Draw(tex, pos3, Color.White);
            spriteBatch.DrawString(font, msg3, new Vector2(pos3.X + (tex.Width - font.MeasureString(msg3).X) / 2, pos1.Y + (tex.Height - font.MeasureString(msg1).Y) / 2), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
