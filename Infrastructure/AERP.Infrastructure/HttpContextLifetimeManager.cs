using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Web;

namespace AERP.Infrastructure
{
    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        public override object GetValue()
        {
            var assemblyQualifiedName = typeof(T).AssemblyQualifiedName;
            if (assemblyQualifiedName != null)
                return HttpContext.Current.Items[assemblyQualifiedName];
            return null;
        }

        public override void RemoveValue()
        {
            var assemblyQualifiedName = typeof(T).AssemblyQualifiedName;
            if (assemblyQualifiedName != null)
                HttpContext.Current.Items.Remove(assemblyQualifiedName);
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current.Items != null)
                HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = newValue;
        }

        public void Dispose()
        {
            RemoveValue();
        }
    }
}
