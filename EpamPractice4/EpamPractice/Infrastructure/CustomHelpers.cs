using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamPractice.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString CreateSelect(this HtmlHelper html, List<string> items, string name)
        {
            var select = new TagBuilder("select");
            select.MergeAttribute("name", name);

            foreach (string item in items)
            {
                var option = new TagBuilder("option");

                option.MergeAttribute("value", item);

                option.SetInnerText(item);

                select.InnerHtml += option.ToString();

            }

            return new MvcHtmlString(select.ToString());

        }

        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {
            TagBuilder tag = new TagBuilder("ul");
            foreach(string str in list)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(str);
                tag.InnerHtml += itemTag.ToString();
            }
            return new MvcHtmlString(tag.ToString());
        }

    }
}

/*<div class="form-group">
        <label for="exampleSelect1">Example select</label>
        <select class="form-control" id="exampleSelect1">
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
            <option>5</option>
        </select>
    </div>
*/