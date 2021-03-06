﻿using Autofac;
using System;
using BK.IBLL;
using BK.BLL;

namespace BK.BLLContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("IOC实例化出错!" + ex.Message);
            }

            return container.Resolve<T>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MfcBLL>().As<IMfcBLL>().InstancePerLifetimeScope();
            builder.RegisterType<PostsBLL>().As<IPostsBLL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
