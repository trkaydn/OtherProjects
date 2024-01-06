//GBAKFramework 3.0.0
using System.Collections.Generic;
namespace GBAK
{
    public partial class bb
    {
        public partial class SP
        {
            public class service_belgedogrulama_get
            {
                public IList<service_belgedogrulama_get_rtn> rtn { get; set; }
            }
            public class service_belgedogrulama_get_rtn
            {
                public int? id { get; set; }
                public string barkodno { get; set; }
                public int? pid { get; set; }
                public string tckimlikno { get; set; }

            }
        }
    }

}
