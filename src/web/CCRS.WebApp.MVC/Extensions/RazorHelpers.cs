using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

namespace CCRS.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string HashEmailForGravatar(this RazorPage page, string email)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string CurrencyFormat(this RazorPage page, decimal value)
        {
            return value > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", value) : "Free";
        }

        public static string StockMessage(this RazorPage page, int quantity)
        {
            return quantity > 0 ? $"Only {quantity} in stock!" : "Product sold out!";
        }


        public static IHtmlContent RenderStars(this RazorPage page, decimal stars)
        {
            var builder = new StringBuilder();

            int fullStars = (int)stars;
            bool hasHalfStar = (stars - fullStars) >= 0.5m; //0.5m por ser decimnal

            //add fulll stars
            for (int i = 1; i <= fullStars; i++)
            {
                builder.Append(CreateStarTag("fas fa-star", "gold"));
            }

            // add halp star
            if (hasHalfStar)
            {
                builder.Append(CreateStarTag("fas fa-star-half-alt", "gold"));
            }

            //add empty stars
            int emptyStars = 5 - fullStars - (hasHalfStar ? 1 : 0);
            for (int i = 1; i <= emptyStars; i++)
            {
                builder.Append(CreateStarTag("fas fa-star", "grey"));
            }

            return new HtmlString(builder.ToString());
        }

        private static string CreateStarTag(string iconClass, string color)
        {
            var tagBuilder = new TagBuilder("i");
            tagBuilder.AddCssClass(iconClass);
            tagBuilder.Attributes.Add("style", $"color: {color};");

            using(var writer = new StringWriter())
            {
                tagBuilder.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}