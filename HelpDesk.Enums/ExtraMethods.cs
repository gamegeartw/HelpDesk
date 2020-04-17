// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtraMethods.cs" company="NAFCO">
//   HelpDesk.Enums
// </copyright>
// <summary>
//   Defines the ExtraMethods type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Enums
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The extra methods.
    /// </summary>
    public static class ExtraMethods
    {
        /// <summary>
        /// The display name.
        /// </summary>
        /// <param name="enum">
        /// The enum.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string DisplayName(this Enum @enum)
        {
            try
            {
                var fields = @enum.GetType().GetFields();

                foreach (FieldInfo item in fields)
                {
                    EnumDisplayAttribute t = 
                        (EnumDisplayAttribute)Attribute
                            .GetCustomAttribute(item, typeof(EnumDisplayAttribute));
                    if (t != null)
                    {
                        return t.Name;
                    }
                }
            }
            catch 
            {
                // Igrone
            }

            return string.Empty;
        }
    }
}
