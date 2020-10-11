using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OborudDataBase.ViewModels;
using static OborudDataBase.ViewModels.MyViewModel;

namespace OborudDataBase//.Utils
{
    public class DynamicDataTemplateSelector : DataTemplateSelector
    {

        public DataTemplate ComboboxTemplate

        { get; set; }


        public DataTemplate TextBlocTemplate

        { get; set; }
      

        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {

            
         



          
            IncludeTab w = item as IncludeTab;


            if (w != null)

            {

               // Console.WriteLine(w.val.ToString());
                   
                    if (w.val == "int")
                    {

                        return TextBlocTemplate;
                        //  return TextBlockTemplate;

                    }
                    else if (w.val == "enum")
                    {

                        //  return ComboBoxTemplate;
                        return ComboboxTemplate;

                    }
                    else if (w.val == "str")
                    {

                        return TextBlocTemplate;
                        //return TextBoxTemplate;

                    }

                    else
                    {
                        return base.SelectTemplate(item, container);
                    }

                }
            
            return base.SelectTemplate(item, container);


        }
    }
}