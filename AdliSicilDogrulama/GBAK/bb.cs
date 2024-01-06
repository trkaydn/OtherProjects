//GBAKFramework 3.0.0
namespace GBAK
{
    using System;
    using System.Linq;
    using System.Data.Linq;
	using System.Collections.Generic;
    public partial class bb : IDisposable
    {
        public int? CommandTimeout { get; set; }
        public EXEC Exec { get; private set; }
        DataContext d = new DataContext(GBAK.Engine.PublicVariable.Connection_bb);
        public bb()
        {
            d.CommandTimeout = (int)(CommandTimeout == null || CommandTimeout < 30 ? 30 : CommandTimeout);
            d.ExecuteCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            Exec = new EXEC(ref d);
        }
        public void Dispose()
        {
            d.Dispose();
        }
    }
}


//using System.Data.Linq
//system.Configuration