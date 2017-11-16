using System;
using System.Collections.Generic;
using Unity;
using System.Linq;

namespace BookLibrary.Infrastructure.InjectionFramework
{
    public class InjectContainer
    {
        private static IUnityContainer unityContainer;

        static InjectContainer()
        {
            unityContainer = new UnityContainer();
        }

        public static IUnityContainer Current
        {
            get
            {
                return unityContainer;
            }
        }

        public static void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            unityContainer.RegisterType<TFrom, TTo>();


        }

        public static void RegisterType(Type from, Type to)
        {
            unityContainer.RegisterType(from, to);
        }

        public static void RegisterInstance<T>(T o)
        {
            unityContainer.RegisterInstance(typeof(T), o);
        }

        public static void RegisterInstance(Type t, object instance)
        {
            unityContainer.RegisterInstance(t, instance);
        }

        public static T GetInstance<T>()
        {
            try
            {
                return unityContainer.Resolve<T>();
            }
            catch (Exception ex)
            {
                //Console.Write(ex.ToString());
                return default(T);
            }
        }
    }
}