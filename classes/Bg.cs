using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace air_shooter.classes
{
    public class Bg
    {
        private Texture2D _texture;
        private Vector2 _position1;
        private Vector2 _position2;
        private float _speed;

        public float Speed
        {
            set => _speed = value;
        }

        public Bg()
        {
            _texture = null;
            _position1 = Vector2.Zero;
            _position2 = Vector2.Zero;// new Vector2(0, 0);
            _speed = 1;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("mainbackground");

            _position1 = new Vector2(_texture.Width, 0);
        }

        public void Update()
        {
            _position1.X += _speed;
            _position2.X += _speed;

            if (_position1.X >= 0)
            {
                _position1.X = -_texture.Width;
                _position2.X = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position1, Color.White);
            spriteBatch.Draw(_texture, _position2, Color.White);
        }
    }
}
