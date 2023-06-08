using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Products.Commands.RemoveProduct
{
    
        public class RemoveProductService : IRemoveProductService
        {
            private readonly IDataBaseContext _context;

            public RemoveProductService(IDataBaseContext context)
            {
                _context = context;
            }


            public ResultDto Execute(long productId)
            {

                var product = _context.Products.Find(productId);
                if (product == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "محصول یافت نشد"
                    };
                }
                product.RemoveTime = DateTime.Now;
                product.IsRemoved = true;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت حذف شد"
                };
            }
        }
    }
