// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayAttribute.cs" company="NAFCO">
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
    public class DisplayAttribute : Attribute
    {
        public DisplayAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 列舉要顯示的名稱
        /// </summary>
        public string Name { get; set; }
    }
}
