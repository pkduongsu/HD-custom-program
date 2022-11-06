using Asteroids.AsteroidFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.BuffFactory
{
    public abstract class BuffCreator
    {
        public abstract Buff CreateBuff();

        public void Operations(List<Buff> buffs)
        {
            Buff newBuff = CreateBuff();

            buffs.Add(newBuff);
        }
    }
}
