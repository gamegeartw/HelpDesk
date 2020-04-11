// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamsRepo.cs" company="NAFCO">
//   HelpDesk.Repos
// </copyright>
// <summary>
//   The params repo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Repos
{
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading;

    using Dapper;

    using HelpDesk.Models;
    using HelpDesk.ViewModels;

    /// <summary>
    /// The params repo.
    /// </summary>
    public class ParamsRepo : GeneralRepo<ParamData, FormSearchViewModel>
    {
        /// <summary>
        /// The query template.
        /// </summary>
        private string queryTemplate = "Select * from PARAM_DATAS Where 1=1";

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamsRepo"/> class.
        /// </summary>
        /// <param name="conn">
        /// The conn.
        /// </param>
        public ParamsRepo(IDbConnection conn)
            : base(conn)
        {
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ParamData"/>.
        /// </returns>
        public ParamData Get(int id)
        {
            var sql = $"{queryTemplate} And Id=@id";
            return this.Conn.QueryFirstOrDefault<ParamData>(sql, new { id });
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Insert(ParamData value)
        {
            var sql = "Insert into PARAM_DATAS ([Program],[Key],[Data],[IsEnable]) values (@Program,@Key,@Data,@IsEnable)";
            this.Conn.Execute(sql, value);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public new void Update(ParamData value)
        {
            var sql = "Update PARAM_DATAS Set Key = @Key,Data=@Data,IsEnable=@IsEnable Where Id=@Id";
            this.Conn.Execute(sql, value);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            var sql = "Delete PARAM_DATAS Where Id=@id";
            this.Conn.Execute(sql, new { id });
        }

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{ParamData}"/>.
        /// </returns>
        public new IEnumerable<ParamData> GetList(FormSearchViewModel searchViewModel)
        {
            var sb = new StringBuilder(this.queryTemplate);

            if (searchViewModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchViewModel.SearchText))
                {
                    searchViewModel.SearchText = $"%{searchViewModel.SearchText}%";
                    sb.AppendLine($" And (Key Like @{nameof(searchViewModel.SearchText)} or Data Like @{nameof(searchViewModel.SearchText)})");
                }
            }

            var sql = string.Format(this.TemplatePageString, sb, nameof(ParamData.Id));
            return this.Conn.Query<ParamData>(sql, searchViewModel);
        }
    }
}
