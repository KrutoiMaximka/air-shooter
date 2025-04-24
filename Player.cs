using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace air_shooter
{
    public class Player
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed;

        public Player()
        {
            _position = new Vector2(30, 30);
            _texture = null;

            _speed = 7;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("player");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            spriteBatch.Draw(_texture,_position, Color.White);

            spriteBatch.End();
        }

        public void Update(int widthScreen, int heightScreen, ContentManager content)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.S))
            {
                _position.Y += _speed;
            }

            if (keyboard.IsKeyDown(Keys.W))
            {
                _position.Y -= _speed;
            }

            if (keyboard.IsKeyDown(Keys.A))
            {
                _position.X -= _speed;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                _position.X += _speed;
            }

            if (_position.X < 0)
            {
                _position.X = 0;
            }
            if (_position.X > widthScreen - _texture.Width)
            {
                _position.X = widthScreen - _texture.Width;
            }
            if (_position.Y < 0)
            {
                _position.Y = 0;
            }
            if (_position.Y > heightScreen - _texture.Height)
            {
                _position.Y = heightScreen - _texture.Height;
            }
        }
    }
}
