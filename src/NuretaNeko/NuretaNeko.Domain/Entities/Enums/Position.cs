using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Domain.Entities.Enums
{
    public enum Position
    {
        Frontend,
        Backend,
        AndroidDev
    }

    public static class PositionExtensions
    {
        public static string EnumToString(this Position me)
        {
            return me switch
            {
                Position.Backend => "Backend-разработчик",
                Position.Frontend => "Frontend-разработчик",
                Position.AndroidDev => "Android-разработчик",
                _ => string.Empty,
            };
        }

    }
}
