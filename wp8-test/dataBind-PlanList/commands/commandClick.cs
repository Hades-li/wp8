using dataBind_PlanList.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dataBind_PlanList.commands
{
    public class commandClick:ICommand
    {
        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            ((plan)parameter).addDate();
        }
    }
}
