using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Products.Commands.EditProduct
{
     
    public interface IEditProductService
    {
        ResultDto Execute(RequestEditproductDto request);
    }
    public class EditProductService : IEditProductService
    {
        private readonly IDataBaseContext _context;

        public EditProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditproductDto request)
        {
            var product = _context.Products.Find(request.productId);
            if (product == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
            product.Price  = request.price;
            product.Name  = request.Name;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش محصول انجام شد"
            };

        }
    }


    public class RequestEditproductDto
    {
        public long productId { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
    }
}

