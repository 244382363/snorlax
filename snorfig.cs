using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snorlax
{
    class snorfig
    {
        public Rectangle Rect;
        private Texture2D _txr, _mouth;
        Rectangle[] mouthRect = new Rectangle[2];

        public snorfig(Texture2D txr, int xPos, int yPos,Texture2D mouth)
        {
            for(int i = 0; i < 2; i++)
            {
                mouthRect[i] = new Rectangle(34*i,0,34,10);
            }
            _txr = txr;
            Rect = new Rectangle(xPos, yPos, _txr.Width, _txr.Height);
            _mouth = mouth;
           
        }
        public void UpdateMe()
        {

        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_txr, Rect, Color.White);
            //draws mouth when closed
            sb.Draw(_mouth, new Vector2(Rect.X + 94, Rect.Y + 32), mouthRect[0] ,Color.White);
        }
    }

}
