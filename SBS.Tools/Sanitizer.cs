using Ganss.Xss;
using System.Reflection;

namespace SBS.Tools
{
    /// <summary>
    /// Sanitizing string values logic
    /// </summary>
    public static class Sanitizer
    {
        /// <summary>
        /// Sanitize all public string properties in a ViewModel object
        /// </summary>
        /// <param name="viewModel">ViewModel object to be sanitized</param>
        public static void Sanitize(object viewModel)
        {
            PropertyInfo[] properties= viewModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            HtmlSanitizer sanitizer = new HtmlSanitizer();
            foreach (PropertyInfo property in properties)
            {
                //Only string properties
                if(property.PropertyType == typeof(string))
                {
                    //Must be readable and writable
                    if(property.CanWrite && property.CanRead)
                    {
                        //Get and set must be public
                        MethodInfo? methodGet = property.GetGetMethod(false);
                        MethodInfo? methodSet = property.GetSetMethod(false);
                        if(methodGet!= null && methodSet != null)
                        {
                            string valueProp = (string)(property.GetValue(viewModel, null) ?? "");
                            valueProp = sanitizer.Sanitize(valueProp);
                            property.SetValue(viewModel, valueProp, null);
                        }
                    }
                }
            }
        }
    }
}
