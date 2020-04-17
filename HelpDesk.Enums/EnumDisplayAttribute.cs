// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumDisplayAttribute.cs" company="NAFCO">
//   HelpDesk.Enums
// </copyright>
// <summary>
//   The display attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Enums
{
    using System;

    /// <summary>
    /// The display attribute.
    /// </summary>
    public class EnumDisplayAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumDisplayAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public EnumDisplayAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 列舉要顯示的名稱
        /// </summary>
        public string Name { get; set; }
    }
}
