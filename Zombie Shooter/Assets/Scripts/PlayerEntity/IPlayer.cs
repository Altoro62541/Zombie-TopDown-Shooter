using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieShooter.HealthSystem;

namespace ZombieShooter.PlayerEntity
{
    public interface IPlayer
    {
        IHeathComponent HeathComponent { get; }
    }
}
