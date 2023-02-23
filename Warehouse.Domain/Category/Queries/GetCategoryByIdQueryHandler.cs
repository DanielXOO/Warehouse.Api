using System.Data;
using AutoMapper;
using MediatR;
using Warehouse.Data.Repositories.Interfaces;

namespace Warehouse.Domain.Category.Queries;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, DomainModels.Category>
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly IMapper _mapper;

    private readonly IProductRepository _productRepository;
    
    
    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, 
        IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    
    public async Task<DomainModels.Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(request.Id);

        if (categoryEntity == null)
        {
            throw new DataException("Product with such id do not exists");
        }
        
        var categoryModel = _mapper.Map<DomainModels.Category>(categoryEntity);

        var productsEntities = await _productRepository.GetProductsByCategoryId(categoryModel.Id);

        if (productsEntities.Any())
        {
            var products = _mapper.Map<IEnumerable<DomainModels.Product>>(productsEntities);
            categoryModel.Products = products;
        }

        return categoryModel;
    }
}