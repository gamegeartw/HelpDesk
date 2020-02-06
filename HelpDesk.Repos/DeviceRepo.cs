// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceRepo.cs" company="NAFCO">
//   HelpDesk ASP.NET
// </copyright>
// <summary>
//   The device repo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Repos
{
    using System.Collections.Generic;
    using System.Data;

    using HelpDesk.Models;
    using HelpDesk.ViewModels;

    /// <summary>
    /// The device repo.
    /// </summary>
    public class DeviceRepo : GeneralRepo<DeviceModel, FormSearchViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRepo"/> class.
        /// </summary>
        /// <param name="conn">
        /// The conn.
        /// </param>
        public DeviceRepo(IDbConnection conn)
            : base(conn)
        {
        }

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IList{DeviceModel}"/>.
        /// </returns>
        public override IList<DeviceModel> GetList(FormSearchViewModel searchViewModel)
        {
            return base.GetList(searchViewModel);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public override void Update(DeviceModel obj)
        {
            base.Update(obj);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public override void Delete(object key)
        {
            base.Delete(key);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceModel"/>.
        /// </returns>
        public override DeviceModel Get(FormSearchViewModel searchViewModel)
        {
            return base.Get(searchViewModel);
        }
    }
}
