using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_GEN_DOCS_BO
{
    public class Validation_Gen_Doc
    {
        public async Task<List<Error>> isValidate(Gen_DocsBO gen_DocsBO)
        {

            List<Error> ER = new List<Error>();
            Error sb = new Error();
            try
            {
                if (gen_DocsBO != null)
                {
                    List<UDTValidation_GenDoc> objVBO = new List<UDTValidation_GenDoc>();
                    bool IsValid = true;

                    if (string.IsNullOrEmpty(gen_DocsBO.applno.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "applno", Evalue = gen_DocsBO.applno, ErrorMessage = ErrorMsg_Gen_Doc.ErrorMsgs["applno"].Value });
                        sb.field = "applno";
                        sb.code = ErrorMsg_Gen_Doc.ErrorMsgs["applno"].Key;
                        sb.message = ErrorMsg_Gen_Doc.ErrorMsgs["applno"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "applno", Evalue = gen_DocsBO.applno, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(gen_DocsBO.transrefno.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "transrefno", Evalue = gen_DocsBO.transrefno, ErrorMessage = ErrorMsg_Gen_Doc.ErrorMsgs["transrefno"].Value });
                        sb.field = "transrefno";
                        sb.code = ErrorMsg_Gen_Doc.ErrorMsgs["transrefno"].Key;
                        sb.message = ErrorMsg_Gen_Doc.ErrorMsgs["transrefno"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "transrefno", Evalue = gen_DocsBO.transrefno, ErrorMessage = "Success" });
                    }

                    if (string.IsNullOrEmpty(gen_DocsBO.doctype.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "doctype", Evalue = gen_DocsBO.doctype, ErrorMessage = ErrorMsg_Gen_Doc.ErrorMsgs["doctype"].Value });
                        sb.field = "doctype";
                        sb.code = ErrorMsg_Gen_Doc.ErrorMsgs["doctype"].Key;
                        sb.message = ErrorMsg_Gen_Doc.ErrorMsgs["doctype"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "doctype", Evalue = gen_DocsBO.doctype, ErrorMessage = "Success" });
                    }

                    if(string.IsNullOrEmpty(gen_DocsBO.docsubtype.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "docsubtype", Evalue = gen_DocsBO.docsubtype, ErrorMessage = ErrorMsg_Gen_Doc.ErrorMsgs["docsubtype"].Value });
                        sb.field = "docsubtype";
                        sb.code = ErrorMsg_Gen_Doc.ErrorMsgs["docsubtype"].Key;
                        sb.message = ErrorMsg_Gen_Doc.ErrorMsgs["docsubtype"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_GenDoc() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "docsubtype", Evalue = gen_DocsBO.docsubtype, ErrorMessage = "Success" });
                    }

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
