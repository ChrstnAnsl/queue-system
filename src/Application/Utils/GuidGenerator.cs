using System;

namespace Application.Utils
{
    public class GuidGenerator
    {
        public static Guid NewGuid()
        {
            Guid newGuid = Guid.NewGuid();

            return newGuid;
        }
    }

}
