using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_PAYMENT_LOG_BO
{
    public class ErrorMsg_RTGSLog
    {
        public static readonly ReadOnlyDictionary<string, KeyValuePair<string, string>> ErrorMsgs = new ReadOnlyDictionary<string, KeyValuePair<string, string>>(
      new Dictionary<string, KeyValuePair<string, string>>(){

            {"applno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0001","application number can't be blank.") },
             {"transrefno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0002","transref number can't be blank.")},
             {"formcode",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00027","formcode can't be blank.")},
             {"pevent",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00028","pevent can't be blank.")},
             {"requesttype",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00029","requesttype can't be blank.")},
             {"merchanttxnrefnumber",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00030","merchanttxnrefnumber can't be blank.")},
             {"bankcode",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00031","bankcode can't be blank.")},
            {"status",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00031","status can't be blank.")},
             {"ismobile",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00032","ismobile can't be blank.")},
             {"serverdomainname",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00033","serverdomainname can't be blank.")},
             {"txndate",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0034","txndate can't be blank")},
             {"txndateformat",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-0035","Please enter correct date formate")},
              {"amount",new KeyValuePair<string, string>("MFFDSUP-API-OPL-VAL-00036","Amount can't be blank.")},
      });

    }
}
