using ProjektASP.Models;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace ProjektASP.Infrastructure {
    [HtmlTargetElement("div", Attributes ="carek")]
    public class MostCarsHelper : TagHelper {
        private readonly CarContext _context;
        public MostCarsHelper(CarContext _context) {
            this._context = _context;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output) {
            var ownerWithMostCars =
                 (from o in _context.Owner
                  join c in _context.Car on o.Id equals c.OwnerId
                  group o by o.Id into g
                  orderby g.Count() descending
                  select g.Key).FirstOrDefault();

            var owner = _context.Owner.Where(e => e.Id == ownerWithMostCars).FirstOrDefault();
            if (ownerWithMostCars!= null) {
                output.TagName = "div";
                output.Attributes.Add("class", "mostCars");
                output.Content.SetHtmlContent($"<h4>Owner with most cars: {owner.Name} {owner.Surname}</h4>");
            }
        }

    }
}
