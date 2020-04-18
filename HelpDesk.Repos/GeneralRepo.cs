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

    using Dapper;

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

        /// <summary>
        /// The gen auto no.
        /// </summary>
        /// <param name="programId">
        /// The program id.
        /// </param>
        /// <param name="strYYYYMM">
        /// The str yyyymm.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GenAutoNo(string companyID, string programId,string prgHead, string strYYYYMM)
        {
            var param = new { companyID, programId, prgHead, strYYYYMM };
            this.Conn.Open();
            using (var tran = this.Conn.BeginTransaction())
            {
                this.sql = "SELECT TOP 1 PrgNumber FROM GNAUTO WHERE 1=1 AND PRGID = @programId and PrgHead = @prgHead AND PrgYymm = @strYYYYMM";
                var result1 = this.Conn.QueryFirstOrDefault<int>(this.sql, param, tran);
                if (result1 != 0)
                {
                    this.sql = @" UPDATE GNAUTO SET PrgNumber= PrgNumber + 1 WHERE PRGID = @programId and PrgHead = @prgHead And AND PrgYymm = @strYYYYMM";
                    result1++;
                }
                else
                {
                    this.sql = @"INSERT INTO GNAUTO(CompanyID, PRGID, PrgHead, PrgYymm ,prgNumber)
                                             VALUES(@companyID, @programId, @prgHead,@strYYYYMM,  1 )";
                    result1 = 1;
                }

                this.Conn.Execute(this.sql, param);

                return $"{programId}{strYYYYMM}{result1:00000}";
            }
        }
    }
}