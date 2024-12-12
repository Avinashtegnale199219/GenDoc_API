using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_GEN_DOCS_BO
{
    public class ShortUrlReqBO
    {
        public ShortUrlReqBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string long_url { get; set; }
        public string Source { get; set; }
    }

    public class ShortUrlResBO
    {
        public string Status { get; set; }
        public string Msg { get; set; }
        public string ShortURL { get; set; }
    }
}
