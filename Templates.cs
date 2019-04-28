using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo
{
    public class Templates
    {
        public struct Book
        {
            public static readonly ID ID = new ID("{C2A6224D-1583-4048-AEF3-AA56D89C6F0D}");
            public struct Fields
            {
                public const string Title = "{6D247B52-3C0C-42EA-B0CE-FEBCEFB1DD5A}";
                public const string Teaser = "{FF4A0AC9-E411-491F-A095-1D4D8470C4FE}";
                public const string Description = "{1E71F31B-470B-4167-AD34-93B883A50408}";
                public const string CoverImage = "{E3833D68-60BC-416A-A6C9-7B1BEF68B03B}";
                public const string ISBN = "{A9610078-7688-4FBF-840E-29FFBEAD060D}";
                public const string NumberOfPages = "{3DC66B6E-CBD5-4969-8F7A-3BC87C5C9F83}";
                public const string Language = "{0024A4D1-585D-4DCE-84A2-88ACD9E7A6DB}";
                public const string PublishedDate = "{003ED8EA-363B-4E71-9D0F-67EFD9372F01}";
                public const string Author = "{1DBB8FD3-1F1C-4ADD-B852-3D80654B96DC}";
                public const string Type = "{152610B1-E1A0-4724-B919-C6B1CD39249A}";
            }
        }

        public struct HeroBanner
        {
            public static readonly ID ID = new ID("{38CF0EAA-1F9B-4931-8C83-2D776FB0C164}");
            public struct Fields
            {
                public const string TopTitle = "{C1FA0A37-EFB4-4687-A420-2AEE73336B30}";
                public const string Title = "{BFC3A2F2-02DE-4147-BBED-68E66054A706}";
                public const string SubTitle = "{5AE84CFF-5D0E-4CD2-B3CC-A96BC3BA0276}";
                public const string CallToActionLink = "{6CDD5C2F-11A5-41B1-AEF2-7ADE623EB8CE}";
                public const string BackgroundImage = "{66349327-E9A5-4441-9E51-A5AD182504AC}";
            }
        }

        public struct CallToAction
        {
            public static readonly ID ID = new ID("{0A18B273-9B24-4C2B-AF2E-AFDA6CFD2F90}");
            public struct Fields
            {
                public const string Name = "{564D0F02-E895-4F29-A169-8959A0A46198}";
                public const string Description = "{1C167E30-AA5B-411C-8331-9500C74168B2}";
                public const string CallToActionLink = "{419F8726-B887-44AB-8034-F5DDA21DBF6E}";
                public const string BackgroundImage = "{5A2FAF8D-5DB4-459E-9810-CAAC5B03DCB9}";
            }
        }

        public struct BookRenderingParameters
        {
            public static readonly ID ID = new ID("{783F979F-5F82-44C4-8E5C-515565E91E2B}");
            public const string TemplateId = "{783F979F-5F82-44C4-8E5C-515565E91E2B}";
            public struct Fields
            {
                public const string PageSize = "{719D423C-6F98-425E-A271-148E42FDF8A6}";
                public const string BackgroundColor = "{12C38FB2-2846-40C2-AE49-40EFF2E84088}";
            }
        }
    }
}