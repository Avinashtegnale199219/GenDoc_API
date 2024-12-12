using WI_MF_FD_SA_GEN_DOCS_BO;
using WI_MF_FD_SA_GEN_DOCS_DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using WI_MF_FD_SA_GEN_DOCS.Services;
using Microsoft.AspNetCore.Hosting;
using SelectPdf;
using System.ComponentModel.Design;
using PQScan.BarcodeCreator;



namespace WI_MF_FD_SA_GEN_DOCS.Controllers
{
    [Route("api/gendoc")]
    [ApiController]
    public class GenDocController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly GEN_DOCS_DAL _GEN_DOCS_DAL;

        public GenDocController(IConfiguration configuration)
        {
            _config = configuration;
            _GEN_DOCS_DAL = new GEN_DOCS_DAL(_config);
        }


        [HttpPost]
        public async Task<IActionResult> POST([FromBody] Gen_DocsBO gen_Docs)
        {
            string pwd = string.Empty;

            bool res = false;

            Validation_Gen_Doc _validation = new Validation_Gen_Doc();
            //var error = await _validation.isValidate(gen_Docs);

            //if (error.Count > 0)
            //{

            //}
            // else
            // {
            if (!string.IsNullOrEmpty(gen_Docs.doctype))
            {
                gen_Docs.doctype = gen_Docs.doctype.ToUpper();

            }
            if (!string.IsNullOrEmpty(gen_Docs.docsubtype))
            {
                gen_Docs.docsubtype = gen_Docs.docsubtype.ToUpper();

            }


            pwd = string.Empty;
            try
            {

                string QR_Code = _config["QR_SCANNER_URL"] + "?App=" + gen_Docs.applno + "&DocType=FDA";
                //Start:--->> QR image generation logic
                string strDocRefNoENCR = QR_Code;
                //-------------------------------------------//Short URL  Start----------------------------
                string shortURL = string.Empty;
                string appKey = "_" + Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                string longurl = _config["SHORT_GEN_URL"] + "?" + appKey;
                ShortUrlReqBO objShortUrlReqBO = new ShortUrlReqBO();
                objShortUrlReqBO.long_url = longurl;
                objShortUrlReqBO.Source = "FD EP RP V5";

                string _req_URL = _config["ShortUrlAPI"].ToString();
                string _req_JSON = JsonConvert.SerializeObject(objShortUrlReqBO);
                string APIRequestTimeout = _config["APIRequestTimeout"].ToString();
                string res1 = APICall.Get_APIResponse(_req_URL, _req_JSON, APIRequestTimeout);
                if (!string.IsNullOrEmpty(res1))
                {
                    ShortUrlResBO objresponse = JsonConvert.DeserializeObject<ShortUrlResBO>(res1);
                    if (objresponse.Status.ToUpper() == "1")
                    {
                        DataTable dtQRtext = _GEN_DOCS_DAL.GET_QRText("FD", "FDA");
                        string SaltKey = dtQRtext.Rows[0]["SaltKey"].ToString();
                        string EncryptKey = dtQRtext.Rows[0]["EncryptionVector"].ToString();
                        shortURL = objresponse.ShortURL;
                        bool success = _GEN_DOCS_DAL.SaveShortUrl(SaltKey, EncryptKey, longurl, objresponse.ShortURL, appKey, _req_URL,gen_Docs);
                    }
                    else
                    {
                        shortURL = longurl;
                        bool success = _GEN_DOCS_DAL.SaveShortUrl("", "", longurl, longurl, appKey, _req_URL, gen_Docs);
                    }
                }
                else
                {
                    shortURL = longurl;
                    bool success = _GEN_DOCS_DAL.SaveShortUrl("", "", longurl, longurl, appKey, _req_URL, gen_Docs);
                }

                //End:-- End Short Url Logic

                Byte[] QRbytes = null;
                byte[] QRImage = null;
                if (!string.IsNullOrEmpty(shortURL))
                {
                    PQScan.BarcodeCreator.Barcode barcode = new PQScan.BarcodeCreator.Barcode();
                    barcode.BarType = PQScan.BarcodeCreator.BarCodeType.QRCode;
                    barcode.Data = shortURL;
                    barcode.Width = 100;
                    barcode.Height = 100;
                    barcode.QRCodeECL = ErrorCorrectionLevelMode.L;
                    barcode.PictureFormat = ImageFormat.Jpeg;
                    Bitmap QRbtm = barcode.CreateBarcode();

                    using (MemoryStream stream = new MemoryStream())
                    {
                        QRbtm.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        QRbytes = stream.ToArray();
                    }
                    QRImage = QRbytes;
                    string b64img = Convert.ToBase64String(QRbytes);
                    //imgQRCODE.ImageUrl = "data:image/jpeg;base64," + b64img;
                }
                else
                {
                    PQScan.BarcodeCreator.Barcode barcode = new PQScan.BarcodeCreator.Barcode();
                    barcode.BarType = PQScan.BarcodeCreator.BarCodeType.QRCode;
                    barcode.Data = strDocRefNoENCR;
                    barcode.Width = 100;
                    barcode.Height = 100;
                    barcode.QRCodeECL = ErrorCorrectionLevelMode.L;
                    barcode.PictureFormat = ImageFormat.Jpeg;
                    Bitmap QRbtm = barcode.CreateBarcode();

                    using (MemoryStream stream = new MemoryStream())
                    {
                        QRbtm.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        QRbytes = stream.ToArray();
                    }
                    QRImage = QRbytes;
                    string b64img = Convert.ToBase64String(QRbytes);
                    //dvQRCODE.InnerHtml = "<img width=\"100px\" height=\"80px\" class='img-responsive' runat=\"server\" id=\"imgIcon\" src='data:image/jpeg;base64," + QRImage + "' />";
                    //imgQRCODE.ImageUrl = "data:image/jpeg;base64," + b64img;
                }




                if (QRImage != null)
                {
                    string imgbase64QR = "";
                    GEN_DOCS_DAL objDAL = new GEN_DOCS_DAL(_config);
                    DataTable dt = objDAL.GetAckDetail(gen_Docs.applno);
                    string html = string.Empty;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string _Path = Path.Combine(Directory.GetCurrentDirectory(), "Public", "Html", "Payment_Successful.html");
                        html = System.IO.File.ReadAllText(_Path);
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PDF_PWD"])))
                            pwd = dt.Rows[0]["PDF_PWD"].ToString();
                        html = html.Replace("{imgbytes}", "data:image/jpeg;base64," + imgbase64QR);
                        html = html.Replace("{name}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Full_Name"])) ? " " : dt.Rows[0]["Full_Name"].ToString().Trim());
                        html = html.Replace("{add1}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Address1"])) ? " " : dt.Rows[0]["Address1"].ToString().Trim());
                        html = html.Replace("{add2}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Address2"])) ? " " : dt.Rows[0]["Address2"].ToString().Trim());
                        html = html.Replace("{city}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["City"])) ? " " : dt.Rows[0]["City"].ToString().Trim());
                        html = html.Replace("{state}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["State"])) ? " " : dt.Rows[0]["State"].ToString().Trim());
                        html = html.Replace("{pincode}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Pincode"])) ? " " : dt.Rows[0]["Pincode"].ToString().Trim());
                        html = html.Replace("{phon_no}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PhoneNo"])) ? " " : dt.Rows[0]["PhoneNo"].ToString().Trim());
                        html = html.Replace("{JointlySecondHolder}", "");
                        html = html.Replace("{JointlyThirdHolder}", "");
                        html = html.Replace("{NomineeRelationship}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Nominee_Relation"])) ? " " : dt.Rows[0]["Nominee_Relation"].ToString().Trim());
                        html = html.Replace("{Payableto}", "First Holder");
                        html = html.Replace("{theSumOfRupees}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Amount"])) ? " " : dt.Rows[0]["Amount"].ToString().Trim());
                        html = html.Replace("{FDApplicationNumber}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["APPLNO"])) ? " " : dt.Rows[0]["APPLNO"].ToString().Trim());
                        html = html.Replace("{FDApplicationDate}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplDate"])) ? " " : dt.Rows[0]["ApplDate"].ToString().Trim());
                        html = html.Replace("{DepositDate}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplDate"])) ? " " : dt.Rows[0]["ApplDate"].ToString().Trim());
                        html = html.Replace("{DepositAmount}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Amount"])) ? " " : dt.Rows[0]["Amount"].ToString().Trim());
                        html = html.Replace("{Period}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Period"])) ? " " : dt.Rows[0]["Period"].ToString().Trim());
                        html = html.Replace("{RateofInterest}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Int_Rate"])) ? " " : dt.Rows[0]["Int_Rate"].ToString().Trim());
                        html = html.Replace("{MaturityDate}", " ");
                        html = html.Replace("{MaturityAmount}", " ");
                        html = html.Replace("{PANoftheFirstDepositor}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PAN"])) ? " " : dt.Rows[0]["PAN"].ToString().Trim());
                        html = html.Replace("{BankAccountNumber}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BankAcc_No"])) ? " " : dt.Rows[0]["BankAcc_No"].ToString().Trim());
                        html = html.Replace("{NameoftheBankandBranch}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Bank_Name"])) ? " " : dt.Rows[0]["Bank_Name"].ToString().Trim());
                        html = html.Replace("{MICR_IFSC_Code}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MICRCode"])) ? " " : dt.Rows[0]["MICRCode"].ToString().Trim());
                        html = html.Replace("{DateofBirthoftheFirstDepositor}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DOB"])) ? " " : dt.Rows[0]["DOB"].ToString().Trim());
                        html = html.Replace("{Category}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Category"])) ? " " : dt.Rows[0]["Category"].ToString().Trim());
                        html = html.Replace("{Scheme}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Scheme"])) ? " " : dt.Rows[0]["Scheme"].ToString().Trim());
                        html = html.Replace("{PaymentMode}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Payment_Mode"])) ? " " : dt.Rows[0]["Payment_Mode"].ToString().Trim());
                        //html = html.Replace("{BrokerCode}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BROKER_CODE"])) ? " " : dt.Rows[0]["BROKER_CODE"].ToString().Trim());
                        html = html.Replace("{EmailID}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Emailid"])) ? " " : dt.Rows[0]["Emailid"].ToString().Trim());
                        html = html.Replace("{InterestPaymentFrequency}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Interest_Freq"])) ? " " : dt.Rows[0]["Interest_Freq"].ToString().Trim());
                        html = html.Replace("{Form15GH}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Form15GH"])) ? " " : dt.Rows[0]["Form15GH"].ToString().Trim());
                        html = html.Replace("{MaturityInstruction}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MaturityInstruction"])) ? " " : dt.Rows[0]["MaturityInstruction"].ToString().Trim());
                        html = html.Replace("{LoanLien}", "");
                        html = html.Replace("{KYCVerifiedby}", " ");
                        html = html.Replace("{TxnDate}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplDate"])) ? " " : dt.Rows[0]["ApplDate"].ToString().Trim());
                        html = html.Replace("{CIN}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CIN"])) ? " " : dt.Rows[0]["CIN"].ToString().Trim());
                        html = html.Replace("{MahindraAddress}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MF_ADDRESS"])) ? " " : dt.Rows[0]["MF_ADDRESS"].ToString().Trim());
                        html = html.Replace("{TransactionType}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Payment_Mode"])) ? " " : dt.Rows[0]["Payment_Mode"].ToString().Trim());
                        //html = html.Replace("{TransactionId}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TransactionId"])) ? " " : dt.Rows[0]["TransactionId"].ToString().Trim());
                        html = html.Replace("{NomineeName}", String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Nominee_Name"])) ? " " : dt.Rows[0]["Nominee_Name"].ToString().Trim());
                        if (_config["Environment"].ToString() == "UAT")
                        {
                            html = html.Replace("{dis}", "display:block;");
                        }
                        else
                        {
                            html = html.Replace("{dis}", "display:none;");
                        }
                        string PDF_Path = _config["docpath"] + gen_Docs.applno + "_" + DateTime.Now.Ticks.ToString() + ".pdf";
                        byte[] pdf = ConvertHTMLToPDF(html, string.IsNullOrEmpty(pwd) ? "" : pwd);

                        System.IO.File.WriteAllBytes(PDF_Path, pdf.ToArray());

                        FileResult fileResult = new FileContentResult(pdf, "application/pdf");
                        if (gen_Docs.doctype.ToUpper() == "FD" && gen_Docs.docsubtype.ToUpper() == "ACK")
                        {
                            fileResult.FileDownloadName = gen_Docs.applno + "_FD_Advice.pdf";
                        }
                        else
                        {
                            fileResult.FileDownloadName = gen_Docs.applno + "_FD_EFDR.pdf";
                        }

                        //return fileResult;
                        if (pdf != null)
                        {
                            //return Ok("data:application/pdf; base64," + Convert.ToBase64String(pdf));
                            return Ok(new { Status = 1, msg = "SUCCESS", DocBinary = "data:application/pdf; base64," + Convert.ToBase64String(pdf) });
                        }

                    }
                    else
                    {
                        return null;
                    }
                    return Ok(new { Status = 1, msg = "Success", DocBinary = "data:application/pdf; base64," });
                }
                else
                {
                    return Ok(new { Status = 0, msg = "Failure", DocBinary = "data:application/pdf; base64," });
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static byte[] ConvertHTMLToPDF(string html, string pwd = null)
        {
                        // byte[] byteACKpdf = null;
                        // HtmlToPdf converter = new HtmlToPdf();

                        // // create a new pdf document converting an url 
                        // PdfDocument doc = converter.ConvertHtmlString(html);

                        // string imgFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Mahindra-Finance-water-mark.png");

                        // byteACKpdf = doc.Save();

                        // // close pdf document 
                        // doc.Close();

                        // return byteACKpdf;


            //rapid code
            // byte[] pdf = null;
            // HtmlToPdf converter = new HtmlToPdf();
            // // create a new pdf document converting an url 
            // // if (!string.IsNullOrEmpty(pwd))
            // // {
            // //    converter.Options.SecurityOptions.OwnerPassword = "Fddoc1234";
            // //    converter.Options.SecurityOptions.UserPassword = pwd;
            // // }
            // SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html);
            // pdf = doc.Save();
            // // close pdf document 
            // doc.Close();
            // return pdf;

            //google code
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;


        }

    }
}
