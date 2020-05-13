// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeCompare.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the EmployeeCompare type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Utils
{
    using System;
    using System.Collections.Generic;

    using HelpDesk.ViewModels;

    /// <summary>
    /// The employee compare.
    /// </summary>
    public class EmployeeCompare : IEqualityComparer<EmployeeViewModel>
    {
        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="dataModel">
        /// The desc Model.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(EmployeeViewModel source, EmployeeViewModel dataModel)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Object is null");
            }

            if (dataModel == null)
            {
                throw new ArgumentNullException(nameof(dataModel), "Object is null");
            }

            return source.EMPNO == dataModel.EMPNO;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetHashCode(EmployeeViewModel obj)
        {
            return 0;
        }
    }
}
