// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeViewModel.cs" company="NAFCO">
//   HelpDesk.ViewModels
// </copyright>
// <summary>
//   Defines the EmployeeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.ViewModels
{
    using System;

    /// <summary>
    /// The employee view model.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Gets or sets the jo b_ title.
        /// </summary>
        public string JOB_TITLE { get; set; }

        /// <summary>
        /// Gets or sets the salar y_ type.
        /// </summary>
        public string SALARY_TYPE { get; set; }

        /// <summary>
        /// Gets or sets the empno.
        /// </summary>
        public string EMPNO { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string TYPE { get; set; }

        /// <summary>
        /// Gets or sets the deptno.
        /// </summary>
        public string DEPTNO { get; set; }

        /// <summary>
        /// Gets or sets the dept name_ c.
        /// </summary>
        public string DeptName_C { get; set; }

        /// <summary>
        /// Gets or sets the dept name_ e.
        /// </summary>
        public string DeptName_E { get; set; }

        public string BOSS { get; set; }

        /// <summary>
        /// Gets or sets the bos s_ name.
        /// </summary>
        public string BOSS_NAME { get; set; }

        /// <summary>
        /// Gets or sets the grad e_ date.
        /// </summary>
        public DateTime GRADE_DATE { get; set; }

        /// <summary>
        /// Gets or sets the appoin t_ date.
        /// </summary>
        public DateTime APPOINT_DATE { get; set; }

        /// <summary>
        /// Gets or sets the titl e_ code.
        /// </summary>
        public string TITLE_CODE { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        /// Gets or sets the c c_ mai l_ name.
        /// </summary>
        public string CC_MAIL_NAME { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        public string GRADE { get; set; }
    }

}