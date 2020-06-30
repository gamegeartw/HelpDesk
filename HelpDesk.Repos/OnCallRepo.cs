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
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

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
        /// The get list.
        /// </summary>
        /// <param name="searchViewModel">
        /// The search view model.
        /// </param>
        /// <returns>
        /// The <see cref="IList{OnCallModel}"/>.
        /// </returns>
        public override IList<OnCallModel> GetList(FormSearchViewModel searchViewModel)
        {
            this.sql = @"
SELECT 
    o.*,p.[Key] as OnCallTypeDisplayName
FROM [dbo].[HELPDESK_ONCALLS] o 
left join dbo.PARAM_DATAS p on o.OnCallType = p.[Data] Where 1=1";
            if (searchViewModel != null && !string.IsNullOrWhiteSpace(searchViewModel.SearchText))
            {
                this.sql += $@"
And (
       o.DeptName Like @{nameof(searchViewModel.SearchText)} 
    OR o.EmpNo Like @{nameof(searchViewModel.SearchText)}
    OR o.EmpName Like @{nameof(searchViewModel.SearchText)}
    OR p.[Key] Like @{nameof(searchViewModel.SearchText)}
    OR o.[OnCallType] Like @{nameof(searchViewModel.SearchText)}
)";
            }

            this.sql = string.Format(this.TemplatePageStringByDesc, this.sql, "Id");

            return this.Conn?.Query<OnCallModel>(this.sql, searchViewModel).ToList();
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
            this.sql = $"Select * From HELPDESK_ONCALLS Where Id=@{nameof(searchViewModel.SearchText) }";
            return this.Conn.QueryFirstOrDefault<OnCallModel>(this.sql, searchViewModel);
        }

        public OnCallModel GetByDocNo(string docNo)
        {
            this.sql = $"Select * From HELPDESK_ONCALLS Where DocNo=@docNo";
            return this.Conn.QueryFirstOrDefault<OnCallModel>(this.sql, new { docNo });
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public override void Update(OnCallModel obj)
        {
            this.sql = $@"
Update HELPDESK_ONCALLS Set
 {nameof(obj.DeptNo)} = @{nameof(obj.DeptNo)}
,{nameof(obj.DeptName)} = @{nameof(obj.DeptName)}
,{nameof(obj.EmpNo)} = @{nameof(obj.EmpNo)}
,{nameof(obj.EmpName)} = @{nameof(obj.EmpName)} 
,{nameof(obj.CommitUser)} = @{nameof(obj.CommitUser)}
,{nameof(obj.CloseTime)} = @{nameof(obj.CloseTime)} 
,{nameof(obj.ExtNumber)} = @{nameof(obj.ExtNumber)} 
,{nameof(obj.OnCallReason)} = @{nameof(obj.OnCallReason)}
,{nameof(obj.OnCallType)} = @{nameof(obj.OnCallType)}
,{nameof(obj.ProcessTime)} = @{nameof(obj.ProcessTime)}
,{nameof(obj.ProcessUser)} = @{nameof(obj.ProcessUser)}
,{nameof(obj.SignPath)} = @{nameof(obj.SignPath)} 
,{nameof(obj.ProcessStatus)} = @{nameof(obj.ProcessStatus)}
Where Id=@Id
";
            this.Conn.Execute(this.sql, obj);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void Insert(OnCallModel data)
        {
            this.sql = $@"
Insert into HELPDESK_ONCALLS (
 {nameof(data.DocNo)}
,{nameof(data.DeptNo)}
,{nameof(data.DeptName)}
,{nameof(data.EmpNo)}
,{nameof(data.EmpName)}
,{nameof(data.OnCallType)}
,{nameof(data.OnCallReason)}
,{nameof(data.ProcessStatus)}
,{nameof(data.ExtNumber)}
) values
(
 @{nameof(data.DocNo)}
,@{nameof(data.DeptNo)}
,@{nameof(data.DeptName)}
,@{nameof(data.EmpNo)}
,@{nameof(data.EmpName)}
,@{nameof(data.OnCallType)}
,@{nameof(data.OnCallReason)}
,@{nameof(data.ProcessStatus)}
,@{nameof(data.ExtNumber)}
)";
            this.Conn.Execute(this.sql, data);
        }
    }
}
