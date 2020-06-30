// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonListComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The button list component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Enums;

    /// <summary>
    /// The button list component.
    /// </summary>
    public partial class ButtonListComponent : UserControl
    {
        /// <summary>
        /// The command.
        /// </summary>
        public event EventHandler<CommandEventArgs> Command;

        /// <summary>
        /// Gets or sets a value indicating whether is small icon.
        /// </summary>
        public bool IsSmallIcon
        {
            get
            {
                if (this.ViewState[nameof(this.IsSmallIcon)] != null)
                {
                    return (bool)this.ViewState[nameof(this.IsSmallIcon)];
                }

                return false;
            }

            set
            {
                this.ViewState[nameof(this.IsSmallIcon)] = value;
            }
        }

        // /// <summary>
        // /// Gets or sets the show btns.
        // /// </summary>
        // public string ShowBtns
        // {
        //     get
        //     {
        //         return (string)this.ViewState[nameof(this.ShowBtns)];
        //     }
        //
        //     set
        //     {
        //         this.ViewState[nameof(this.ShowBtns)] = value;
        //     }
        // }


        /// <summary>
        /// Gets or sets the btn list.
        /// </summary>
        [
            DefaultValue(null),
            TypeConverterAttribute(typeof(EnumConverter))
        ]
        
        public BtnList ShowBtns
        {
            get
            {
                return (BtnList)this.ViewState[nameof(this.ShowBtns)];
            }

            set
            {
                this.ViewState[nameof(this.ShowBtns)] = value;
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

        /// <summary>
        /// The on pre render.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnPreRender(EventArgs e)
        {
            //var showBtns = this.ShowBtns.Split(',');

            // foreach (var btnId in showBtns)
            // {
            //     var btn = this.FindControl($"LinkButton{btnId}") as LinkButton;
            //     if (btn != null)
            //     {
            //         btn.Visible = true;
            //         if (this.IsSmallIcon && !btn.CssClass.Contains("btn-sm"))
            //         {
            //             btn.CssClass += " btn-sm ";
            //         }
            //     }
            // }

            var btns = this.Controls.OfType<LinkButton>().ToList();
            foreach (var btn in btns)
            {
                var enumBtn = (BtnList)Enum.Parse(typeof(BtnList), btn.CommandName);
                btn.Visible = this.ShowBtns.HasFlag(enumBtn);
                if (this.IsSmallIcon && !btn.CssClass.Contains("btn-sm"))
                {
                    btn.CssClass += " btn-sm ";
                }
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// The link button_ on command.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void LinkButton_OnCommand(object sender, CommandEventArgs e)
        {
            this.OnCommand(e);
        }

        /// <summary>
        /// The on command.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected virtual void OnCommand(CommandEventArgs e)
        {
            this.Command?.Invoke(this, e);
        }
    }
}