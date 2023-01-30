using AutoMapper;
using MediatR;
using Warehouse.Data.Core.Interfaces;
using Warehouse.Data.Repositories.Interfaces;

namespace Warehouse.Domain.Product;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, DomainModels.Product>
{
    private readonly IProductRepository _productRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;
    
    
    public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<DomainModels.Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = _mapper.Map<Data.Entities.Product>(request);
        _productRepository.Create(productEntity);
        await _unitOfWork.SaveChangesAsync();

        var product = _mapper.Map<DomainModels.Product>(productEntity);

        return product;
    }
}