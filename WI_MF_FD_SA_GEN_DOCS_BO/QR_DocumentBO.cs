using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_GEN_DOCS_BO
{
    public class QR_DocumentBO
    {
        public QR_DocumentBO()
        {
        }
        private string _DocType;
        private string _SubDocType;
        private string _Version;
        private string _RefferenceNumber;
        private string _QR_Code;
        private string _QR_CodeImage;
        private string _QR_DocLocation;
        private string _QR_DMSPath;
        private string _QR_DMSId;
        private string _QR_FilePath;
        private string _QR_Text;
        private string _QR_HttpFullPath;
        private string _QR_UNCPath;
        private string _QR_UNCFile;
        private DateTime _CreatedDate;
        private string _CreatedIP;
        private string _SessionId;
        private string _FormCode;
        private string _IsVerified;
        private byte[] _QRImage;
        private string _Active;
        private string _QR_Text_SecretCode;
        private string _QR_DMSStatus;
        public string DocType
        {
            get
            {
                return _DocType;
            }

            set
            {
                _DocType = value;
            }
        }

        public string SubDocType
        {
            get
            {
                return _SubDocType;
            }

            set
            {
                _SubDocType = value;
            }
        }

        public string Version
        {
            get
            {
                return _Version;
            }

            set
            {
                _Version = value;
            }
        }

        public string RefferenceNumber
        {
            get
            {
                return _RefferenceNumber;
            }

            set
            {
                _RefferenceNumber = value;
            }
        }

        public string QR_Code
        {
            get
            {
                return _QR_Code;
            }

            set
            {
                _QR_Code = value;
            }
        }

        public string QR_DocLocation
        {
            get
            {
                return _QR_DocLocation;
            }

            set
            {
                _QR_DocLocation = value;
            }
        }

        public string QR_DMSPath
        {
            get
            {
                return _QR_DMSPath;
            }

            set
            {
                _QR_DMSPath = value;
            }
        }

        public string QR_DMSId
        {
            get
            {
                return _QR_DMSId;
            }

            set
            {
                _QR_DMSId = value;
            }
        }

        public string QR_FilePath
        {
            get
            {
                return _QR_FilePath;
            }

            set
            {
                _QR_FilePath = value;
            }
        }

        public string QR_Text
        {
            get
            {
                return _QR_Text;
            }

            set
            {
                _QR_Text = value;
            }
        }

        public string QR_HttpFullPath
        {
            get
            {
                return _QR_HttpFullPath;
            }

            set
            {
                _QR_HttpFullPath = value;
            }
        }

        public string QR_UNCPath
        {
            get
            {
                return _QR_UNCPath;
            }

            set
            {
                _QR_UNCPath = value;
            }
        }

        public string QR_UNCFile
        {
            get
            {
                return _QR_UNCFile;
            }

            set
            {
                _QR_UNCFile = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }

            set
            {
                _CreatedDate = value;
            }
        }

        public string CreatedIP
        {
            get
            {
                return _CreatedIP;
            }

            set
            {
                _CreatedIP = value;
            }
        }

        public string SessionId
        {
            get
            {
                return _SessionId;
            }

            set
            {
                _SessionId = value;
            }
        }

        public string FormCode
        {
            get
            {
                return _FormCode;
            }

            set
            {
                _FormCode = value;
            }
        }

        public string IsVerified
        {
            get
            {
                return _IsVerified;
            }

            set
            {
                _IsVerified = value;
            }
        }

        public byte[] QRImage
        {
            get
            {
                return _QRImage;
            }

            set
            {
                _QRImage = value;
            }
        }

        public string Active
        {
            get
            {
                return _Active;
            }

            set
            {
                _Active = value;
            }
        }
        public string QR_Text_SecretCode
        {
            get
            {
                return _QR_Text_SecretCode;
            }

            set
            {
                _QR_Text_SecretCode = value;
            }
        }

        public string QR_DMSStatus
        {
            get
            {
                return _QR_DMSStatus;
            }

            set
            {
                _QR_DMSStatus = value;
            }
        }

        public string QR_CodeImage
        {
            get
            {
                return _QR_CodeImage;
            }

            set
            {
                _QR_CodeImage = value;
            }
        }
    }
}
