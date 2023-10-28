using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace snorlax
{

    enum poffinState
    {
        Falling,
        Crashed
    }
    class poffin
    {
        poffinState _currState;
        public Rectangle Rect;
        Texture2D _txr;
        Vector2 _pos;
        Vector2 _vel;


        public poffin(Texture2D txr, int xPos, int yPos)
        {
            _txr = txr;
            Rect = new Rectangle(xPos, yPos, _txr.Width, _txr.Height);
            _pos = new Vector2(xPos, yPos);
            _vel = new Vector2(Game1.RNG.Next(-2, 2), (float)Game1.RNG.NextDouble() + 0.25f);
            _currState = poffinState.Falling;
        }


        public poffinState GetState()
        {
            return _currState;
        }

        public void UpdateMe(Rectangle mouthRect)
        {
            if (_currState == poffinState.Falling)
            {
                // Add gravity or any movement logic here
                _pos += _vel;
                Rect = new Rectangle((int)_pos.X, (int)_pos.Y, _txr.Width, _txr.Height);

                // Check for collision with the mouth
                if (Rect.Intersects(mouthRect))
                {
                    _currState = poffinState.Crashed;
                    // Perform any actions for the collision
                }
            }
        }
        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_txr, Rect, Color.White);
        }

    }
}
