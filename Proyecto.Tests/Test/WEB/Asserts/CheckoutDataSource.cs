using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Test.WEB.Asserts
{
    public class CheckoutDataSource
    {
        private const string nameJson = "DataCheckout.json";

        /// <summary>
        /// Metodo que nos permite obtener la información del mensaje desde el archivo Json y nos permite separar los casos de prueba
        /// <returns></returns>
        public static IEnumerable<TestCaseData> MessageInformation()
        {
            var listaMessageInfo = JsonHelper.LoadListFromJson<CheckoutInfo>(nameJson);

            foreach (var item in listaMessageInfo)
            {
                yield return new TestCaseData(item.Name, item.Lastname, item.zip);
            }
        }
    }
}
