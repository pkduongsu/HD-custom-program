using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.BuffFactory
{
    public interface Buff
    {
        public void Draw();
        public void Move();
        public bool JetCollided(Jet jet);
        public void Update(Jet jet);
    }
}
