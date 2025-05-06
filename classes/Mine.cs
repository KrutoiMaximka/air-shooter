using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace air_shooter.classes
{
    public class Mine
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed = 0.1f;

        public Rectangle hitbox;

        public int Width
        {
            get { return _texture.Width; }
        }

        public int Height
        {
            get { return _texture.Height; }
        }

        public Vector2 Position
        {
            set { _position = value; }
            get { return _position; }
        }

        public Rectangle Hitbox
        {
            get { return hitbox; }
        }

        public bool IsAlive { get; set; }

        public Mine() : this(Vector2.Zero)
        {

        }

        public Mine(Vector2 position)
        {
            _texture = null;
            _position = position;
            IsAlive = true;

            hitbox = new Rectangle((int)_position.X, (int)_position.Y, 0, 0);
            Random randY = new Random();
            Random randX = new Random();
            _position.X = randX.Next(0, 640);
            _position.Y = randY.Next(0, 480);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("mine");
        }

        public void Update()
        {
            _position.X -= _speed;

            hitbox = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

    }
}
