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
    using System;
    using System.Collections.Generic;
    using System.Data;

    using AutoMapper;

    using HelpDesk.Enums;
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
                            .ForMember(m => m.OnCallTypeDisplayName, o => o.Ignore())
                            .ForMember(m => m.ProcessDetails, o => o.Ignore())
                            .ForMember(m => m.StartRowIndex, o => o.Ignore())
                            .ForMember(m => m.MaximumRows, o => o.Ignore())
                            .ForMember(m => m.TotalRowCount, o => o.Ignore());
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
            data.DocNo = this.repo.GenAutoNo("NAFCO", "OnCall", "OC", DateTime.Now.ToString("yyyyMM"));
            data.ProcessStatus = ProcessStatus.Enroll;
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

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IList{OnCallModel}"/>.
        /// </returns>
        public IList<OnCallModel> GetList(FormSearchViewModel searchViewModel)
        {
            return this.repo.GetList(searchViewModel);
        }

        /// <summary>
        /// 結案作業
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void CloseReport(string id)
        {
            var item = this.repo.Get(new FormSearchViewModel { SearchText = id });
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item.Id), "沒有這筆資料");
            }

            if (item.ProcessStatus == ProcessStatus.Finish)
            {
                throw new ArgumentNullException(nameof(item.Id), "已結案,無法再進行");
            }

            if (item.ProcessStatus == ProcessStatus.Rollback)
            {
                throw new ArgumentNullException(nameof(item.Id), "退件中,無法結案");
            }

            if (item.ProcessStatus == ProcessStatus.OnService)
            {
                throw new ArgumentNullException(nameof(item.Id), "送修中,無法結案");
            }

            item.ProcessStatus = ProcessStatus.Finish;

            this.repo.Update(item);
        }

        /// <summary>
        /// The get by doc no.
        /// </summary>
        /// <param name="docNo">
        /// The doc no.
        /// </param>
        /// <returns>
        /// The <see cref="OnCallModel"/>.
        /// </returns>
        public OnCallModel GetByDocNo(string docNo)
        {
            return this.repo.GetByDocNo(docNo);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="OnCallModel"/>.
        /// </returns>
        public OnCallModel Get(FormSearchViewModel model)
        {
            return this.repo.Get(model);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Update(OnCallModel model)
        {
            this.repo.Update(model);
        }
    }
}
