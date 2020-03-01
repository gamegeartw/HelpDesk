// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonListComponent.ascx.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   按鈕命令集
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Components
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// 按鈕命令集
    /// </summary>
    public partial class ButtonListComponent : UserControl
    {
        /// <summary>
        /// The on click.
        /// </summary>
        public event EventHandler<CommandEventArgs> Click;

        /// <summary>
        /// Gets or sets the btn type.Value is Large or Small,Default is Large
        /// </summary>
        public string BtnType
        {
            get
            {
                if (this.ViewState[nameof(this.BtnType)] == null)
                {
                    return "Large";
                }
                return (string)this.ViewState[nameof(this.BtnType)];
            }

            set
            {
                this.ViewState[nameof(this.BtnType)] = value;
            }
        }

        public string ShowBtns
        {
            get
            {
                if (this.ViewState[nameof(this.ShowBtns)] == null)
                {
                    return string.Empty;
                }

                return (string)this.ViewState[nameof(this.ShowBtns)];
            }

            set
            {
                this.ViewState[nameof(this.ShowBtns)] = value;
            }
        }

        /// <summary>
        /// The on pre render.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnPreRender(EventArgs e)
        {
            var showBtns = this.ShowBtns.Split(',').ToList();
            Panel panel = null;

            if (this.BtnType == "Large")
            {
                this.PanelLarge.Visible = true;
                this.PanelSmall.Visible = false;
                panel = this.PanelLarge;
            }
            else
            {
                this.PanelLarge.Visible = false;
                this.PanelSmall.Visible = true;
                panel = this.PanelSmall;
            }

            // 找出Panel裡的所有按鈕,去比對Command是否有在清單內
            foreach (var btn in panel.Controls.OfType<LinkButton>())
            {
                btn.Visible = showBtns.Exists(m => btn.CommandName == m);
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// The on command.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        protected void OnCommand(object sender, CommandEventArgs args)
        {
            this.Click?.Invoke(sender, args);
        }
    }
}