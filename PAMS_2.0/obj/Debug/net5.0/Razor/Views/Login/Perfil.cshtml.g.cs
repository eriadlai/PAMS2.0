#pragma checksum "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1792b4fbbd42fd4b6cfe7a531a42fc0db2a71d00657dd7e964379345af1dcbc5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Perfil), @"mvc.1.0.view", @"/Views/Login/Perfil.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\_ViewImports.cshtml"
using PAMS_2._0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\_ViewImports.cshtml"
using PAMS_2._0.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1792b4fbbd42fd4b6cfe7a531a42fc0db2a71d00657dd7e964379345af1dcbc5", @"/Views/Login/Perfil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"372e73335376a794b71a43fded252a26fea26b1c1a6800447bca9b307a9478e0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_Perfil : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PAMS_2._0.Data.ViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
  
    ViewData["Title"] = "Perfil";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-deck\">\r\n    <div class=\"card border-info\">\r\n        <div class=\"card-body\">\r\n            <img class=\"card-img\"");
            BeginWriteAttribute("src", " src=\'", 252, "\'", 335, 1);
#nullable restore
#line 10 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
WriteAttributeValue("", 258, Url.Action("GetImage", "Usuario", new {item=Model.listaUsuarios.First().id}), 258, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""100"" height=""400"" alt=""Card image"">

        </div>
    </div>
    <div class=""card border-info"">
        <div class=""card-body"">
            <h5 class=""card-title font-weight-bold"">Informacion del Perfil</h5>

            <div class=""col-md-6"">
                <p class=""card-title font-weight-bold"">");
#nullable restore
#line 19 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                                  Write(Html.DisplayNameFor(m => m.listaUsuarios.First().email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 20 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                Write(Model.listaUsuarios.First().email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"card-title font-weight-bold\">");
#nullable restore
#line 23 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                                  Write(Html.DisplayNameFor(m => m.listaUsuarios.First().rol));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 24 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                Write(Model.listaUsuarios.First().rol);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"card-title font-weight-bold\">");
#nullable restore
#line 27 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                                  Write(Html.DisplayNameFor(m => m.listaUsuarios.First().nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 28 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                Write(Model.listaUsuarios.First().nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"card-title font-weight-bold\">");
#nullable restore
#line 31 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                                  Write(Html.DisplayNameFor(m => m.listaUsuarios.First().apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 32 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                Write(Model.listaUsuarios.First().apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"card-title font-weight-bold\">");
#nullable restore
#line 35 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                                  Write(Html.DisplayNameFor(m => m.listaUsuarios.First().nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 36 "E:\ProgramacionSSD\GithubRepositories\PAMS2.0\PAMS_2.0\Views\Login\Perfil.cshtml"
                                Write(Model.listaUsuarios.First().nacimiento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n   \r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PAMS_2._0.Data.ViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
