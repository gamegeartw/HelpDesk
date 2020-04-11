// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamsService.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   The params service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Services
{
    using System.Collections.Generic;
    using System.Data;

    using HelpDesk.Models;
    using HelpDesk.Repos;
    using HelpDesk.ViewModels;

    /// <summary>
    /// The params service.
    /// </summary>
    public class ParamsService : BaseService
    {
        /// <summary>
        /// The repo.
        /// </summary>
        private ParamsRepo repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamsService"/> class.
        /// </summary>
        /// <param name="conn">
        /// The conn.
        /// </param>
        public ParamsService(IDbConnection conn)
        {
            this.repo = new ParamsRepo(conn);
        }

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{KeyValuePair}"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetKeyValuePairs(FormSearchViewModel searchViewModel)
        {
            var list = this.GetList(searchViewModel);
            var result = new List<KeyValuePair<string, string>>();

            foreach (var paramData in list)
            {
                result.Add(new KeyValuePair<string, string>(paramData.Key, paramData.Data));
            }

            return result;
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
        public IEnumerable<ParamData> GetList(FormSearchViewModel searchViewModel)
        {
            return this.repo.GetList(searchViewModel);
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
            return this.repo.Get(id);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Update(ParamData value)
        {
            this.repo.Update(value);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Insert(ParamData value)
        {
            this.repo.Insert(value);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.repo?.Dispose();
            base.Dispose();
        }
    }
}
