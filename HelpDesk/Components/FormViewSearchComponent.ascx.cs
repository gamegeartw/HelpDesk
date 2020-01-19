// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormViewSearchComponent.ascx.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   查詢組件
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Components
{
    using System;
    using System.Web.UI;

    using HelpDesk.Events;
    using HelpDesk.ViewModels;

    /// <summary>
    /// 查詢組件
    /// </summary>
    public partial class FormViewSearchComponent : UserControl
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The finished.
        /// </summary>
        public event EventHandler<HelpDeskEventArgs<FormSearchViewModel>> Finished;

        /// <summary>
        /// 可顯示的項目,用分號分隔
        /// </summary>
        public string ShowItems
        {
            get
            {
                return (string)this.ViewState[nameof(this.ShowItems)];
            }

            set
            {
                this.ViewState[nameof(this.ShowItems)] = value;
            }
        }

        /// <summary>
        /// The insert form view model.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void InsertFormViewModel(FormSearchViewModel model)
        {
            try
            {
                if (this.Page.ModelState.IsValid)
                {
                    this.Finished?.Invoke(
                        this, 
                        new HelpDeskEventArgs<FormSearchViewModel>
                            {
                                ExtraObj = model
                            });
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError(e.Source, e.Message);
            }
        }

        /// <summary>
        /// The on finished.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected virtual void OnFinished(HelpDeskEventArgs<FormSearchViewModel> e)
        {
            this.Finished?.Invoke(this, e);
        }

        protected void FormViewMain_OnItemCreated(object sender, EventArgs e)
        {
            var panels = this.ShowItems.Split(',');

            foreach (var panel in panels)
            {
                var item = this.FormViewMain.FindControl(panel);
                if (item != null)
                {
                    item.Visible = true;
                }
            }
        }
    }
}