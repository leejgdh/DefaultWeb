using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DHWeb.Helpers.TagHelpers{

    /// <summary>
    /// <see cref="ITagHelper"/> implementation targeting &lt;span&gt; elements with an <c>asp-description-for</c> attribute.
    /// Input 태그에 Placeholder로 DIsplay Attribute의 Description이나, Name을 넣어준다.
    /// </summary>
    [HtmlTargetElement("label", Attributes = AttributeName)]
    public class LabelTagHelper : TagHelper
    {
        private const string AttributeName = "asp-for";

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(AttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            //if radio label has class  .form-check-label

            var class_attr = output.Attributes.FirstOrDefault(e => e.Name == "class");

            if(class_attr != null){
                
                string class_value = class_attr.Value.ToString();

                if(class_value.Contains("form-check-label")){
                    
                }

            }



            if (For.Metadata.IsRequired)
            {
                output.PostContent.AppendHtml(" <span class=\"text-danger\">*</span>");
            }
        }

    }

}