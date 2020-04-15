using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCadwise.ViewModels
{
    class GetCashMenuViewModel : Conductor<object>
    {
        private readonly GetCashViewModel _getCashView;
        private readonly GetCertainValueViewModel _getCeratinValue;

        public GetCashMenuViewModel(SimpleContainer container)
        {
            _getCashView = container.GetInstance<GetCashViewModel>();
            _getCeratinValue = container.GetInstance<GetCertainValueViewModel>();
            ActivateItem(_getCeratinValue);
        }
        public void GetCash()
        {
            ActivateItem(_getCashView);
        }
        public void GetCertain()
        {
            ActivateItem(_getCeratinValue);
        }
    }
}
