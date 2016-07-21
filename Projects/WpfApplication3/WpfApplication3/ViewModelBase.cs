using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public abstract event PropertyChangedEventHandler PropertyChanged;
        //以抽象实现接口与
        //if



        public void RaisePropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = null;
            PropertyChanged +=handler;
            if(handler!=null)
            {
                handler(this,new PropertyChangedEventArgs(propertyName));
            }


        }

    }

   
}
