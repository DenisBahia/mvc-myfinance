#pragma checksum "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Usuario\Sucesso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22b42ca78292a390ba7562543e791c27f49381a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Sucesso), @"mvc.1.0.view", @"/Views/Usuario/Sucesso.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/Sucesso.cshtml", typeof(AspNetCore.Views_Usuario_Sucesso))]
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
#line 1 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#line 2 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22b42ca78292a390ba7562543e791c27f49381a3", @"/Views/Usuario/Sucesso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Sucesso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Usuario\Sucesso.cshtml"
   
    Layout = "../Shared/_LayoutLogin.cshtml";

#line default
#line hidden
            BeginContext(55, 268, true);
            WriteLiteral(@"
<div class=""container"" style=""background-color: rgba(239, 230, 230, .50); border-radius: 8px; padding: 10px; width: 95%;"">
    <h2>Parabéns!!! Sua conta foi criada com sucesso!!! Clique <a href=""../Usuario/Login"">aqui</a> para efetuar login no sistema.</h2>
</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
