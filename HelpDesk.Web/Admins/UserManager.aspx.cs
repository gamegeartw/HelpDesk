// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the UserManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Admins
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Models;
    using HelpDesk.ViewModels;

    using NLog;

    /// <summary>
    /// The user manager.
    /// </summary>
    public partial class UserManager : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets the search view model.
        /// </summary>
        public FormSearchViewModel SearchViewModel
        {
            get
            {
                if (this.ViewState[nameof(this.SearchViewModel)] != null)
                {
                    return (FormSearchViewModel)this.ViewState[nameof(this.SearchViewModel)];
                }

                return null;
            }

            set
            {
                this.ViewState[nameof(this.SearchViewModel)] = value;
            }
        }

        /// <summary>
        /// The delete user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        public void DeleteUser(string userId)
        {
            try
            {
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("Delete", e.Message);
                Logger.Error(e);
            }
        }

        /// <summary>
        /// The insert user.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void InsertUser(UserData model)
        {
            try
            {
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("Insert", e.Message);
                Logger.Error(e);
            }
        }

        /// <summary>
        /// The select users.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{UserData}"/>.
        /// </returns>
        public IEnumerable<UserData> SelectUsers()
        {
            try
            {
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("Select", e.Message);
                Logger.Error(e);
            }

            return null;
        }

        /// <summary>
        /// The update user.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void UpdateUser(UserData model)
        {
            try
            {
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("Update", e.Message);
                Logger.Error(e);
            }
        }

        /// <summary>
        /// The list view main_ on item command.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ListViewMain_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}