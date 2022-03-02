#pragma checksum "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a96d52c7a9c204a2af94d451a08cf89981fe4cea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_List), @"mvc.1.0.view", @"/Views/Employee/List.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\Form\Form\Views\_ViewImports.cshtml"
using Form;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\Form\Form\Views\_ViewImports.cshtml"
using Form.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a96d52c7a9c204a2af94d451a08cf89981fe4cea", @"/Views/Employee/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ad1894cf2a5a996cc341bfb6a6502f1eb2ef4df", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Form.Models.Employees>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
  
    ViewData["Title"] = "Listeleme";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!DOCTYPE html>

<table id=""tblListele"">
    <thead>
        <tr>
            <th>Id:</th>
            <th>İsim:</th>
            <th>Soyisim:</th>
            <th>İşe Başlangıç Tarihi:</th>
            <th>Adres:</th>
            <th>Ülke:</th>
            <th>Şehir:</th>
            <th>Cinsiyet:</th>
            <th> Güncelle</th>
            <th>Sil</th>
        </tr>

    </thead>

    <tbody>
");
#nullable restore
#line 28 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.EmployeeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.EmployeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.EmployeeSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.DateOfStartingJob);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.EmployeeAdress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.CountryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.CityId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
               Write(item.GenderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               \r\n                <td><a class=\"btn btn-info\"  onclick=\"btnUpdateKayit(this.id)\"");
            BeginWriteAttribute("id", " id = \"", 1033, "\"", 1056, 1);
#nullable restore
#line 40 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
WriteAttributeValue("", 1040, item.EmployeeId, 1040, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Güncelle</a></td>\r\n                <td><a class=\"btn btn-warning btnEmployeeSil\" data-id=\"");
#nullable restore
#line 41 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
                                                                  Write(item.EmployeeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"> Sil</a>  </td>\r\n\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\HP\source\repos\Form\Form\Views\Employee\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>


<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.21/css/jquery.dataTables.min.css"" integrity=""sha512-1k7mWiTNoyx2XtmI96o+hdjP8nn0f3Z2N4oF/9ZZRgijyV4omsKOXEnqL1gKQNPy2MTSP9rIEWGcH/CInulptA=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer"" />
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.21/css/dataTables.bootstrap4.min.css"" integrity=""sha512-PT0RvABaDhDQugEbpNMwgYBCnGCiTZMh9yOzUsJHDgl/dMhD9yjHAwoumnUk3JydV3QTcIkNDuN40CJxik5+WQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer"" />
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.21/js/jquery.dataTables.min.js""  integrity=""sha512-BkpSL20WETFylMrcirBahHfSnY++H2O1W+UnEEO4yNIl+jI2+zowyoGJpbtk6bx97fBXf++WJHSSK2MV4ghPcg=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer"" defer></script>
  
<script>

    $(document).ready(function () {
        $(""#tblListele"").DataTable();
    });
   


    $(function () {
        ");
            WriteLiteral(@"$(""#tblListele"").on(""click"", "".btnEmployeeSil"", function () {
            if (confirm(""Çalışanı silmek istediğinizden emin misiniz?"")) {
                var id = $(this).data(""id"");
                var btn = $(this);
                $.ajax({
                    type: ""GET"",
                    url: ""/Employee/Sil/"" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }

        });

    });

    function btnUpdateKayit(id) {
        window.location.href = ""/Employee/Update?id="" + id;
    };

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Form.Models.Employees>> Html { get; private set; }
    }
}
#pragma warning restore 1591
