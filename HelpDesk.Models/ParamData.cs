// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamData.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   The params data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The params data.
    /// </summary>
    [Serializable]
    public class ParamData : BaseClass
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Display(Name = "編號")]
        [DefaultValue(0)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the program.
        /// </summary>
        [Key]
        [Display(Name = "項目")]
        [Column(Order = 1)]  
        [MaxLength(50)]
        public string Program { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [Display(Name = "Key")]
        [Key]
        [Column(Order = 2)]  
        [MaxLength(50)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [Display(Name = "內容")]
        [MaxLength(255)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is enable.
        /// </summary>
        [Display(Name = "啟用狀態")]
        [DefaultValue(true)]
        public bool IsEnable { get; set; }
    }
}
