using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace snorlax
{

    enum WinggullState
    {
        Flying,
        overscreen
    }
    class winggulls
    {
        WinggullState _currState;
        public Rectangle Rect;
        Texture2D _txr;
        int _dir;
        public float speed;
        private bool _goingRight;
        SpriteEffect _effect;

        Vector2 _pos;
        Vector2 _vel;

        public winggulls(Texture2D txr, int maxY, int maxX, int dir)
        {
            //start flying
            _currState = WinggullState.Flying;
            _dir = dir;
            _txr = txr;
            speed = Game1.RNG.Next(1, 6);

            //pick a random poing along the "side line" to start
            _pos = new Vector2(0, Game1.RNG.Next(0, 300));
            Rect = new Rectangle(maxY,maxX, _txr.Width, _txr.Height );

            //pick a random velocity
            _vel = new Vector2((float)Game1.RNG.NextDouble() * 2 + 0.5f, 0);
            _goingRight = true;
        }

        public WinggullState GetState()
        {
            return _currState;
        }

        public void UpdateMe(int maxX, int maxY)
        {
            _pos = _pos + _vel;
            //_dir = 1;
            if (_pos.X > maxX)
            {
                _goingRight = false;
                _vel.X = -_vel.X;

            }
            else if (_pos.X <=0)
            {
                _goingRight = true;
                _vel.X = -_vel.X;
            }
        }
        /*public void UpdateMe(int maxX)
        {
            //move the winggull by it's velocity
            _pos += _vel;

            //if it's overscreen, change to "overscreen" state
            if (_pos.Y > maxX)
                _currState = WinggullState.overscreen;

            //make sure the rectangle follows the position
            Rect.Location = _pos.ToPoint();

        }*/


        public void DrawMe(SpriteBatch sb)
        {
            if (_goingRight)
                sb.Draw(_txr, _pos, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);

            else
                sb.Draw(_txr, _pos, Color.White);
            


            /*sb.Draw(_txr, _pos, null, Color.White,0,
                 Vector2.Zero,Vector2.One,
                SpriteEffects.None, 0);*/
        }
        /*public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_txr, Rect, Color.White);
        }*/
    }
}
