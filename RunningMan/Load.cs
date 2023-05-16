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
    /// Load class for drawing load button
    /// </summary>
    public class Load :DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        public Load(Game game,SpriteBatch spriteBatch, Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
        }

        // draw load button
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Vector2(900-tex.Width, 0), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
