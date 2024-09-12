using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;

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


        public static IHtmlContent RenderStars(this RazorPage page, double stars)
        {
            var builder = new StringBuilder();

            int fullStars = (int)stars;
            bool hasHalfStar = (stars - fullStars) >= 0.5;

            for (int i = 1; i <= 5; i++)
            {
                if (i <= fullStars)
                {
                    builder.Append("<i class='fas fa-star' style='color: gold;'></i>");
                }
                else if (i == fullStars + 1 && hasHalfStar)
                {
                    builder.Append("<i class='fas fa-star-half-alt' style='color: gold;'></i>");
                }
                else
                {
                    builder.Append("<i class='fas fa-star' style='color: grey;'></i>");
                }
            }

            return new HtmlString(builder.ToString());
        }
    }
}