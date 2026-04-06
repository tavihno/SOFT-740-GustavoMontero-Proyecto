using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Tests.Test.WEB.Asserts
{
    public class CheckoutInfo
    {
        private string name;
        private string lastname;
        private string ZIP;
        

        public CheckoutInfo(string name, string lastname, string ZIP)
        {
            this.name = name;
            this.lastname = lastname;
            this.ZIP = ZIP;
           
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Lastname
        {
            get => lastname;
            set => lastname = value;
        }
       

        public string zip   
        {
            get => ZIP;
            set => ZIP = value;
        }

       
    }
}
