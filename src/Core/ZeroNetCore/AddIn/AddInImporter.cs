﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Agebull.Common;
using Agebull.Common.Configuration;
using Agebull.Common.Ioc;
using Agebull.ZeroNet.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agebull.ZeroNet.ZeroApi
{
    /// <summary>
    /// MEF插件导入器
    /// </summary>
    internal class AddInImporter
    {
        /// <summary>
        /// 实例对象
        /// </summary>
        internal static AddInImporter Instance;

        /// <summary>
        /// 插件对象
        /// </summary>
        [ImportMany(typeof(IAutoRegister))]
        public IEnumerable<IAutoRegister> Registers {get; set; }

        /// <summary>
        /// 导入
        /// </summary>
        public static void Importe()
        {
            if (Instance != null)
                return;
            string path = ConfigurationManager.Root.GetValue("contentRoot", Environment.CurrentDirectory);
            if (!string.IsNullOrEmpty(ZeroApplication.Config.AddInPath))
                path = IOHelper.CheckPath(path, ZeroApplication.Config.AddInPath);
            ZeroTrace.WriteInfo("AddIn", path);
            Instance = new AddInImporter();
            IocHelper.ServiceCollection.AddSingleton(pro => Instance);
            // 通过容器对象将宿主和部件组装到一起。 
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(path);
            var container = new CompositionContainer(directoryCatalog);
            container.ComposeParts(Instance);
            foreach (var reg in Instance.Registers)
            {
                ZeroTrace.WriteInfo("AddIn", reg.GetType().Assembly.FullName);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            foreach (var reg in Registers)
            {
                reg.Initialize();
            }
        }

        /// <summary>
        /// 执行自动注册
        /// </summary>
        public void AutoRegist()
        {
            foreach (var reg in Registers)
                reg.AutoRegist();
        }

    }
}