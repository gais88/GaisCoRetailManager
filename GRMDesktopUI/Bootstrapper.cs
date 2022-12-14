using Caliburn.Micro;
using GRMDesktopUI.Helper;
using GRMDesktopUI.Library.Helper;
using GRMDesktopUI.Library.Models;
using GRMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GRMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }
        protected override void Configure()
        {
            _container.Instance(_container)
                   .PerRequest<IProductEndPoint,ProductEndPoint>();

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILogInUser, LogInUser>()
                .Singleton<IApiHelper, ApiHelper>();

            GetType().Assembly.GetTypes()
                     .Where(x => x.IsClass)
                     .Where(x => x.Name.EndsWith("ViewModel"))
                     .ToList()
                     .ForEach(modelViewType => _container.RegisterPerRequest(
                         modelViewType, modelViewType.ToString(), modelViewType));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<ShellViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
