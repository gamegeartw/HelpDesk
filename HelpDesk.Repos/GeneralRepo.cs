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
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// The general repo.
    /// </summary>
    /// <typeparam name="T">
    /// T is class
    /// </typeparam>
    public class GeneralRepo<T,U> : IDisposable
        where T : class where U : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralRepo{T,U}"/> class.
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
        /// The get list.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public virtual IList<T> GetList(U searchViewModel)
        {
            return null;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public virtual void Update(T obj)
        {

        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public virtual void Delete(object key)
        {
            }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T Get(U searchViewModel)
        {
            return null;
        }

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