using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_FD_SA_ONBOARDING_BO
{

    public static class ErrorMsg_SavePaymentLog
    {
        public static readonly ReadOnlyDictionary<string, KeyValuePair<string, string>> ErrorMsgs = new ReadOnlyDictionary<string, KeyValuePair<string, string>>(
       new Dictionary<string, KeyValuePair<string, string>>(){

             //Save Payment log details
             {"apievent",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0001","Event mode can't be blank.")},
             {"paymentgatewayid",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0002","Payment gateway id can't be blank.")},
             {"merchantcode",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0003","Merchant code can't be blank.")},
             {"txndate",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0004","Txn date can't be blank.")},
             {"txndateformat",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0005","Txn date format is invalid.")},
             {"amountnumeric",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0006","Amount must be Numeric.")},
             {"amountblnk",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0007","Amount can't be blank.")},
             {"status",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0008","Status can't be blank.")},
             {"response",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0009","Response can't be blank.")},
             {"paytype",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0010","Paytype can't be blank.")},
             {"applno",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0011","Applno can't be blank.")},
             {"transrefno",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0012","Trans ref no can't be blank.")},
             {"bankcode",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0013","Bank code can't be blank.")},
      });
    }
}
