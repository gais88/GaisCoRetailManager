using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using GRMDesktopUI.Events;

namespace GRMDesktopUI.ViewModels
{
    public class ShellViewModel :Conductor<object>,IHandle<LogInEvent>
    {
        private SalesViewModel _salesViewModel;
        private readonly SimpleContainer _container;
        private IEventAggregator _eventagger;

        public ShellViewModel(LoginViewModel loginVM ,SimpleContainer container,SalesViewModel salesViewModel,IEventAggregator eventaggr)
        {
            _container = container; 
            _salesViewModel = salesViewModel;
            _eventagger = eventaggr;
            _eventagger.SubscribeOnPublishedThread(this);
            _container = container;
            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
        }

        public Task HandleAsync(LogInEvent message, CancellationToken cancellationToken)
        {
            var s = ActivateItemAsync(_salesViewModel);
            return s;
            
        }
    }
}
