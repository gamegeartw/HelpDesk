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
    /// <typeparam name="TU">
    /// U is class
    /// </typeparam>
    public class GeneralRepo<T, TU> : IDisposable
        where T : class where TU : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralRepo{T,TU}"/> class.
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
        protected string sql { get; set; }

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
        /// The delete.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public virtual void Delete(object key)
        {
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Conn?.Dispose();
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
        public virtual T Get(TU searchViewModel)
        {
            return null;
        }

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public virtual IList<T> GetList(TU searchViewModel)
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
    }
}