using TrendApi.Application.Base;

namespace TrendApi.Application.Features.Products.Exceptions;

public class ProductTitleMustNotBeSameException : BaseExceptions
{
    public ProductTitleMustNotBeSameException() : base("Ürün Başlığı zaten var.") { } 
    //Bu yapının güzelliği: çoklu dil kullanııyorsanız, base içine resourch dosyasını vererek, hata dönüşümü alabilirsiniz. 
            
}
