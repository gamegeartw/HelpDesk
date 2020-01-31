using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.ViewModels
{
    using HelpDesk.Enums;

    public class ComputerEnrollViewModel
    {
        /// <summary>
        /// 單號
        /// </summary>
        public string DocNo { get; set; }

        /// <summary>
        /// 員工
        /// </summary>
        public string Employee => $"{this.EmpNo}-{this.EmpName}";

        /// <summary>
        /// 工號
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 部門代號
        /// </summary>
        public string DeptNo { get; set; }

        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 申請日期
        /// </summary>
        public DateTime EnrollDate { get; set; }

        /// <summary>
        /// 需求日期
        /// </summary>
        public DateTime? RequireDate { get; set; }

        /// <summary>
        /// 需求類別
        /// </summary>
        public int RequiredMode { get; set; }

        /// <summary>
        /// 驗收模式
        /// </summary>
        public int FinishMode { get; set; }

        /// <summary>
        /// 申請電腦的需求數量
        /// </summary>
        public int ComputerCount { get; set; }

        /// <summary>
        /// 申請電腦種類(每年訪商得到的規格,桌機,筆電,產線電腦)
        /// </summary>
        public string ComputerMode { get; set; }

        /// <summary>
        /// 申請電腦的特殊規格需求
        /// </summary>
        public IList<string> ComputerExtraRequired { get; set; }

        /// <summary>
        /// 有特殊規格需求，需要理級主管同意
        /// </summary>
        public bool RequiredCenterBossCommit { get; set; }

        /// <summary>
        /// 特殊規格需求理級主管覆核
        /// </summary>
        public bool CenterBossCommit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether computer_ mis commit.
        /// </summary>
        public bool Computer_MISCommit { get; set; }

        /// <summary>
        /// 申請網路線
        /// </summary>
        public bool RequireNetworkLine { get; set; }

        /// <summary>
        /// 佈線Layout
        /// </summary>
        public string RoomLayoutFile { get; set; }

        /// <summary>
        /// MIS確認
        /// </summary>
        public string MISCommitLayout { get; set; }

        /// <summary>
        /// 申請條碼機
        /// </summary>
        public bool RequiredBarCodeReader { get; set; }

        /// <summary>
        /// 條碼機的規格
        /// </summary>
        public string RequiredBarCodeReaderSpec { get; set; }

        /// <summary>
        /// 申請相機
        /// </summary>
        public bool RequiredCamera { get; set; }

        /// <summary>
        /// 相機的規格
        /// </summary>
        public string RequiredCameraSpec { get; set; }

        /// <summary>
        /// 申請隨身碟
        /// </summary>
        public bool RequiredUSB { get; set; }

        /// <summary>
        /// 申請電子秤(吊秤)
        /// </summary>
        public bool RequiredScale { get; set; }

        /// <summary>
        /// 申請其他設備
        /// </summary>
        public bool RequiredExtraDevice { get; set; }

        /// <summary>
        /// 申請其他設備的用途說明
        /// </summary>
        public string RequiredExtraDeviceSpec { get; set; }

        /// <summary>
        /// 目前進度
        /// </summary>
        public Status Status { get; set; }
    }
}
