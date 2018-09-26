using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PartyPopper
{
    public enum Team
    {
        BLUE,
        RED,
        YELLOW,
        GREEN,
        NONE
    }

    public static class TeamMethodsExtention
    {
        public static Color GetColor(this Team team)
        {
            switch (team)
            {
                case Team.NONE:
                    return Color.white;

                case Team.BLUE:
                    return Color.blue;

                case Team.GREEN:
                    return Color.green;

                case Team.RED:
                    return Color.red;

                case Team.YELLOW:
                    return Color.yellow;

                default:
                    return Color.white;
            }
        }
    }
}
