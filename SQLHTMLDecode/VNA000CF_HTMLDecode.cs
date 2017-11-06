using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using SQLHTMLDecode;
using System.Web;


public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(
        IsDeterministic = true,
        IsPrecise = true,
        DataAccess = DataAccessKind.None,
        SystemDataAccess = SystemDataAccessKind.None)]
    [return: SqlFacet(MaxSize = 4000)]
    public static SqlString VNA000CF_HTMLDecode([SqlFacet(MaxSize = 4000)] SqlString input)
    {
        if (input.IsNull)
            return null;
       // return HttpUtility.HtmlDecode(input.Value);
        return WebUtility.HtmlDecode(input.Value);
    }
}
