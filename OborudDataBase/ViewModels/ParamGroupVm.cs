using OborudDataBase.Model;
using OborudDataBase.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OborudDataBase.ViewModels
{
    public class ParamGroupVm : ViewModelBase
    {

        private readonly GroupType _groupType;
        private readonly Oboruds _oborud;

        public Oboruds Oborud { get; }
        public string GroupName => _groupType.Name;
        public ObservableCollection<ParameterVM> Parameters { get; }
    }
}
