
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    public class WeaponSpawner : BaseScript
    {
        public WeaponSpawner()
        {
            API.RegisterCommand("guns", new Action<int, List<object>, string>((src, args, raw) =>
            { 
                foreach (WeaponHash weapon in Enum.GetValues(typeof(WeaponHash)))
                {
                    if (Game.PlayerPed.Weapons.HasWeapon(weapon))
                    {
                        Game.PlayerPed.Weapons.Remove(weapon);
                    }
                    else 
                    { 
                        Game.PlayerPed.Weapons.Give(weapon, 250, false, true);
                    }
                }
            }), false);
        }
    }
}
