using System;
using System.Collections.Generic;
using air_shooter.classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace air_shooter
{
    public class Game1 : Game
    {
        private const int MAX_MINES = 10;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Player _player;
        public Bg1 _bg1;
        public Bg2 _bg2;
        public Bg _bg;
        private List<Mine> _mines;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _player = new Player();
            _bg1 = new Bg1();
            _bg2 = new Bg2();
            _bg = new Bg();
            _mines = new List<Mine>();
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player.LoadContent(Content);
            _bg1.LoadContent(Content);
            _bg2.LoadContent(Content);
            _bg.LoadContent(Content);
            for (int i = 0; i < MAX_MINES; i++)
            {
                LoadMines();
            }
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            _player.Update(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, Content);
            _bg1.Update();
            _bg2.Update();
            _bg.Update();
            foreach(Mine mine in _mines)
            {
                mine.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);




            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            {
                _bg.Draw(_spriteBatch);
                _bg1.Draw(_spriteBatch);
                _bg2.Draw(_spriteBatch);
                _player.Draw(_spriteBatch);
                for (int i = 0; i < MAX_MINES; i++)
                {
                    Mine mine = _mines[i];
                    _mines.Add(mine);
                    mine.Draw(_spriteBatch);
                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public void LoadMines()
        {
            Mine mine = new Mine();
            mine.LoadContent(Content);

            Random rand = new Random();

            int x = rand.Next(0, _graphics.PreferredBackBufferWidth);
            int y = rand.Next(0, _graphics.PreferredBackBufferHeight - mine.Height);

            mine.Position = new Vector2(x, y);

            _mines.Add(mine);
        }
        public void Collision()
        {
            foreach (Mine mine in _mines)
            {
                if (mine.hitbox.Intersects(_player.hitbox))
                {
                    mine.IsAlive = false;
                    _mines.Remove(mine);
                }
            }
        }
        private void UpdateMines()
        {
            for (int i = 0; i < _mines.Count; i++)
            {
                Mine mine = _mines[i];

                mine.Update();

                // teleport
                if (mine.Position.Y > _graphics.PreferredBackBufferHeight)
                {
                    Random random = new Random();

                    int x = random.Next(0, _graphics.PreferredBackBufferWidth - mine.Width);
                    int y = random.Next(0, _graphics.PreferredBackBufferHeight);

                    mine.Position = new Vector2(x, -y);
                }

                // check isAlive asteroid
                if (!mine.IsAlive)
                {
                    _mines.Remove(mine);
                    i--;
                }
            }

            // Загружаем доп. астероиды в игру
            if (_mines.Count < MAX_MINES)
            {
                LoadMines();
            }
        }
    }
}
