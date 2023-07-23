using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animuSharp.Client.Internals.Utils
{
    public class Types
    {
        public static Type GetTypeForContentType(ContentType content)
        {
            switch (content)
            {
                case ContentType.fact:
                    return typeof(Data.Fact);

                case ContentType.owoify:
                    return typeof(Data.Text);

                case ContentType.password:
                    return typeof(Data.Password);

                case ContentType.quote:
                    return typeof(Data.Quote);

                case ContentType.uvuify:
                    return typeof(Data.Text);

                case ContentType.uwuify:
                    return typeof(Data.Text);

                case ContentType.Waifu:
                    return typeof(Data.Waifu);

                default:
                    return typeof(Data.Generic);
            }
        }
    }
}