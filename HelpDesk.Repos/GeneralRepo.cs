// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneralRepo.cs" company="NAFCO">
//   HelpDesk.Repos
// </copyright>
// <summary>
//   The general repo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Repos
{
    using System;
    using System.Data;

    /// <summary>
    /// The general repo.
    /// </summary>
    public class GeneralRepo : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralRepo"/> class.
        /// </summary>
        /// <param name="conn">
        /// The conn.
        /// </param>
        public GeneralRepo(IDbConnection conn)
        {
            this.Conn = conn;
        }

        /// <summary>
        /// Gets the conn.
        /// </summary>
        protected IDbConnection Conn { get; }

        /// <summary>
        /// Gets or sets the query string.
        /// </summary>
        protected string QueryString { get; set; }

        /// <summary>
        /// 分頁檔範本(正向)
        /// </summary>
        protected string TemplatePageString =>
            @"
;WITH T
AS (
{0}
    )
SELECT TotalRowCount = COUNT(1) OVER (), T.*
FROM T
ORDER BY {1} OFFSET(@StartRowIndex) ROWS

FETCH NEXT @MaximumRows ROWS ONLY;
";

        /// <summary>
        /// 分頁檔範本(反向)
        /// </summary>
        protected string TemplatePageStringByDesc =>
            @"
;WITH T
AS (
{0}
    )
SELECT TotalRowCount = COUNT(1) OVER (), T.*
FROM T
ORDER BY {1} Desc OFFSET(@StartRowIndex) ROWS

FETCH NEXT @MaximumRows ROWS ONLY;
";

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Conn?.Dispose();
        }
    }
}