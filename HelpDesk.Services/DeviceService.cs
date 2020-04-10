// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceService.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the DeviceService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Services
{
    using System.Collections.Generic;

    using AutoMapper;

    using HelpDesk.Models;
    using HelpDesk.Repos;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;

    /// <summary>
    /// The device service.
    /// </summary>
    public class DeviceService : BaseService
    {
        /// <summary>
        /// The repo device.
        /// </summary>
        private readonly DeviceRepo repoDevice;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService"/> class.
        /// </summary>
        public DeviceService()
            : this(new DeviceRepo(ServiceUtils.GetConnection("HelpDesk")))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        public DeviceService(DeviceRepo repo)
        {
            this.Config = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<DeviceViewModel, DeviceModel>();
                    });
            this.IMapper = this.Config.CreateMapper();
            this.repoDevice = repo;
        }

        /// <summary>
        /// 取得所有資產設備清單
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IList{DeviceViewModel}"/>.
        /// </returns>
        public IList<DeviceViewModel> GetDeviceList(FormSearchViewModel searchViewModel)
        {
            var data = this.repoDevice.GetList(searchViewModel);

            return this.IMapper.Map<IList<DeviceViewModel>>(data);
        }

        /// <summary>
        /// 取得資產設備清單
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceViewModel"/>.
        /// </returns>
        public DeviceViewModel GetDevice(FormSearchViewModel searchViewModel)
        {
            var data = this.repoDevice.Get(searchViewModel);
            return this.IMapper.Map<DeviceViewModel>(data);
        }

        /// <summary>
        /// 更新資產設備清單
        /// </summary>
        /// <param name="device">
        /// The device.
        /// </param>
        public void UpdateDevice(DeviceViewModel device)
        {
            var data = this.IMapper.Map<DeviceModel>(device);
            this.repoDevice.Update(data);
        }

        /// <summary>
        /// 刪除資產設備清單
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void DeleteDevice(object key)
        {
            this.repoDevice.Delete(key);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.repoDevice?.Dispose();
            base.Dispose();
        }
    }
}
