using AutoMapper;
using MediatR;
using Warehouse.Data.Core.Interfaces;
using Warehouse.Data.Repositories.Interfaces;

namespace Warehouse.Domain.Category;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, DomainModels.Category>
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;
    
    
    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<DomainModels.Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryEntity = _mapper.Map<Data.Entities.Category>(request);
        _categoryRepository.Create(categoryEntity);
        await _unitOfWork.SaveChangesAsync();

        var product = _mapper.Map<DomainModels.Category>(categoryEntity);

        return product;
    }
}