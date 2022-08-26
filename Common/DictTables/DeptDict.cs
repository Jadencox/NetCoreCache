using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.DictTables
{
    [Table("DEPTDICT")]
    public class DeptDict
    {
        /// <summary>
        /// 部门代码
        /// </summary>
        [Column("DEPTCODE", TypeName = "NVARCHAR2(50)")]
        [Description("部门代码")]
        [Key]
        public string DeptCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("DEPTNAME", TypeName = "NVARCHAR2(50)")]
        [Description("部门名称")]
        public string DeptName { get; set; }
    }
}
