using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp6
{
    class NullConditional
    {
        public Action PurchaseCallBack { get; set; }

        public void PurchaseProduct()
        {

            //Without null conditional
            //Store purchase is done, notify caller
            if (PurchaseCallBack != null)
            {
                //Notify the StoreManager we're done with purchase
                //so it can update its UI
                PurchaseCallBack();
            }

            //With null conditional - call if its not null
            PurchaseCallBack?.Invoke();


            string customerInfo = "Jane Doe";

            //Length or null - storing to var
            int? length = customerInfo?.Length;


            //Direct use
            if (customerInfo?.Length > 0)
            {
                Console.WriteLine($"Length:{customerInfo.Length}");
            }

            //**** Also see Program.Main() for switch ******

            List<string> collection = null;
            var item = collection?[0];
        }
    }
}
