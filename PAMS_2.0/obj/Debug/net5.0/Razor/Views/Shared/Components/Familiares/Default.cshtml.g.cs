#pragma checksum "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09b5ea64e171ada4900b42e8fc8ed18d8eeeb2f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Familiares_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Familiares/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\_ViewImports.cshtml"
using PAMS_2._0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\_ViewImports.cshtml"
using PAMS_2._0.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09b5ea64e171ada4900b42e8fc8ed18d8eeeb2f9", @"/Views/Shared/Components/Familiares/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d8d08a831ded566fdc0b83fb791db516ae218de", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Familiares_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PAMS_2._0.Data.ViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success d-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Fam", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
   ViewData["Title"] = "Lista de Pacientes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container\">\n");
#nullable restore
#line 6 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
     if (TempData["message"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert alert-warning alert-dismissible fade show \" role=\"alert\">\n    ");
#nullable restore
#line 9 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
Write(TempData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <button type=\"button\" class=\"close\" date-dismiss=\"alert\" aria-label=\"Close\">\n        <span aria-hidden=\"true\">&times;</span>\n    </button>\n</div>");
#nullable restore
#line 13 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\n    <div class=\"row\">\n        <div class=\"col-sm-6\">\n            <h4>Familiares</h4>\n        </div>\n        <div class=\"col-sm-6\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09b5ea64e171ada4900b42e8fc8ed18d8eeeb2f97162", async() => {
                WriteLiteral("Agregar Familiar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
                                                 WriteLiteral(Model.paciente.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n    </div>\n    <div class=\"row\">\n\n");
#nullable restore
#line 25 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
         if (Model.listaFamiliares.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table table-bordered table-striped\">\n    <thead>\n        <tr>\n            <td>");
#nullable restore
#line 30 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
           Write(Html.DisplayNameFor(m => m.listaFamiliares.First().id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 31 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
           Write(Html.DisplayNameFor(m => m.listaFamiliares.First().nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 32 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
           Write(Html.DisplayNameFor(m => m.listaFamiliares.First().nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 33 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
           Write(Html.DisplayNameFor(m => m.listaFamiliares.First().apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 34 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
           Write(Html.DisplayNameFor(m => m.listaFamiliares.First().parentesco));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 35 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
           Write(Html.DisplayNameFor(m => m.listaFamiliares.First().ocupacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>Acciones</td>\n        </tr>\n    </thead>\n    <tbody>\n\n");
#nullable restore
#line 41 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
         foreach (var item in Model.listaFamiliares)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>");
#nullable restore
#line 44 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
   Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 45 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
   Write(item.nacimiento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 46 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
   Write(item.nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 47 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
   Write(item.apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 48 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
   Write(item.parentesco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 49 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
   Write(item.ocupacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09b5ea64e171ada4900b42e8fc8ed18d8eeeb2f913956", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
                                                    WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09b5ea64e171ada4900b42e8fc8ed18d8eeeb2f916442", async() => {
                WriteLiteral("\n            <input type=\"submit\" value=\"Eliminar\" class=\"btn btn-danger\" />\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
                                                                       WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </td>\n\n</tr>\n");
#nullable restore
#line 58 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table> ");
#nullable restore
#line 60 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
         }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p>No existen Registros.</p>");
#nullable restore
#line 62 "C:\Users\eri_a\source\repos\PAMS2.0-Tabulacionv2\PAMS_2.0\Views\Shared\Components\Familiares\Default.cshtml"
                              }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n</div>\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PAMS_2._0.Data.ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
