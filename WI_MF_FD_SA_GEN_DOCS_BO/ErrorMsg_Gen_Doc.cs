using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_GEN_DOCS_BO
{
    public class ErrorMsg_Gen_Doc
    {
        public static readonly ReadOnlyDictionary<string, KeyValuePair<string, string>> ErrorMsgs = new ReadOnlyDictionary<string, KeyValuePair<string, string>>(
     new Dictionary<string, KeyValuePair<string, string>>(){

             //Generate Doc validation
              {"applno",new KeyValuePair<string, string>("MFFDSUP-API-GD-VAL-0001","Applno can't be blank.")},
              {"transrefno",new KeyValuePair<string, string>("MFFDSUP-API-GD-VAL-0002","Trans ref no can't be blank.")},
              {"doctype",new KeyValuePair<string, string>("MFFDSUP-API-GD-VAL-0003","Document type can't be blank.")},
              {"docsubtype",new KeyValuePair<string, string>("MFFDSUP-API-GD-VAL-0004","Document subtype can't be blank.")},

    });
    }
}
