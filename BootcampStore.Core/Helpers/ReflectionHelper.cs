using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;

namespace BootcampStore.Core.Helpers
{
    public static class ReflectionHelper
    {
        public static T GetDefault<T>() where T: new()
        {
            if(typeof(IEnumerable).IsAssignableFrom(typeof(T)))
            {
                return new T();
            }

            return default(T);
        }
    }
}
