using Restaurant.MVC.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.TagHelpers
{
    public class ContactTagHelper : TagHelper
    {
        public Organization Organization { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("Itemscope itemtype", "http://schema.org/organization");
            output.Content.SetHtmlContent( 
                $@"<span itemprop=""name"">{Organization.Name}</span>
                <address itemprop=""address""><br/>
                <span itemprop=""streetAddress"">{Organization.StreetAddress}</span><br/>
                <span itemprop=""addressLocality"">{Organization.AddressLocality}</span><br/>
                <span itemprop=""streetRegion"">{Organization.AddressRegion}</span><br/>
                <span itemprop=""postalCode"">{Organization.PostalCode}</span><br/><br/>
                <span itemprop=""telephone"">{Organization.TelephoneNumber}</span><br/>
                <span itemprop=""email"">{Organization.Email}</span>");
            output.Attributes.SetAttribute("class", "row col-5");
        }
    }
}
