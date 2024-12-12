using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_PAYMENT_LOG_BO
{
    public class RTGSPaymentLogBO
    {
        public RTGSPaymentLogBO()
        {
        }

             public string applno { get; set; }
             public string transrefno { get; set; }
            public decimal amount { get; set; }
            public string txndate { get; set; }
             public string status { get; set; }
            public string  response { get; set; }



    }
}
