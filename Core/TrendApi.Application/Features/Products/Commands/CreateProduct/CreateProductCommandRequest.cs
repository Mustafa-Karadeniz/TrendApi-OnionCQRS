using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrendApi.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandRequest : IRequest<Unit>
{
    [Required(ErrorMessage ="{0} alanı zorunludur")]
    [DisplayName("Başlık")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} alanı en az {2} en çok {1} karakter olabilir")]
    public string Title { get; set; }
    public string Description { get; set; }[StringLength(50, MinimumLength = 3, ErrorMessage = "{0} alanı en az {2} en çok {1} karakter olabilir")]
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public decimal Discount{ get; set; }

    public IList<int> CategoryIds { get; set; }
}