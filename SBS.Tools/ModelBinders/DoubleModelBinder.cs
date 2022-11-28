using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace SBS.Tools.ModelBinders
{
    public class DoubleModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None)
            {
                string doubleValue = valueResult.FirstValue;

                if (!string.IsNullOrEmpty(doubleValue))
                {
                    double actialValue = 0;
                    doubleValue = doubleValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    doubleValue = doubleValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    try
                    {
                        actialValue = Convert.ToDouble(doubleValue, CultureInfo.CurrentCulture);
                        bindingContext.Result = ModelBindingResult.Success(actialValue);
                    }
                    catch (FormatException fe)
                    {
                        bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
