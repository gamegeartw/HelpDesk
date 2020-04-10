// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ADService.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the ADService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Services
{
    using System;
    using System.Collections.Generic;

    using Landpy.ActiveDirectory.Core;
    using Landpy.ActiveDirectory.Entity.Object;

    /// <summary>
    /// The ad service.
    /// </summary>
    public class ADService : BaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ADService"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        public ADService(IADOperator @operator)
        {
            this.ADOperator = @operator;
        }

        /// <summary>
        /// Gets or sets the handle exception.
        /// </summary>
        public Exception HandleException { get; set; }

        /// <summary>
        /// Gets or sets the ad operator.
        /// </summary>
        private IADOperator ADOperator { get; set; }

        /// <summary>
        /// Gets or sets the user object.
        /// </summary>
        private UserObject UserObject { get; set; }

        /// <summary>
        /// The disable user.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        public Exception DisableUser(string account)
        {
            this.UserObject = UserObject.FindOneBySAMAccountName(this.ADOperator, account);
            if (this.UserObject.IsAccountOperator || this.UserObject.IsDomainAdmin)
            {
                return new Exception("管理員帳號不可在這裡停用,請至AD伺服器作業");
            }

            if (!this.UserObject.IsEnabled)
            {
                return new Exception("帳號已停用,不能重覆執行");
            }
            this.UserObject.IsEnabled = false;
            this.UserObject.Save();

            return null;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.UserObject?.Dispose();
            if (this.ADOperator != null)
            {
                this.ADOperator = null;
            }

            base.Dispose();
        }

        /// <summary>
        /// The enable user.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        public Exception EnableUser(string account)
        {
            this.UserObject = UserObject.FindOneBySAMAccountName(this.ADOperator, account);
            if (this.UserObject.IsEnabled)
            {
                return new Exception("帳號已啟用,不能重覆執行");
            }

            this.UserObject.IsEnabled = true;
            this.UserObject.Save();
            return null;

        }

        /// <summary>
        /// The unlock.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        public Exception Unlock(string account)
        {
            this.UserObject = UserObject.FindOneBySAMAccountName(this.ADOperator, account);
            var entry = this.UserObject.DirectoryEntry;
            entry.InvokeSet("IsAccountLocked", false);
            entry.CommitChanges();

            return null;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{UserObject}"/>.
        /// </returns>
        public IList<UserObject> GetAll()
        {
            return UserObject.FindAll(this.ADOperator);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="UserObject"/>.
        /// </returns>
        public UserObject Get(string account)
        {
            return UserObject.FindOneBySAMAccountName(this.ADOperator, account);
        }
    }
}