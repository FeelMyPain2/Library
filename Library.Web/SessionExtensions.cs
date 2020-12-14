using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Library.Web.Models;

namespace Library.Web
{
    public static class SessionExtensions
    {
        private const string key = "cart";

        public static void Set(this ISession sesion, RentalCart value)
        {
            if (value == null)
            {
                return;
            }
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalRentalPrice);

                sesion.Set(key, stream.ToArray());
            }
        }

        public static bool TryGetCart(this ISession session, out RentalCart value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalRentalPrice = reader.ReadDecimal();

                    value = new RentalCart(orderId)
                    {
                        TotalCount = totalCount,
                        TotalRentalPrice = totalRentalPrice
                    };

                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
