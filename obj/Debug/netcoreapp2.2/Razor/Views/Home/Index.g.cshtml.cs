#pragma checksum "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f9ed6a0e683fa5ed5e512f998fb6e53f644de10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/_ViewImports.cshtml"
using routine_explorer;

#line default
#line hidden
#line 2 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/_ViewImports.cshtml"
using routine_explorer.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f9ed6a0e683fa5ed5e512f998fb6e53f644de10", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31d673d5cd1c900d3fa50cc6ed4da690fdb67f0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<routine_explorer.Models.RoutineFileUploaderStatus>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentsRoutine", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Routines", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TeachersRoutine", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "SWE Routine";

#line default
#line hidden
            BeginContext(120, 390, true);
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>


<div class=""row center"">
    <div class=""col-md-8"">
        
        <div class=""text-center"">
            <h5 class=""display-5"">Students Routine</h5>
        </div>
        <hr/>
        ");
            EndContext();
            BeginContext(510, 1927, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f9ed6a0e683fa5ed5e512f998fb6e53f644de106043", async() => {
                BeginContext(634, 131, true);
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <select class=\"form-control custom-select\" id=\"selected\" name=\"selected\">\r\n");
                EndContext();
#line 23 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
                BeginContext(838, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(858, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f9ed6a0e683fa5ed5e512f998fb6e53f644de106879", async() => {
                    BeginContext(882, 54, false);
#line 25 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                                      Write(Html.DisplayFor(modelItem => item.NameOfFilesUploaded));

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 25 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                      WriteLiteral(item.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(945, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 26 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                    }

#line default
#line hidden
                BeginContext(970, 1460, true);
                WriteLiteral(@"                </select>
            </div>

            <div class=""form-group"">
               <label for=""subject1"">Subject Code 1</label>
                <input type=""text"" class=""form-control"" id=""subject1"" name=""subject1"" placeholder=""SWEXXXA"">
            </div>

            <div class=""form-group"">
               <label for=""subject2"">Subject Code 2</label>
                <input type=""text"" class=""form-control"" id=""subject2"" name=""subject2"" placeholder=""SWEXXXA"">
            </div>

            <div class=""form-group"">
               <label for=""subject3"">Subject Code 3</label>
                <input type=""text"" class=""form-control"" id=""subject3"" name=""subject3"" placeholder=""SWEXXXA"">
            </div>

            <div class=""form-group"">
               <label for=""subject4"">Subject Code 4</label>
                <input type=""text"" class=""form-control"" id=""subject4"" name=""subject4"" placeholder=""SWEXXXA"">
            </div>

            <div class=""form-group"">
             ");
                WriteLiteral(@"  <label for=""subject5"">Subject Code 5</label>
                <input type=""text"" class=""form-control"" id=""subject5"" name=""subject5"" placeholder=""SWEXXXA"">
            </div>
            
            <div class=""col-md-12 text-center"">
                    <div class=""form-group"">
                    <input type=""submit"" value=""Check Routine"" class=""btn btn-outline-primary"" />  
            </div>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2437, 175, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"col-md-4\">\r\n        <div class=\"text-center\">\r\n            <h5 class=\"display-5\">Teachers Routine</h5>\r\n        </div>\r\n        <hr/>\r\n        ");
            EndContext();
            BeginContext(2612, 998, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f9ed6a0e683fa5ed5e512f998fb6e53f644de1012731", async() => {
                BeginContext(2736, 131, true);
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <select class=\"form-control custom-select\" id=\"selected\" name=\"selected\">\r\n");
                EndContext();
#line 71 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
                BeginContext(2940, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(2960, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f9ed6a0e683fa5ed5e512f998fb6e53f644de1013571", async() => {
                    BeginContext(2984, 54, false);
#line 73 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                                      Write(Html.DisplayFor(modelItem => item.NameOfFilesUploaded));

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 73 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                      WriteLiteral(item.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3047, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 74 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
                    }

#line default
#line hidden
                BeginContext(3072, 531, true);
                WriteLiteral(@"                </select>
            </div>

            <div class=""form-group"">
               <label for=""teacherInitial"">Teacher Initial</label>
                <input type=""text"" class=""form-control"" id=""teacherInitial"" name=""teacherInitial"" placeholder=""DTB"">
            </div>
            
            <div class=""col-md-12 text-center"">
                    <div class=""form-group"">
                    <input type=""submit"" value=""Check Routine"" class=""btn btn-outline-primary"" />  
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3610, 28, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3656, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 94 "/home/shunjid/Documents/web/dotnet/routine-explorer/Views/Home/Index.cshtml"
      await Html.RenderPartialAsync("_ValidationAutoComplete");

#line default
#line hidden
            }
            );
            BeginContext(3727, 12, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<routine_explorer.Models.RoutineFileUploaderStatus>> Html { get; private set; }
    }
}
#pragma warning restore 1591
