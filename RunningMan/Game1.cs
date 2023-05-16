/*
 * Project Name: RunningMan
 * Name: Boa Im
 * Revision history:
 *      Dec 8, 2022 Created
 *      Dec 9, 2022 Added codes
 *      Dec 10, 2022 Added codes
 *      Dec 11, 2022 Added codes, added comments, summary
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;

namespace RunningMan
{
    /// <summary>
    /// Everything for playing game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private SpriteFont ScoreFont;

        // Play variables
        private Background bg;
        private Obstacle ob;
        private Texture2D loadTex;
        private RunningMan rm;
        private ScoreString score;
        private HitManager hitManager;

        // Save variables
        private float currentTime = 0f;
        private int highScore = 0;
        public int level = 1;

        // Pause variables
        private Texture2D pauseTex;
        private Pause pause;

        // Main variables
        private Texture2D btnTex;
        private Vector2 btnPos;
        private string Back = " Back to Main";
        private MouseState ms;

        //Dead components
        private individualScoreBoard isb;
        private Message sbMsg;
        private BackToMain backToMain;
        private Replay re;
        private BottomMessage esc;

        // Save
        private static string _filename = @"Save.txt";

        // Check game state
        public enum GameState { Main, Play, Help, About, Dead, Pause, Save };
        public GameState gameState = GameState.Main;

        /// <summary>
        /// Constructor
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 360;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //for back ground music
            Song backgroundMusic = this.Content.Load<Song>("sounds/bgm");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);

            // loading fonts
            font = this.Content.Load<SpriteFont>("fonts/font");
            ScoreFont = this.Content.Load<SpriteFont>("fonts/scoreFont");

            // Main page
            if (gameState == GameState.Main)
            {
                // for buttons in main page
                btnTex = this.Content.Load<Texture2D>("images/greenbutton");
                btnPos = new Vector2(50, 143);
                Buttons btns = new Buttons(this, _spriteBatch, font, btnTex, btnPos, "Play", "Help", "About");
                this.Components.Add(btns);

                // for loading saved game from text file;
                loadTex = this.Content.Load<Texture2D>("images/Load");
                Load load = new Load(this, _spriteBatch, loadTex);
                this.Components.Add(load);

                // for letting users know if they press esc button, game will close
                BottomMessage esc = new BottomMessage(this, _spriteBatch, font, "Press ESC button to quit this game!", Color.Black);
                this.Components.Add(esc);
            }

            // Play page
            else if(gameState == GameState.Play)
            {
                currentTime = 0;
                level = 1;

                // for background scrolling
                Texture2D bgTex = this.Content.Load<Texture2D>("images/background");
                Vector2 bgPosition = new Vector2(-bgTex.Width, 0);
                Vector2 Speed = new Vector2(4, 0);
                bg = new Background(this, _spriteBatch, bgTex, bgPosition, Speed);
                this.Components.Add(bg);

                // for running man moving
                Texture2D rmTex = this.Content.Load<Texture2D>("images/runningman");
                Vector2 rmPosition = new Vector2(250, 173);
                rm = new RunningMan(this, _spriteBatch, rmTex, rmPosition);
                this.Components.Add(rm);

                // for triangles moving
                Texture2D obTex = this.Content.Load<Texture2D>("images/obstacle");
                Vector2 obPosition = new Vector2(_graphics.PreferredBackBufferWidth, 240);
                ob = new Obstacle(this, _spriteBatch, obTex, obPosition, Speed);
                this.Components.Add(ob);

                // for score string
                score = new ScoreString(this, _spriteBatch, font, Vector2.Zero, "Score", Color.Black);
                this.Components.Add(score);

                // for checking score and stopping everything
                SoundEffect dieSound = this.Content.Load<SoundEffect>("sounds/Die");
                this.hitManager = new HitManager(this, rm, ob, bg, score, dieSound);
                this.Components.Add(hitManager);

                // pause button
                pauseTex = this.Content.Load<Texture2D>("images/pause");
                pause = new Pause(this, _spriteBatch, pauseTex);
                this.Components.Add(pause);
            }
            
            // help page
            else if (gameState == GameState.Help)
            {
                // message
                string help = "This is a running man game! :)\nThis game is created for the final project\nJump: left click\nClick left mouse button to jump, avoid obstacles and get high score!";
                Message helpMessage = new Message(this, _spriteBatch, font, help, Color.Black);
                this.Components.Add(helpMessage);

                // back to main menu button
                BackToMain backToMain = new BackToMain(this, _spriteBatch, font, Vector2.Zero, Back, Color.Gray);
                this.Components.Add(backToMain);
            }

            // about page
            else if (gameState == GameState.About)
            {
                // about me string
                string aboutMe = "Name: Boa Im\nStudent number: 8751777\nContact: bim1777@conestogac.on.ca";
                Message aboutMessage = new Message(this, _spriteBatch, font, aboutMe, Color.Black);
                this.Components.Add(aboutMessage);

                // back to main menu button
                BackToMain backToMain = new BackToMain(this, _spriteBatch, font, Vector2.Zero, Back, Color.Gray);
                this.Components.Add(backToMain);
            }

            // dead page
            else if (gameState == GameState.Dead)
            {
                // score board image
                Texture2D sbTex = this.Content.Load<Texture2D>("images/individualScoreBoard");
                Vector2 sbPos = new Vector2((900 - sbTex.Width) / 2, (360 - sbTex.Height) / 2);
                isb = new individualScoreBoard(this, _spriteBatch, sbTex, sbPos);
                this.Components.Add(isb);

                // score board message
                sbMsg = new Message(this, _spriteBatch, ScoreFont, currentTime.ToString("0"), Color.White);
                this.Components.Add(sbMsg);

                // back to main menu button
                backToMain = new BackToMain(this, _spriteBatch, font, Vector2.Zero, Back, Color.Gray);
                this.Components.Add(backToMain);

                // for letting users know if they press esc button, game will close
                esc = new BottomMessage(this, _spriteBatch, font, "Press ESC button to quit this game!", Color.White);
                this.Components.Add(esc);

                // replay button
                Texture2D reTex = this.Content.Load<Texture2D>("images/replay");
                re = new Replay(this, _spriteBatch, reTex);
                this.Components.Add(re);

                this.Components.Remove(score);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ms = Mouse.GetState();


            // update main page
            if (gameState == GameState.Main)
            {
                if(ms.LeftButton == ButtonState.Pressed)
                {
                    Vector2 position = new Vector2(ms.X, ms.Y);

                    // Play button
                    if(position.X >= 50 && position.X <= 50 + btnTex.Width && position.Y >= 143 && position.Y <= 143 + btnTex.Height)
                    {
                        this.Components.Clear();
                        gameState = GameState.Play;
                        LoadContent();
                    }
                    // help button
                    else if (position.X >= 150 + btnTex.Width && position.X <= 150 + btnTex.Width * 2 && position.Y >= 143 && position.Y <= 143 + btnTex.Height)
                    {
                        this.Components.Clear();
                        gameState = GameState.Help;
                        LoadContent();
                    }
                    //about button
                    else if (position.X >= 250 + btnTex.Width * 2 && position.X <= 250 + btnTex.Width * 3 && position.Y >= 143 && position.Y <= 143 + btnTex.Height)
                    {
                        this.Components.Clear();
                        gameState = GameState.About;
                        LoadContent();
                    }
                    //load button
                    else if (position.X >= 900-loadTex.Width && position.X <= 900 && position.Y >= 0 && position.Y <= loadTex.Height)
                    {
                        if (!File.Exists(_filename))
                            File.Create(_filename).Dispose();

                        //read information from txt file
                        using (StreamReader reader = new StreamReader(_filename))
                        {
                            while(!reader.EndOfStream)
                            {
                                string lines = reader.ReadLine();
                                if(lines != "")
                                {
                                    this.Components.Clear();
                                    gameState = GameState.Play;
                                    LoadContent();

                                    string[] line = lines.Split('|');

                                    rm.pos.X = (float)Convert.ToDouble(line[0]);
                                    rm.pos.Y = (float)Convert.ToDouble(line[1]);
                                    rm.Velocity.X = (float)Convert.ToDouble(line[2]);
                                    rm.Velocity.Y = (float)Convert.ToDouble(line[3]);
                                    ob.pos.X = (float)Convert.ToDouble(line[4]);
                                    ob.pos.Y = (float)Convert.ToDouble(line[5]);
                                    ob.speed.X = (float)Convert.ToDouble(line[6]);
                                    ob.speed.Y = (float)Convert.ToDouble(line[7]);
                                    currentTime = (float)Convert.ToDouble(line[8]);
                                    highScore = Convert.ToInt32(line[9]);
                                }
                                else
                                {
                                    gameState = GameState.Main;
                                }
                            }
                        }
                        // delete everything in txt file
                        using (StreamWriter writer = new StreamWriter(_filename))
                        {
                            writer.WriteLine("");
                        }
                    }
                }
            }
            // update play page
            else if(gameState == GameState.Play)
            {
                rm.Enabled = true;
                Vector2 d = font.MeasureString(score.message);
                Vector2 ssPos = new Vector2(_graphics.PreferredBackBufferWidth - d.X, 0);
                score.pos = ssPos;

                // check if user hits obstacles
                if (bg.speed != Vector2.Zero)
                {
                    currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds * 10f;
                    
                    if(currentTime >= 100 * level)
                    {
                        level++;
                        bg.speed = new Vector2(3 + level, 0);
                        ob.speed = new Vector2(3 + level, 0);
                    }
                    score.message = "Level " + level + " Score: " + currentTime.ToString("0") + "\nHigh score: " + highScore;
                }
                else if (bg.speed == Vector2.Zero)
                {
                    gameState = GameState.Dead;
                    LoadContent();
                }

                // if user clicks pause button
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Vector2 position = new Vector2(ms.X, ms.Y);

                    if (position.X >= 0 && position.X <= pauseTex.Width && position.Y >= 0 && position.Y <= pauseTex.Height)
                    {
                        this.Components.Clear();
                        gameState = GameState.Pause;
                    }
                }
            }
            // update help, about, and dead page
            else if (gameState == GameState.Help || gameState == GameState.About || gameState == GameState.Dead)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Vector2 position = new Vector2(ms.X, ms.Y);

                    if (position.X >= 0 && position.X <= font.MeasureString(Back).X && position.Y >= 0 && position.Y <= font.MeasureString(Back).Y)
                    {
                        this.Components.Clear();
                        gameState = GameState.Main;
                    }
                    LoadContent();
                }
            }
            // update help page
            if (gameState == GameState.Dead)
            {
                this.Components.Remove(pause);

                if (currentTime > highScore)
                    highScore = (int)currentTime;

                rm.Enabled = false;
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Vector2 position = new Vector2(ms.X, ms.Y);

                    // if user clicks replay button
                    if (position.X >= 400 && position.X <= 500 && position.Y >= 280 && position.Y <= 330)
                    {
                        this.Components.Remove(isb);
                        this.Components.Remove(sbMsg);
                        this.Components.Remove(backToMain);
                        this.Components.Remove(re);
                        this.Components.Remove(esc);
                        gameState = GameState.Play;
                        LoadContent();
                    }
                }
            }
            // update pause page
            if (gameState == GameState.Pause)
            {
                Buttons btns = new Buttons(this, _spriteBatch, font, btnTex, btnPos, "Resume", "Save", "About");
                this.Components.Add(btns);

                // variables for resume game
                Vector2 rmPos = rm.pos;
                Vector2 rmVelocity = rm.Velocity;
                Vector2 obPos = ob.pos;
                Vector2 Speed = ob.speed;
                float score = currentTime;

                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Vector2 position = new Vector2(ms.X, ms.Y);

                    // resume button
                    if (position.X >= 50 && position.X <= 50 + btnTex.Width && position.Y >= 143 && position.Y <= 143 + btnTex.Height)
                    {
                        this.Components.Clear();
                        gameState = GameState.Play;
                        LoadContent();
                        rm.pos = rmPos;
                        rm.Velocity = rmVelocity;
                        ob.pos = obPos;
                        ob.speed = Speed;
                        bg.speed = Speed;
                        currentTime = score;

                    }
                    // save button to save to txt file
                    else if (position.X >= 150 + btnTex.Width && position.X <= 150 + btnTex.Width * 2 && position.Y >= 143 && position.Y <= 143 + btnTex.Height)
                    {
                        if (!File.Exists(_filename))
                            File.Create(_filename).Dispose();
                        using (StreamWriter writer = new StreamWriter(_filename))
                        {
                            writer.WriteLine(rmPos.X + "|" + rmPos.Y + "|" + rmVelocity.X + "|" + rmVelocity.Y + "|" + obPos.X + "|" + obPos.Y + "|" + Speed.X + "|" + Speed.Y + "|" + score + "|" + highScore);
                        }
                        BottomMessage save = new BottomMessage(this, _spriteBatch, font, "Saved Successfully!", Color.Black);
                        this.Components.Add(save);
                    }
                    // go to about page
                    else if (position.X >= 250 + btnTex.Width * 2 && position.X <= 250 + btnTex.Width * 3 && position.Y >= 143 && position.Y <= 143 + btnTex.Height)
                    {
                        this.Components.Clear();
                        gameState = GameState.About;
                        LoadContent();
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            base.Draw(gameTime);
        }
    }
}