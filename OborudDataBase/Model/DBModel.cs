using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OborudDataBase.Model;

namespace OborudDataBase.Model
{
    //Оборудование
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Oboruds> oboruds { get; set; }
    }

    //Оборудование
    public class Oboruds

    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ParamValue> ParamValues { get; set; }
        //   public List<Oborud_Group> oborud_Groups { get; set; }
        //  public List<GroupType> GroupTypes { get; set; }
        public List<Oborud_TypeVal> Oborud_TypeVals { get; set; }
        public ICollection<GroupType> ParameterGroups { get; set; }
        public Location Location { get; set; }
        public DateTime? DateVvoda { get; set; }  //
        public string DescriptionOborud { get; set; }
    }


    public class Parameters
    {
        public int Id { get; set; }
        //это свойство будет использоваться как внешний ключ
        //  public int GroupType_id { get; set; }
        public GroupType GroupType { get; set; }
        public ParamTypes ParamTypes { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<TypesVariant> TypesVariants { get; set; }
        public List<ParamValue> ParamValues { get; set; }

    }

    public class GroupType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public List<Parameters> parameters { get; set; }
        // public List<Oborud_Group> oborud_Groups { get; set; }
        public ICollection<Oboruds> Oboruds { get; set; }
    }

    public class TypesVariant //для выбора вариантов типов 
    {
        public int Id { get; set; }
        // public int ParamId { get; set; }
        public Parameters Parameters { get; set; }
        public int Variant_num { get; set; }
        public string Name { get; set; }
        public List<ParamValue> ParamValues { get; set; }
    }

    public class ParamValue
    {
        public int Id { get; set; }
        // public int ParamId { get; set; }
        public Parameters Parameters { get; set; }

        //  public int Oborud_id { get; set; }
        public Oboruds Oboruds { get; set; }

        // public int typeValueTypesVariant_id { get; set; }
        public TypesVariant TypesVariant { get; set; }
        public int Num_value { get; set; }
        public string Str_value { get; set; }

    }
    public class Oborud_TypeVal
    {
        public int Id { get; set; }
        //public int Oborud_id { get; set; }
        public Oboruds Oboruds { get; set; }

        //  public int TypeVal_id { get; set; }
        public ParamValue ParamValues { get; set; }
    }



    //public class Oborud_Group
    //{
    //    public int Id { get; set; }

    //    public Oboruds Oboruds { get; set; }

    //    public GroupType GroupType { get; set; }

    //}
    public class ParamTypes
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Parameters> parameters { get; set; }
    }

}