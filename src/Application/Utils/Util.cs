using System;

namespace Application
{
    public class Util
    {
        public static string GenerateTimeBasedGuid()
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
