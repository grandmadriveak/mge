using System.ComponentModel;

namespace Common.RestApi.Constants
{
    public class ProjectConstants
    {
    }

    public enum ProjectModule
    {
        [Description("/")]
        Identity,
        [Description("/database")]
        Database,
        [Description("/order")]
        Order,
        [Description("/shipping")]
        Shipping,
        [Description("/inventory")]
        Inventory
    }
}
