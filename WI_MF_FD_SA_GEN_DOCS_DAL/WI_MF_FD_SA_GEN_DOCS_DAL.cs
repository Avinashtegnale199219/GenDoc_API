using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper;
using Microsoft.Extensions.Configuration;
using WI_MF_FD_SA_GEN_DOCS_BO;

namespace WI_MF_FD_SA_GEN_DOCS_DAL
{
    public class GEN_DOCS_DAL
    {
        private readonly string _conn = string.Empty;
        public GEN_DOCS_DAL(IConfiguration cofing)
        {
            _conn = cofing["ConnectionStrings:CONN_FD"];
        }

        public DataTable GetAckDetail(string ApplicationNo)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ApplicationNo", ApplicationNo);

                ////HARD CODE VALUE SET
                dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "Usp_FD_SA_GetFDAdviseDtlsForMailer", param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            { 
                throw ex;
                 }
        }

        public DataTable GET_QRText(string DocType, string SubDocType)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@DocType", DocType);
                sqlParam[1] = new SqlParameter("@SubDocType", SubDocType);
                DataSet ds = SqlHelper.ExecuteDataSet(_conn, CommandType.StoredProcedure, "Usp_FD_RI_QR_GET_QRDocument_Mst_V6", sqlParam);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                //return ex.Message;
                throw ex;
            }
        }

        public bool SaveShortUrl(string SaltKey, string EncryptKey, string QrLongUrl, string QrShortUrl, string appKey, string Short_API_URL,Gen_DocsBO gen_DocsBO)
        {

            SqlParameter[] sqlparam = new SqlParameter[18];
            try
            {
                sqlparam[0] = new SqlParameter("@App_No", gen_DocsBO.applno);
                sqlparam[1] = new SqlParameter("@Sys_Ref_No", "");
                sqlparam[2] = new SqlParameter("@QR_Gen_URL", QrLongUrl);
                sqlparam[3] = new SqlParameter("@Short_Gen_URL", QrShortUrl);
                sqlparam[4] = new SqlParameter("@DocType", "FD");
                sqlparam[5] = new SqlParameter("@SubDocType", "FDA");
                sqlparam[6] = new SqlParameter("@Version", "1.0");
                sqlparam[7] = new SqlParameter("@SaltKey", SaltKey);
                sqlparam[8] = new SqlParameter("@EncryptionVector", EncryptKey);
                sqlparam[9] = new SqlParameter("@CreatedBy", "");
                sqlparam[10] = new SqlParameter("@CreatedByUName", "");
                sqlparam[11] = new SqlParameter("@CreatedType","");
                sqlparam[12] = new SqlParameter("@CreatedIP", "");
                sqlparam[13] = new SqlParameter("@SessionID", "");
                sqlparam[14] = new SqlParameter("@Form_Code", "");
                sqlparam[15] = new SqlParameter("@Source", "FD_REGULAR");
                sqlparam[16] = new SqlParameter("@Short_URL_Key", appKey);
                sqlparam[17] = new SqlParameter("@Short_API_URL", Short_API_URL);
                int res = SqlHelper.ExecuteNonQuery(_conn, CommandType.StoredProcedure, "Usp_FD_RI_QR_Short_URL_Dtls_V6", sqlparam);
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                sqlparam = null;
            }
        }

        //public async Task<string> SavePaymentLog(PaymentLog payment)
        //{
        //    try
        //    {
        //        int res = 0;
        //        SqlParameter[] param = new SqlParameter[13];
        //        param[0] = new SqlParameter("@event", payment.apievent.ToUpper());
        //        //param[1] = new SqlParameter("@paymentmode", payment.paymentmode);
        //        param[1] = new SqlParameter("@merchantcode", payment.merchantcode);
        //        param[2] = new SqlParameter("@txndate", payment.txndate);
        //        param[3] = new SqlParameter("@amount",Convert.ToDecimal(payment.amount));
        //        param[4] = new SqlParameter("@bankcode", payment.bankcode);
        //        param[5] = new SqlParameter("@customername", payment.customername);
        //        param[6] = new SqlParameter("@card", payment.card);
        //        param[7] = new SqlParameter("@status", payment.status.ToLower());
        //        param[8] = new SqlParameter("@response", string.IsNullOrEmpty(payment.response) ? (object)DBNull.Value : payment.response);
        //        param[9] = new SqlParameter("@paytype", string.IsNullOrEmpty(payment.paytype) ? (object)DBNull.Value : payment.paytype.Trim());
        //        param[10] = new SqlParameter("@applno", string.IsNullOrEmpty(payment.applno) ? (object)DBNull.Value : payment.applno.Trim());
        //        param[11] = new SqlParameter("@transrefno", payment.transrefno);
        //        param[12] = new SqlParameter("@paymentgatewayid", payment.paymentgatewayid.ToLower());

        //        DataTable dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "usp_FD_SA_Insert_Payment_Log", param);

        //        if (dt.Rows.Count > 0 && Convert.ToString(dt.Rows[0]["msg"]) == "success")
        //        {
        //            return "SUCCESS";
        //        }
        //        else
        //        {
        //            return Convert.ToString(dt.Rows[0]["msg"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
