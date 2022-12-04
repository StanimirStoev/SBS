using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Tools.ModelBinders
{
    /// <summary>
    /// Provider for double data 
    /// </summary>
    public class DoubleModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Generate double model binder if it is possible and rturn it.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Binging provider for double data</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if(context== null)
            {
                throw new ArgumentNullException(nameof(context)); 
            }
            if(context.Metadata.ModelType == typeof(double) || context.Metadata.ModelType == typeof(double?))
            {
                return new DoubleModelBinder();
            }

            return null;
        }
    }
}
