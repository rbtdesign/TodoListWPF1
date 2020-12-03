/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TODODesktopUI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using TODODesktopUI.Services;
using TODODesktopUI.ViewsModels;

namespace TODODesktopUI.Helpers
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {

            try
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

                
                SimpleIoc.Default.Register<ITodosService, TodosService>();

                SimpleIoc.Default.Register<MyTodosViewModel>();

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        public MyTodosViewModel MyTodosVm => ServiceLocator.Current.GetInstance<MyTodosViewModel>();

    }
}
