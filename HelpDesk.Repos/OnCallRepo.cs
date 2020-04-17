// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallRepo.cs" company="NAFCO">
//   HelpDesk.Repos
// </copyright>
// <summary>
//   The on call repo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Repos
{
    using System.Data;
    using System.Text;

    using Dapper;

    using HelpDesk.Models;
    using HelpDesk.ViewModels;

    /// <summary>
    /// The on call repo.
    /// </summary>
    public class OnCallRepo : GeneralRepo<OnCallModel, FormSearchViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCallRepo"/> class.
        /// </summary>
        /// <param name="conn">
        /// The conn.
        /// </param>
        public OnCallRepo(IDbConnection conn)
            : base(conn)
        {
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="OnCallModel"/>.
        /// </returns>
        public override OnCallModel Get(FormSearchViewModel searchViewModel)
        {
            this.sql = $"Select * From HELPDESK_ONCALLS Where Id=@{searchViewModel.SearchText}";
            return this.Conn.QueryFirstOrDefault<OnCallModel>(this.sql, searchViewModel);
        }

        public override void Update(OnCallModel obj)
        {
            var sb = new StringBuilder("Update HELPDESK_ONCALLS Set");

            sb.AppendLine($" {nameof(obj.DeptNo)} = @{nameof(obj.DeptNo)} ");
            sb.AppendLine($" ,{nameof(obj.DeptName)} = @{nameof(obj.DeptName)} ");
            sb.AppendLine($" ,{nameof(obj.EmpNo)} = @{nameof(obj.EmpNo)} ");
            sb.AppendLine($" ,{nameof(obj.EmpName)} = @{nameof(obj.EmpName)} ");
            sb.AppendLine($" ,{nameof(obj.CommitUser)} = @{nameof(obj.CommitUser)} ");
            sb.AppendLine($" ,{nameof(obj.CloseTime)} = @{nameof(obj.CloseTime)} ");
            sb.AppendLine($" ,{nameof(obj.ExtNumber)} = @{nameof(obj.ExtNumber)} ");
            sb.AppendLine($" ,{nameof(obj.OnCallReason)} = @{nameof(obj.OnCallReason)} ");
            sb.AppendLine($" ,{nameof(obj.OnCallType)} = @{nameof(obj.OnCallType)} ");
            sb.AppendLine($" ,{nameof(obj.ProcessTime)} = @{nameof(obj.ProcessTime)} ");
            sb.AppendLine($" ,{nameof(obj.ProcessUser)} = @{nameof(obj.ProcessUser)} ");
            sb.AppendLine($" ,{nameof(obj.SignPath)} = @{nameof(obj.SignPath)} ");
            sb.AppendLine(" Where Id=@Id");
        }

        public void Insert(OnCallModel data)
        {
            this.sql = $@"
Insert into HELPDESK_ONCALLS (
{data.DocNo}
,{data.DeptNo}
,{data.DeptName}
,{data.EmpNo}
,{data.EmpName}
,{data.CreateTime}
,{data.OnCallType}
,{data.OnCallReason}
) values
(
 @{data.DocNo}
,@{data.DeptNo}
,@{data.DeptName}
,@{data.EmpNo}
,@{data.EmpName}
,@{data.CreateTime}
,@{data.OnCallType}
,@{data.OnCallReason}
)";
            this.Conn.Execute(this.sql, data);
        }
    }
}
