using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;



namespace SBS.Tools.ModelBinders
{
    /// <summary>
    /// Model bindig methods for double numbers
    /// </summary>
    public class DoubleModelBinder : IModelBinder
    {
        /// <summary>
        /// Model bindig for double number
        /// </summary>
        /// <param name="bindingContext">Context Data </param>
        /// <returns></returns>
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
