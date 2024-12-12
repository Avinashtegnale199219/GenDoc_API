using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WI_MF_FD_SA_PAYMENT_LOG_BO;
using static WI_MF_FD_SA_PAYMENT_LOG_BO.Validate_CAMSBankPennyDropLog;

namespace MF_FD_SA_ONBOARDING_BO
{
    public class Validation_Gen_Doc
    {
        //private readonly IConfiguration _config;
        public async Task<List<Error>> isValidate(PaymentLog ObjBo)
        {

            List<Error> ER = new List<Error>();
            Error sb = new Error();
            try
            {
                if (ObjBo != null)
                {
                    List<UDTValidation_SavePaymentLog> objVBO = new List<UDTValidation_SavePaymentLog>();
                    bool IsValid = true;


                    if (string.IsNullOrEmpty(ObjBo.apievent.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "apievent", Evalue = ObjBo.apievent, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["apievent"].Value });
                        sb.field = "apievent";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["apievent"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["apievent"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "apievent", Evalue = ObjBo.apievent, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(ObjBo.paymentgatewayid.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "paymentgatewayid", Evalue = ObjBo.paymentgatewayid, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["paymentgatewayid"].Value });
                        sb.field = "paymentgatewayid";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["paymentgatewayid"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["paymentgatewayid"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "paymentgatewayid", Evalue = ObjBo.paymentgatewayid, ErrorMessage = "Success" });
                    }


                    if (string.IsNullOrEmpty(ObjBo.applno.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "applno", Evalue = ObjBo.applno, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["applno"].Value });
                        sb.field = "applno";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["applno"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["applno"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "applno", Evalue = ObjBo.applno, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(ObjBo.merchantcode.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "merchantcode", Evalue = ObjBo.merchantcode, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["merchantcode"].Value });
                        sb.field = "merchantcode";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["merchantcode"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["merchantcode"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "merchantcode", Evalue = ObjBo.merchantcode, ErrorMessage = "Success" });
                    }

                    if (!String.IsNullOrEmpty(ObjBo.txndate))
                    {
                        if (!IsValidDateFormat(ObjBo.txndate))
                        {
                            sb = new Error();
                            IsValid = false;
                            objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "txndateformat", Evalue = ObjBo.txndate, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["txndateformat"].Value });
                            sb.field = "txndateformat";
                            sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["txndateformat"].Key;
                            sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["txndateformat"].Value;
                            ER.Add(sb);

                        }
                        else
                        {
                            objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "txndate", Evalue = ObjBo.txndate, ErrorMessage = "Success" });

                        }
                    }
                    else
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "txndate", Evalue = ObjBo.txndate, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["txndate"].Value });// ErrorMsg.cpRef });
                        sb.field = "txndate";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["txndate"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["txndate"].Value;
                        ER.Add(sb);

                    }

                    //if (string.IsNullOrEmpty(ObjBo.amount))
                    //{
                    //    sb = new Error();
                    //    IsValid = false;
                    //    objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "amount", Evalue = Convert.ToString(ObjBo.amount), ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["amount"].Value });
                    //    sb.field = "amount";
                    //    sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["amount"].Key;
                    //    sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["amount"].Value;
                    //    ER.Add(sb);
                    //}
                    //else
                    //{
                    //    objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "amount", Evalue = Convert.ToString(ObjBo.amount), ErrorMessage = "Success" });
                    //}

                    var regexAmount = @"^[0-9]\d*(\.\d+)?$";
                    if (!String.IsNullOrEmpty(ObjBo.amount))
                    {
                        bool isAmountValid = Regex.IsMatch(ObjBo.amount, regexAmount);
                        if (!isAmountValid)
                        {
                            sb = new Error();
                            IsValid = false;
                            objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "amount", Evalue = ObjBo.amount, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["amountnumeric"].Value });
                            sb.field = "amount";
                            sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["amountnumeric"].Key;
                            sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["amountnumeric"].Value;
                            ER.Add(sb);
                        }
                        else
                        {
                            objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "amount", Evalue = Convert.ToString(ObjBo.amount), ErrorMessage = "Success" });
                        }
                    }
                    else
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "amount", Evalue = ObjBo.amount, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["amountblnk"].Value });
                        sb.field = "amount";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["amountblnk"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["amountblnk"].Value;
                        ER.Add(sb);
                    }

                    if (string.IsNullOrEmpty(ObjBo.status.Trim()) && ObjBo.apievent.ToLower() == "response")
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "status", Evalue = ObjBo.status, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["status"].Value });
                        sb.field = "status";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["status"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["status"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "status", Evalue = ObjBo.status, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(ObjBo.response.Trim()) && ObjBo.apievent.ToLower() == "response")
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "response", Evalue = ObjBo.response, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["response"].Value });
                        sb.field = "response";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["response"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["response"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "response", Evalue = ObjBo.response, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(ObjBo.paytype.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "paytype", Evalue = ObjBo.paytype, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["paytype"].Value });
                        sb.field = "paytype";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["paytype"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["paytype"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "paytype", Evalue = ObjBo.paytype, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(ObjBo.transrefno.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "transrefno", Evalue = ObjBo.transrefno, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["transrefno"].Value });
                        sb.field = "transrefno";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["transrefno"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["transrefno"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "transrefno", Evalue = ObjBo.transrefno, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(ObjBo.bankcode.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "bankcode", Evalue = ObjBo.bankcode, ErrorMessage = ErrorMsg_SavePaymentLog.ErrorMsgs["bankcode"].Value });
                        sb.field = "bankcode";
                        sb.code = ErrorMsg_SavePaymentLog.ErrorMsgs["bankcode"].Key;
                        sb.message = ErrorMsg_SavePaymentLog.ErrorMsgs["bankcode"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_SavePaymentLog() { RootElement = "PaymentLog", Element = "PaymentLog", Attribute = "bankcode", Evalue = ObjBo.bankcode, ErrorMessage = "Success" });
                    }

                    //ER.Add(sb);
                    return ER;
                }
                else
                    return ER;
            }
            catch (Exception ex)
            {
                return ER;

            }
        }
      
        public class UDTValidation_GenDoc
        {
            public string RootElement { get; set; }
            public string Element { get; set; }

            public string Attribute { get; set; }

            public string Evalue { get; set; }

            public string ErrorMessage { get; set; }



        }
    }
}
