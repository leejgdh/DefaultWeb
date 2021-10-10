using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DHWeb.Helpers.TagHelpers
{
/// <summary>
    /// <see cref="ITagHelper"/> implementation targeting &lt;span&gt; elements with an <c>asp-description-for</c> attribute.
    /// Input 태그에 Placeholder로 DIsplay Attribute의 Description이나, Name을 넣어준다.
    /// </summary>
    [HtmlTargetElement("input", Attributes = AttributeName)]
    public class InputPlaceholderTagHelper : TagHelper
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


            var input_type = output.Attributes.FirstOrDefault( e => e.Name == "type");

            if(input_type != null){
                
                string type_name = input_type.Value.ToString();

                if(type_name == "text"){
                            
                    if (!output.IsContentModified)
                    {
                        if (!string.IsNullOrEmpty(For.Metadata.Description))
                        {
                            output.Attributes.SetAttribute("placeholder", For.Metadata.Description);

                        }
                        else if (!string.IsNullOrEmpty(For.Metadata.Name))
                        {

                            output.Attributes.SetAttribute("placeholder", For.Metadata.DisplayName);
                        }
                        
                    }

                }
            }

        }
    }
}