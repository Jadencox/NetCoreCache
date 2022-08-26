namespace Cache
{
    public enum CacheNameConstants
    {
        /// <summary>
        /// 默认的Cache name
        /// </summary>
        DoCare_Caching_Default = 1,

        /// <summary>
        /// 权限验证
        /// </summary>
        DoCare_Caching_Framework_Authority = 2,

        /// <summary>
        /// 方法注入的cache name
        /// </summary>
        DoCare_Caching_Interception_CachingInterceptor = 3,

        /// <summary>
        /// Dict table cache name
        /// </summary>
        DoCare_Caching_Dict = 4,

        /// <summary>
        /// 患者相关的Cache Name
        /// </summary>
        Docare_Caching_Patient = 5,

        /// <summary>
        /// 大屏
        /// </summary>
        DoCare_Caching_Screen = 6,

    }

    public enum CacheKeyConstants
    {
        #region DoCare_Caching_Default
        /// <summary>
        /// 质控统计
        /// </summary>
        ClinicalQualityStatistics,

        /// <summary>
        /// 文书归档配置
        /// </summary>
        DocumentArchiveConfig,

        /// <summary>
        /// 系统授权文件
        /// </summary>
        SystemLicence,

        #endregion

        #region DoCare_Caching_Framework_Authority

        AuthorityCache,
        UserRoleCache,
        RoleActionCache,

        #endregion

        #region DoCare_Caching_Interception_CachingInterceptor

        AuthoritiesCache,

        #endregion

        #region DoCare_Caching_Dict

        DictCache,

        /// <summary>
        /// 系统参数缓存
        /// </summary>
        SystemConfigCache,

        /// <summary>
        /// 科室参数缓存
        /// </summary>
        WardConfigCache,

        #endregion

        #region Docare_Caching_Patient

        InWardPatient,

        #endregion

        #region Docare_Caching_Monitor
        /// <summary>
        /// 监测表单缓存结构
        /// </summary>
        MonitorCachingStruct,

        /// <summary>
        /// 监测表单成组缓存
        /// </summary>
        MonitorCachingGroup,
        #endregion

        #region DoCare_Caching_Doctor_Overview
        /// <summary>
        /// 体征列表
        /// </summary>
        Doctor_Overview_Sign,
        /// <summary>
        /// 导管列表
        /// </summary>
        Doctor_Overview_Cath,
        /// <summary>
        /// 检查检验主表
        /// </summary>
        Doctor_Overview_LabMaster,
        /// <summary>
        /// 医嘱执行记录
        /// </summary>
        Doctor_Overview_OrderExec,
        #endregion

        #region DoCare_Caching_Screen

        DoCare_Caching_Screen_PatFromSource,

        #endregion

        MyCache,

        MyCacheUser,

    }
}
