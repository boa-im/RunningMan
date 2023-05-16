using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RunningMan
{
    /// <summary>
    /// hit manager to check whether user hits an obstacles or not
    /// </summary>
    public class HitManager : GameComponent
    {
        private RunningMan man;
        private Obstacle triangle;
        private SoundEffect sound;
        private Background background;
        private ScoreString score;
        public bool playMusic = true;

        /// <summary>
        /// constructor for saving info to variables
        /// </summary>
        /// <param name="game"></param>
        /// <param name="rm"></param>
        /// <param name="triangle"></param>
        /// <param name="background"></param>
        /// <param name="score"></param>
        /// <param name="sound"></param>
        public HitManager(Game game, RunningMan rm, Obstacle triangle, Background background, ScoreString score, SoundEffect sound) : base(game)
        {
            man = rm;
            this.triangle = triangle;
            this.background = background;
            this.score = score;
            this.sound = sound;
        }

        /// <summary>
        /// if user hits obstacle background and obstacles moving stop
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Rectangle manRect = man.getBounds();
            Rectangle triangleRect = triangle.getBounds();

            if (triangleRect.Intersects(manRect))
            {
                triangle.speed = Vector2.Zero;
                background.speed = Vector2.Zero;
                if (playMusic == true)
                {
                    sound.Play();
                    playMusic = false;
                }
            }
            base.Update(gameTime);
        }
    }
}
