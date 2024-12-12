using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_PAYMENT_LOG_BO
{
    public static class ErrorMsg
    {
        public static readonly ReadOnlyDictionary<string, KeyValuePair<string, string>> ErrorMsgs = new ReadOnlyDictionary<string, KeyValuePair<string, string>>(
       new Dictionary<string, KeyValuePair<string, string>>(){

             {"applno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0001","application number can't be blank.") },
             {"transrefno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0002","transref number can't be blank.")},          
             
             {"reqbankaccountno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0003","request bank account number can't be blank.")},        
             {"reqbankbenaccname",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0004","request bank account name can't be blank.")},
             {"reqbankifsc",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0005","request bank IFSC code can't be blank.")},

             {"respresponsemsg",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0006","response message can't be blank.")},             
             {"respuniquerefno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0007","response unique ref number can't be blank.")},
             {"respbeneacctno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0008","response bene account number can't be blank.")},
             {"respbeneifsc",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0009","response IFSC Code  can't be blank.")},
             {"resppaymtamt",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0010","response payment amount can't be blank.")},
             {"resppaymtdate",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0011","response payment date can't be blank.")},
             {"respaddltranref",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0012","response addl trans ref number can't be blank.")},
             {"resppaymtstatus",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0013","response payment status can't be blank.")},
             {"resppaymterrcode",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0014","response payment code can't be blank.")},
             {"resppaymterrdesc",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0015","response payment  description can't be blank.")},
             {"respupirefno",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0016","response upi  ref number can't be blank.")},
             {"respbankacctname",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0017","response bank account name can't be blank.")},
             {"respenablematch",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0018","response enable match  can't be blank.")},
             {"resprequestnamematchperc",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0019","response Request name match perc can't be blank.")},
             {"respresponsenamematchperc",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0020","response name match perc can't be blank.")},

             {"svcprovname",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0021","service provider name can't be blank.")},

             //{"respnamematch",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0030","response name match can't be blank.")},
             //{"response",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0006","response  can't be blank.")},
            // {"respstatuscode",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0006","response status code  can't be blank.")},
             //{"reqbankaccountno_length",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0019","request bank account number cannot be less than 8 digit.")},
             //{"respbeneacctno_length",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0020","response bank account number cannot be less than 8 digit.")},         
            //{"AmtNumeric",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0021","amount must be Numeric.")},
            //{"AmountLength",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0022","invalid length of amount.")},       
            //{"specialChar",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0023","name can not contain special characters.")},
            //{"reqbankifsc_Invalid",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0024","requestor bank IFSC code is invalid.")},
            //{"respbeneifsc_Invalid",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0025","response bank IFSCcode is invalid.")},          
            //{"dtFormat",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0026","date is not in correct format(DD-MMM-YYYY).")},
              //{"pgname",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0003","PGname can't be blank.")},
             //{"pgcredential",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0004","PGcredential can't be blank.")},
             //{"apiencryptionalgo",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0005","API_Encryption_Algo can't be blank.")},
             //{"apiiv",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0006","API_IV can't be blank.")},
             //{"apikey",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0007","API_Key can't be blank.")},                 
             //{"requestdata",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0008","Request data can't be blank.")},
             //{"responsedata",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0009","response data can't be blank.")},
            // {"respaeskey",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0015","response AES key can't be blank.")},
             //{"respapplicationuserid",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0016","response Application Userid can't be blank.")},
             //{"respepsclientcode",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0017-API-E-BPV-00017","response Client code can't be blank.")},
             //{"reqpan",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0034","Request pan number can't be blank.")},
             //{"reqvpa",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0035","Request vpa can't be blank.")},
            //{"PANInvalid",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0038","PAN Number is not valid.")},
           //{"PANLength",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0039","Invalid length of  PAN.")},
            //{"respbenename",new KeyValuePair<string, string>("MFFDSUP-API-E-BPV-0019","response bene Name can't be blank.")},


       });

    }
}
