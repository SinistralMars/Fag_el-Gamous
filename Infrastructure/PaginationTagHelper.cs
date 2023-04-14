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

namespace Fag_el_Gamous.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create the page links

        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

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
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

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
                a.Attributes["href"] = disabled ? "#" : uh.Action(PageAction, new
                {
                    sex = FilterSex,
                    hairColor = FilterHairColor,
                    faceBundles = FilterFaceBundles,
                    ageAtDeath = FilterAgeAtDeath,
                    headDirection = FilterHeadDirection,
                    depth = FilterDepth,
                    pageNum // Moved this line to the end
                });
                a.InnerHtml.Append(text);

                li.InnerHtml.AppendHtml(a);
                container.InnerHtml.AppendHtml(li);
            }
            context.Items.TryGetValue(nameof(FilterSex), out object filterSex);
            context.Items.TryGetValue(nameof(FilterHairColor), out object filterHairColor);
            context.Items.TryGetValue(nameof(FilterFaceBundles), out object filterFaceBundles);
            context.Items.TryGetValue(nameof(FilterAgeAtDeath), out object filterAgeAtDeath);
            context.Items.TryGetValue(nameof(FilterHeadDirection), out object filterHeadDirection);
            context.Items.TryGetValue(nameof(FilterDepth), out object filterDepth);

            FilterSex = filterSex?.ToString();
            FilterHairColor = filterHairColor?.ToString();
            FilterFaceBundles = filterFaceBundles?.ToString();
            FilterAgeAtDeath = filterAgeAtDeath?.ToString();
            FilterHeadDirection = filterHeadDirection?.ToString();
            FilterDepth = filterDepth?.ToString();

        }
    }
}

