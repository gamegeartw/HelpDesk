// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseService.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   The base service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Services
{
    using System;
    using System.Data;

    using AutoMapper;

    /// <summary>
    /// The base service.
    /// </summary>
    public class BaseService : IDisposable
    {
        /// <summary>
        /// Gets or sets the conn.
        /// </summary>
        protected IDbConnection SqlConn { get; set; }

        /// <summary>
        /// Gets or sets the erp conn.
        /// </summary>
        protected IDbConnection ERPConn { get; set; }

        /// <summary>
        /// The config.
        /// </summary>
        protected MapperConfiguration Config { get; set; }

        /// <summary>
        /// The i mapper.
        /// </summary>
        protected IMapper IMapper { get; set; }


        /// <summary>
        /// The dispose.
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
