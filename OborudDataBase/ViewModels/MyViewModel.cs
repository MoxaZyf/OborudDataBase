using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Effects;
using OborudDataBase.Model;
using OborudDataBase.Utils;
using System.Data.Entity;
using System.Windows.Input;
using System.Xml;
using System.Windows.Navigation;

namespace OborudDataBase.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly DB _db = new DB();

        public RelayCommand SaveCommand { get; set; }

        private string _oborud;
        public string Oborud
        {
            get { return _oborud; }
            set
            {
                _oborud = value;
                OnPropertyChanged("Oborud");
            }
        }

        private ObservableCollection<IncludeTab> _group;
        public ObservableCollection<IncludeTab> Books
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged("Books");
            }
        }

       
        private string _Location;
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                OnPropertyChanged("Location");
            }
        }
        public int LocationId { get; set; }

        private readonly CRUDVM order = new CRUDVM();
        public CRUDVM Order
        {
            get { return order; }

        }


        private ObservableCollection<IncludeTab> _studentList;
        public ObservableCollection<IncludeTab> StudentList
        {
            get
            {
                return _studentList;
            }
            set
            {
                if (_studentList != value)
                {
                    _studentList = value;
                    OnPropertyChanged("StudentList");
                }
            }
        }
        private string _strValue;
        private string _numValue;
        public string StrValue { get => _strValue; set { _strValue = value; this.PropertyChanged(this, new PropertyChangedEventArgs("StrValue")); } }
        public class IncludeTab : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public string image { get; set; }
            public string Name { get; set; }
            public string val { get; set; }

            private readonly TypesVariant _variant;
            private readonly ParamTypes _paramTypes;
            private readonly ParameterVM _paramVM;

           
            //public string Nam { get; set; }
            private TypesVariant _Namet;
            private bool _isSelected;

            public TypesVariant Namet
            {
                get => _Namet;
                set
                {
                    _Namet = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Namet"));
                    StrValue = _Namet.Name;
                   
                }
            }

       


            public List<TypesVariant> TypeVariants { get; set; }
            public List<ParamTypes> ParamTypes { get; set; }

            private readonly Parameters _parameter;
            private readonly Oboruds _oborud;

   
            private string _strValue;
            private string _numValue;
            public string StrValue { get => _strValue; set { _strValue = value; this.PropertyChanged(this, new PropertyChangedEventArgs("StrValue")); } }
            public string NumValue { get => _numValue; set { _numValue = value; this.PropertyChanged(this, new PropertyChangedEventArgs("NumValue")); } }
        

        }

        public ICollectionView Customers { get; private set; }
       
        private ICollectionView _GroupedCustomers;
        public ICollectionView GroupedCustomers
        {
            get { return _GroupedCustomers; }
            set
            {
                _GroupedCustomers = value;
                OnPropertyChanged(nameof(GroupedCustomers));
            }
        }


        public MyViewModel()
        {


            _group = new ObservableCollection<IncludeTab>();

            _studentList = new ObservableCollection<IncludeTab>();

            Customers = CollectionViewSource.GetDefaultView(_group);

            GroupedCustomers = new ListCollectionView(_group);
            GroupedCustomers.GroupDescriptions.Add(new PropertyGroupDescription("image"));

            var players = _db.Parameters.Include(p => p.TypesVariants).Include(p => p.GroupType).Include(p => p.ParamTypes).AsEnumerable().ToList();
            foreach (Parameters p in players)
            {

                _group.Add(new IncludeTab
                {
                    image = p.GroupType.Name,
                    Name = p.Name,
                    TypeVariants = p.TypesVariants.ToList().Where(x => x.Parameters.Id == p.Id).ToList(),

                    val = p.ParamTypes.Type,



                });

                _studentList.Add(new IncludeTab
                {
                    image = p.GroupType.Name,
                    Name = p.Name,
                    TypeVariants = p.TypesVariants.ToList().Where(x => x.Parameters.Id == p.Id).ToList(),

                    val = p.ParamTypes.Type,


                });




            }

           

        }

        private CRUDVM _selectedOrder;
        public CRUDVM DynamicResource
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(DynamicResource));
            }
        }

        public void Save()
        {



           if (_group != null)
            {
                MessageBox.Show("s");

               
            }

            _selectedOrder = new CRUDVM
            {
               
                 Location = Location,
                Oborud = Order.Oborud,
                includeTabs = _group,


            };


            if (DynamicResource != null)
            {
                DynamicResource.UpdateModel();
                _db.SaveChanges();
            }
        }

        public void Save(object parameter)
        {


            //Bez1Entities db;
            //db = new Bez1Entities();
            ////Одна запись в бд
            //var sm = GetSm + 1;
            //DateTime ndt = Convert.ToDateTime(DateNar);


            ////  CONVERT(SMALLDATETIME, CONVERT(DATETIME, '" + ndt + "'))

            //db.UMRK_SM.Add(new UMRK_SM
            //{

            //    Date_nar = ndt,
            //    Num_sm = Smena,
            //    Prod = SmenaLong,
            //    Nar_vid = FIO.FIO.ToString(),

            //});

            // db.SaveChanges();
        }


        private DataTable employeeDataTable;

        public DataTable EmployeeDataTable
        {
            get { return employeeDataTable; }
            set
            {
                employeeDataTable = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("EmployeeDataTable"));
            }
        }

        private ObservableCollection<GroupType> _records = null;
        private string image;
        internal string val;

        //public ObservableCollection<GroupType> Records
        //{
        //    get { return _records; }
        //    set
        //    {
        //        if (_records != value)
        //        {
        //            _records = value;

        //            if (this.PropertyChanged != null)
        //            {
        //                this.PropertyChanged(this, new PropertyChangedEventArgs("Records"));
        //            }
        //        }
        //    }
        //}

        public string Name { get; set; }


        private void LoadData()
        {
            // this populates Records using your LINQ query
            var query = _db.GroupTypes.ToList();
        }


        #region Events

        #endregion

        #region Command
        #endregion

        #region Private Methods
        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }
}