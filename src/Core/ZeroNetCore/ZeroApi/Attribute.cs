using System;

namespace Agebull.ZeroNet.ZeroApi
{

    /// <summary>
    /// API访问配置
    /// </summary>
    [Flags]
    public enum ApiAccessOption
    {
        /// <summary>
        /// 不可访问
        /// </summary>
        None,
        /// <summary>
        /// 公开访问
        /// </summary>
        Public = 0x1,
        /// <summary>
        /// 内部访问
        /// </summary>
        Internal = 0x2,

        /// <summary>
        /// 游客
        /// </summary>
        Anymouse = 0x4,
        /// <summary>
        /// 客户
        /// </summary>
        Customer = 0x10,
        /// <summary>
        /// 内部员工
        /// </summary>
        Employe = 0x20,
        /// <summary>
        /// 商家用户
        /// </summary>
        Business = 0x40,
        /// <summary>
        /// 扩展用户性质3
        /// </summary>
        User1 = 0x80,
        /// <summary>
        /// 扩展用户性质2
        /// </summary>
        User2 = 0x100,
        /// <summary>
        /// 扩展用户性质3
        /// </summary>
        User3 = 0x200,
        /// <summary>
        /// 扩展用户性质4
        /// </summary>
        User4 = 0x400,
        /// <summary>
        /// 扩展用户性质5
        /// </summary>
        User5 = 0x800,
        /// <summary>
        /// 扩展用户性质6
        /// </summary>
        User6 = 0x1000,
        /// <summary>
        /// 扩展用户性质7
        /// </summary>
        User7 = 0x4000,
        /// <summary>
        /// 扩展用户性质8
        /// </summary>
        User8 = 0x8000,

        /// <summary>
        /// 参数可以为null
        /// </summary>
        ArgumentCanNil = 0x10000
    }

    /// <summary>
    /// API配置过滤器
    /// </summary>
    public class ApiAccessOptionFilterAttribute : Attribute
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="option"></param>
        public ApiAccessOptionFilterAttribute(ApiAccessOption option)
        {
            Option = option;
        }
        /// <summary>
        /// 配置
        /// </summary>
        public ApiAccessOption Option { get; }
    }


    /// <summary>
    /// 站点名称
    /// </summary>
    public class StationAttribute : Attribute
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="name"></param>
        public StationAttribute(string name)
        {
            Name = name;
        }
        /// <summary>
        /// 配置
        /// </summary>
        public string Name { get; }
    }

    /// <summary>
    /// 路由名称
    /// </summary>
    public class RouteAttribute : Attribute
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="name"></param>
        public RouteAttribute(string name)
        {
            Name = name;
        }
        /// <summary>
        /// 配置
        /// </summary>
        public string Name { get;}
    }

}
