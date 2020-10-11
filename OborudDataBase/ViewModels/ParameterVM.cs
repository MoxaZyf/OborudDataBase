using OborudDataBase.Model;
using OborudDataBase.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OborudDataBase.ViewModels
{
    public class ParameterVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Parameters _parameter;
        private readonly Oboruds _oborud;

        public string Name => _parameter.Name;
        public ParamTypes Type => _parameter.ParamTypes;

        public List<string> Variant { get; }
        private string _strValue;
        private string _numValue;
        public string StrValue { get => _strValue; set { _strValue = value; this.PropertyChanged(this, new PropertyChangedEventArgs("StrValue")); } }
        public string NumValue { get => _numValue; set { _numValue = value; this.PropertyChanged(this, new PropertyChangedEventArgs("NumValue")); } }





            }
}
