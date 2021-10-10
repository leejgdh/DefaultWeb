using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DHWeb.Helpers.TagHelpers
{
    /// <summary>
    /// <see cref="ITagHelper"/> implementation targeting &lt;span&gt; elements with an <c>asp-description-for</c> attribute.
    /// </summary>
    [HtmlTargetElement("input", Attributes = AttributeName)]
    public class InputRadioTagHelper : TagHelper
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

                if(type_name == "radio"){
                    
                    var id_attr = output.Attributes.FirstOrDefault(e => e.Name == "id");

                    if(id_attr != null){
                        output.Attributes.Remove(id_attr);
                    }

                    var value_attr = output.Attributes.FirstOrDefault(e => e.Name == "value");

                    if(value_attr != null){

                        //id를 다시 세팅한다.

                        output.Attributes.Add("id",$"{For.Name}_{value_attr.Value}");
                    }


                }
            }
        }
    }

     /// <summary>
    /// <see cref="ITagHelper"/> implementation targeting &lt;span&gt; elements with an <c>asp-description-for</c> attribute.
    /// </summary>
    [HtmlTargetElement("input", Attributes = AttributeName)]
    public class InputCheckboxTagHelper : TagHelper
    {
        private const string AttributeName = "asp-item";

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
                
                if(type_name == "radio"){
                    
                    // var id_attr = output.Attributes.FirstOrDefault(e => e.Name == "id");

                    // if(id_attr != null){
                    //     output.Attributes.Remove(id_attr);
                    // }

                }
                else if(type_name == "checkbox"){

                }
            }
        }
    }
}