// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallService.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   The on call service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Services
{
    using System.Data;

    using AutoMapper;

    using HelpDesk.Models;
    using HelpDesk.Repos;
    using HelpDesk.ViewModels;

    /// <summary>
    /// The on call service.
    /// </summary>
    public class OnCallService : BaseService
    {
        /// <summary>
        /// The repo.
        /// </summary>
        private readonly OnCallRepo repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCallService"/> class.
        /// </summary>
        /// <param name="conn">
        /// The conn.
        /// </param>
        public OnCallService(IDbConnection conn)
        {
            this.repo = new OnCallRepo(conn);
            this.Config = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<ServiceOnCallViewModel, OnCallModel>()
                            .ForMember(m => m.Id, o => o.Ignore())
                            .ForMember(m => m.DocNo, o => o.Ignore())
                            .ForMember(m => m.ProcessDetails, o => o.Ignore());
                    });
            this.Config.AssertConfigurationIsValid();
            this.IMapper = this.Config.CreateMapper();
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Insert(ServiceOnCallViewModel value)
        {
            var data = this.IMapper.Map<OnCallModel>(value);
            this.repo.Insert(data);
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
