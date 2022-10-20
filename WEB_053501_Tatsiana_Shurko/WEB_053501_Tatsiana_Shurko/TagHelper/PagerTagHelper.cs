namespace WEB_053501_Tatsiana_Shurko.TagHelper
{

    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.AspNetCore.Routing;
    using System.ComponentModel;
    using WEB_053501_Tatsiana_Shurko.Models;

    public class PagerTagHelper: TagHelper {
        [HtmlAttributeName("controller")]
        public string ControllerName { get; set; }

        [HtmlAttributeName("action")]
        public string ActionName { get; set; }

        [HtmlAttributeName("page-current")]
        public int CurrentPage { get; set; }

        [HtmlAttributeName("page-total")]
        public int TotalPage { get; set; }

        [HtmlAttributeName("group-id")]
        public int GroupId { get; set; }

        private ListViewModel<Book> _list;
        private LinkGenerator _linkGenerator;

        public PagerTagHelper(LinkGenerator linkGenerator) {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "li";
            if (ListViewModel<Book>.CurrentPage == CurrentPage) {
                output.Attributes.SetAttribute("class", "page-item active");
            } else {
                output.Attributes.SetAttribute("class", "page-item");
            }

            string listContent = $"<a class=\"page-link\" href=\"/Catalog/Page_{CurrentPage}/{GroupId}\">" + CurrentPage + "</a>";
            output.Content.SetHtmlContent(listContent);
        }
    }
}
