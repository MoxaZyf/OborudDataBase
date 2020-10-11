using OborudDataBase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static OborudDataBase.ViewModels.MyViewModel;

namespace OborudDataBase.ViewModels
{
    public class CRUDVM
    {
        private readonly DB _db = new DB();

        public string TypeVarName { get; set; }
        public int Location_id { get; set; }
        public int Oborud_id { get; set; }
        public string Location { get; set; }
        public string Parameters { get; set; }
        public string Oborud { get; set; }
        public ObservableCollection<IncludeTab> includeTabs { get; set; }
     //   public ObservableCollection<ParameterVM> Parameters { get; }
        public class CRUDData
        {
            public int Location_id { get; set; }

            public int Oborud_id { get; set; }


            public static CRUDVM From(Location location, Oboruds oboruds, IncludeTab includeTab)
            {

                return new CRUDVM
                {
                    
                    Location = location.Name,
                    Location_id = oboruds.Location.Id,
                    Oborud = oboruds.Name,
                    Oborud_id = oboruds.Id,
                  //  Parameters = includeTab.Name
                  
                };



            }



        }


        public Oboruds order;
        private readonly Oboruds _oboruds;
        private readonly Location locations;
        private readonly Parameters parameters;
        public void UpdateModel()
        {


            List<Location> list = new List<Model.Location>();
           // Location_id = _db.locations.Where(x => x.Name == Location).Select(x => x.Id).First();
            list.Add(_db.locations.Where(x => x.Name == Location).SingleOrDefault());
            foreach (var item in list)
            {

                //var oborud = _db.Oboruds.Where(o => o.Name == Location) ?? new Oboruds { Location = _db.locations.Find(locations) });
                //oborud.Name = Location;
                //_db.Oboruds.Add(oborud);
                //  _db.SaveChanges();

                _db.Oboruds.Add(new Oboruds
                {
                    Location = item,// _db.locations.Find(locations),
                    Name = Location,

                });
            }
           
             Oborud_id = _db.Oboruds.Where(o => o.Name == Location).Select(o => o.Id).FirstOrDefault();
            foreach (var i in includeTabs)
            {
                var nameParam = _db.Parameters.Where(p => p.Name == i.Name.ToString()).Select(p => p.Id).First();  //idПараметра
               

                _db.ParamValues.Add(new ParamValue
                {
                     Parameters =  _db.Parameters.Find(nameParam),
                     // Num_value = i.NumValue,
                      Str_value = i.StrValue,
                      Oboruds = _db.Oboruds.Find(Oborud_id),
                   //    TypesVariant = _db.TypesVariants.Find()



            });
                

               // MessageBox.Show(nameParam.ToString());
            }



             _db.SaveChanges();

            MessageBox.Show ("Save");

   

            
        }


    }


}

