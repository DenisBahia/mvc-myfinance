#pragma checksum "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b13054b8cd06a3d3217e1290942a3897755b20a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Conta_Index), @"mvc.1.0.view", @"/Views/Conta/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Conta/Index.cshtml", typeof(AspNetCore.Views_Conta_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b13054b8cd06a3d3217e1290942a3897755b20a", @"/Views/Conta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Conta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(43, 245, true);
            WriteLiteral("\r\n<h2>Minhas Contas</h2>\r\n\r\n<table class=\"table table-bordered\">\r\n\r\n    <thead>\r\n        <tr>\r\n            <td>#</td>\r\n            <td>id</td>\r\n            <td>Nome</td>\r\n            <td>Saldo</td>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n\r\n");
            EndContext();
#line 21 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml"
          
            foreach (var item in (List<ContaModel>)ViewBag.ListaContas)
            {

#line default
#line hidden
            BeginContext(388, 116, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <button type=\"button\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 504, "\"", 542, 3);
            WriteAttributeValue("", 514, "Excluir(", 514, 8, true);
#line 26 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml"
WriteAttributeValue("", 522, item.id.ToString(), 522, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 541, ")", 541, 1, true);
            EndWriteAttribute();
            BeginContext(543, 70, true);
            WriteLiteral(">Excluir</button>\r\n                    </td>\r\n                    <td>");
            EndContext();
            BeginContext(614, 18, false);
#line 28 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml"
                   Write(item.id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(632, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(664, 20, false);
#line 29 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml"
                   Write(item.Nome.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(684, 34, true);
            WriteLiteral("</td>\r\n                    <td>R$ ");
            EndContext();
            BeginContext(719, 21, false);
#line 30 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml"
                      Write(item.Saldo.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(740, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 32 "C:\Users\denis.bahia\Desktop\Curso WEB\mvc-myfinance\WebApplication1\Views\Conta\Index.cshtml"
            }
        

#line default
#line hidden
            BeginContext(796, 363, true);
            WriteLiteral(@"
    </tbody>

</table>

<button type=""button"" class=""btn btn-block btn-primary"" onclick=""CriarConta()"">Criar Conta</button>

<script language=""javascript"">
    function CriarConta() {
        window.location.href = ""../Conta/CriarConta""
    }

    function Excluir(id) {
        window.location.href = ""../Conta/ExcluirConta/"" + id
    }
</script>");
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