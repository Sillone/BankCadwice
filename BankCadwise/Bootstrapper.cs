using BankCadwise.Models;
using BankCadwise.Utils;
using BankCadwise.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BankCadwise
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
        private readonly SimpleContainer _container = new SimpleContainer();

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void Configure()
        {
            _container.RegisterInstance(typeof(SimpleContainer), "Coniainer", _container);
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<SerializePerson>();
            _container.Singleton<Bank>();
            _container.Singleton<MainViewModel>();
            _container.PerRequest<GetCashMenuViewModel>();
            _container.PerRequest<MenuViewModel>();
            _container.PerRequest<AuthenticationViewModel>();
            _container.PerRequest<GetCertainValueViewModel>();
            _container.PerRequest<GetCashViewModel>();
            _container.PerRequest<DepositeViewModel>();
        }
    }
}


