using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortApp.TagHelpers
{
    /*
     * Поскольку класс tag-хелпера в своем названии имеет несколько слов, которые начинаются с большой буквы - SortHeaderTagHelper, 
     * то в имени соотвествующего тега все части названия будут разделяться дефисом: <sort-header> (суффикс TagHelper при этом отбрасывается).
     * 
     * Через атрибуты тега sort-header мы можем передать значения для соотвествующих одноименных свойств класса SortHeaderTagHelper.
            <sort-header action="Index" up="@Model.SortViewModel.Up"
                    current="@Model.SortViewModel.Current" property="@Model.SortViewModel.CompanySort">
                Компания
            </sort-header>
     */
    public class SortHeaderTagHelper : TagHelper
    {
        // Данные в tag-хелпер будут передаваться извне через набор свойств:
        // В идеале все эти свойства можно выделить в отдельную модель, но я не буду этого делать, чтобы не множить чрезмерно классы.
        // Теперь нам надо передать данные для этого хелпера. Для этого определим в папке Models новый класс SortViewModel
        public SortState Property { get; set; } // значение текущего свойства, для которого создается тег
        public SortState Current { get; set; }  // значение активного свойства, выбранного для сортировки
        public string Action { get; set; }  // действие контроллера, на которое создается ссылка
        public bool Up { get; set; }    // сортировка по возрастанию или убыванию

        // Для создания url-адреса и тега-ссылки по методу контроллера потребуется объект IUrlHelperFactory. 
        // И мы можем получить его в конструкторе, так как он встраивается по умолчанию через встроенный в ASP.NET Core механизм dependency injection.
        private IUrlHelperFactory urlHelperFactory;
        public SortHeaderTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        // Через тот же механизм внедрения зависимостей мы можем через атрибут получить контекст представления ViewContext, в котором будет вызываться хелпер
        [ViewContext][HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "a";
            string url = urlHelper.Action(Action, new { sortOrder = Property });
            output.Attributes.SetAttribute("href", url);
            // если текущее свойство имеет значение CurrentSort
            if (Current == Property)
            {
                TagBuilder tag = new TagBuilder("i");
                tag.AddCssClass("glyphicon");

                if (Up == true)   // если сортировка по возрастанию
                    tag.AddCssClass("glyphicon-chevron-up");
                else   // если сортировка по убыванию
                    tag.AddCssClass("glyphicon-chevron-down");

                output.PostContent.AppendHtml(tag);
            }
        }
    }
}
