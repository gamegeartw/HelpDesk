// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormSearchComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The form search component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.ViewModels;
    using HelpDesk.Web.Events;

    using NLog;

    /// <summary>
    /// The form search component.
    /// </summary>
    public partial class FormSearchComponent : UserControl
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The search.
        /// </summary>
        public event EventHandler<HelpDeskEventArgs<FormSearchViewModel>> Search;

        /// <summary>
        /// Gets or sets the show items.
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
        /// The insert.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Insert(FormSearchViewModel model)
        {
            try
            {
                if (this.Page.ModelState.IsValid)
                {
                    Logger.Info("查詢作業");
                    foreach (var pi in model.GetType().GetProperties())
                    {
                        try
                        {
                            if (pi.GetValue(model) != null)
                            {
                                Logger.Info($"參數:{pi.Name},值:{pi.GetValue(model)}");
                            }
                        }
                        catch (Exception)
                        {
                            // ignore
                        }
                    }

                    this.OnSearch(new HelpDeskEventArgs<FormSearchViewModel> { Data = model });
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError("Search", e.Message);
            }
        }

        /// <summary>
        /// The form view main_ on item inserted.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void FormViewMain_OnItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            e.KeepInInsertMode = true;
        }

        /// <summary>
        /// The link button submit_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void LinkButtonSubmit_OnClick(object sender, EventArgs e)
        {
            var model = new FormSearchViewModel
                            {
                                SearchText = this.TextBoxSearchText.Text.Trim()
                            };

            if (!string.IsNullOrWhiteSpace(this.TextBoxStartDate.Text))
            {
                model.StartDate = DateTime.Parse(this.TextBoxCloseDate.Text.Trim());
            }

            if (!string.IsNullOrWhiteSpace(this.TextBoxCloseDate.Text))
            {
                model.CloseDate = DateTime.Parse(this.TextBoxCloseDate.Text.Trim());
            }

            this.OnSearch(new HelpDeskEventArgs<FormSearchViewModel>() { Data = model });
        }

        /// <summary>
        /// The on pre render.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            foreach (var item in this.ShowItems.Split(','))
            {
                var control = this.PanelMain.FindControl($"Panel{item}");
                if (control != null)
                {
                    control.Visible = true;
                }
            }
        }

        /// <summary>
        /// The on search.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected virtual void OnSearch(HelpDeskEventArgs<FormSearchViewModel> e)
        {
            this.Search?.Invoke(this, e);
        }

        /// <summary>
        /// The page_ init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        protected void Page_Init(object sender, EventArgs args)
        {
            foreach (var item in this.ShowItems.Split(','))
            {
                var control = this.PanelMain.FindControl($"Panel{item}");
                if (control != null)
                {
                    control.Visible = true;
                }
            }
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