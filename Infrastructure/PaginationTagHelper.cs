using Fag_el_Gamous.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Define the namespace for the Fag_el_Gamous infrastructure
namespace Fag_el_Gamous.Infrastructure
{
    // Define a custom TagHelper to generate pagination elements
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create the page links

        private IUrlHelperFactory uhf;

        // Constructor that receives an IUrlHelperFactory instance
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        // Properties to hold the view context and various pagination attributes
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public string FilterSex { get; set; }
        public string FilterHairColor { get; set; }
        public string FilterFaceBundles { get; set; }
        public string FilterAgeAtDeath { get; set; }
        public string FilterHeadDirection { get; set; }
        public string FilterDepth { get; set; }
        public string FilterEstimateStature { get; set; }
        public string FilterStructureValue { get; set; }
        public string FilterColorValue { get; set; }
        public string FilterTextileFunctionValue { get; set; }

        // Override the Process method to generate pagination elements
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            // Initialize tag builders for the navigation and unordered list elements
            TagBuilder final = new TagBuilder("nav");
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");



            // Calculate visible page range
            int startPage = Math.Max(1, PageModel.CurrentPage - 2);
            int endPage = Math.Min(PageModel.TotalPages, PageModel.CurrentPage + 2);

            // Add "Previous" button
            AddPageLink(ul, PageModel.CurrentPage - 1, "Previous", PageModel.CurrentPage == 1);

            // Add page number buttons
            for (int i = startPage; i <= endPage; i++)
            {
                AddPageLink(ul, i, i.ToString(), i == PageModel.CurrentPage);
            }

            // Add "Next" button
            AddPageLink(ul, PageModel.CurrentPage + 1, "Next", PageModel.CurrentPage == PageModel.TotalPages);

            // Append the generated HTML to the output content
            final.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(final.InnerHtml);

            // Local helper method for adding page buttons
            void AddPageLink(TagBuilder container, int pageNum, string text, bool disabled)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                if (disabled) li.AddCssClass("disabled");

                TagBuilder a = new TagBuilder("a");
                a.AddCssClass("page-link");

                // Set the URL for the anchor element based on the pagination attributes
                a.Attributes["href"] = disabled ? "#" : uh.Action(PageAction, new
                {
                    sex = FilterSex,
                    hairColor = FilterHairColor,
                    faceBundles = FilterFaceBundles,
                    ageAtDeath = FilterAgeAtDeath,
                    headDirection = FilterHeadDirection,
                    depth = FilterDepth,
                    pageNum
                });
                a.InnerHtml.Append(text);

                // Append the anchor element to the list item and the list item to the container
                li.InnerHtml.AppendHtml(a);
                container.InnerHtml.AppendHtml(li);
            }
            // Retrieve filter values from the context
            context.Items.TryGetValue(nameof(FilterSex), out object filterSex);
            context.Items.TryGetValue(nameof(FilterHairColor), out object filterHairColor);
            context.Items.TryGetValue(nameof(FilterFaceBundles), out object filterFaceBundles);
            context.Items.TryGetValue(nameof(FilterAgeAtDeath), out object filterAgeAtDeath);
            context.Items.TryGetValue(nameof(FilterHeadDirection), out object filterHeadDirection);
            context.Items.TryGetValue(nameof(FilterDepth), out object filterDepth);

            // Set the filter properties from the retrieved values
            FilterSex = filterSex?.ToString();
            FilterHairColor = filterHairColor?.ToString();
            FilterFaceBundles = filterFaceBundles?.ToString();
            FilterAgeAtDeath = filterAgeAtDeath?.ToString();
            FilterHeadDirection = filterHeadDirection?.ToString();
            FilterDepth = filterDepth?.ToString();

        }
    }
}

