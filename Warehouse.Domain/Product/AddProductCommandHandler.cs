using System.Data;
using AutoMapper;
using MediatR;
using Warehouse.Data.Core.Interfaces;
using Warehouse.Data.Repositories.Interfaces;

namespace Warehouse.Domain.Product;

public sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, DomainModels.Product>
{
    private readonly IProductRepository _productRepository;

    private readonly ICategoryRepository _categoryRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;
    
    
    public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    
    
    public async Task<DomainModels.Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        
        if (category == null)
        {
            throw new DataException("Category with such id do not exists");
        }
        
        var productEntity = _mapper.Map<Data.Entities.Product>(request);
        _productRepository.Create(productEntity);

        category.ProductsIds.Add(productEntity.Id);
        _categoryRepository.Update(category);
        
        await _unitOfWork.SaveChangesAsync();
        
        var product = _mapper.Map<DomainModels.Product>(productEntity);

        return product;
    }
}