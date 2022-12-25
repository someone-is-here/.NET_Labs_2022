namespace WEB_053501_Tatsiana_Shurko.TagHelper {

    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.AspNetCore.Routing;
    using WEB_053501_Tatsiana_Shurko.Entities;
    using WEB_053501_Tatsiana_Shurko.Models;

    public class ImageTagHelper: TagHelper {
        [HtmlAttributeName("img-controller")]
        public string ControllerName { get; set; }

        [HtmlAttributeName("img-action")]
        public string ActionName { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "img";
            output.Attributes.SetAttribute("style", "width: 30px; height: 30px; border-radius: 5em; margin-left:20px;");
            output.Attributes.SetAttribute("src", $"/{ControllerName}/{ActionName}");
            output.Attributes.SetAttribute("alt", "User");
        }
    }
}
