using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interface;
using Service.Services.Generic;
using Service.Services.Interface;
using Service.ViewModels.FeaturedProduct;

namespace Service.Services;

public class FeaturedProductService : CrudService<FeaturedProduct, FeaturedProductCreateVM, FeaturedProductEditVM, FeaturedProductVM>, IFeaturedProductService
{
    private readonly IFeaturedProductRepository _repository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public FeaturedProductService(IFeaturedProductRepository repository, IMapper mapper, IProductRepository productRepository) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task RestoreOrginalPrice(int productId)
    {
        var product = await _productRepository.GetAsync(x => x.Id == productId);
        if (product == null)
            throw new Exception("Belə bir məhsul mövcud deyil.");
        var featuredProduct = await _repository.GetAsync(x => x.ProductId == productId);
        if (product == null)
            throw new Exception("Belə bir məhsul mövcud deyil.");
        product.Price = featuredProduct.OrginalPrice;

        _productRepository.Update(product);
        await _productRepository.SaveChangesAsync();

        _repository.Delete(featuredProduct);

    }

    public async Task EditAsync(FeaturedProductEditVM vm)
    {
        var entity = await _repository.GetAsync(x => x.Id == vm.Id);
        if (entity == null)
            throw new Exception("Featured product tapılmadı.");

        var product = await _productRepository.GetAsync(x => x.Id == vm.ProductId);
        if (product == null)
            throw new Exception("Belə bir məhsul mövcud deyil.");

        var exists = await _repository.GetAsync(x => x.ProductId == vm.ProductId && x.Id != vm.Id);
        if (exists != null)
            throw new Exception("Bu məhsul artıq başqa Featured Product kimi mövcuddur.");

        if (vm.DiscountedPrice <= 0 || vm.DiscountedPrice >= product.Price)
            throw new Exception("Endirimli qiymət 0-dan böyük və orijinal qiymətdən kiçik olmalıdır.");

        if (vm.CountdownEndDate <= DateTime.UtcNow)
            throw new Exception("Son tarix indiki tarixdən sonra olmalıdır.");


        entity.ProductId = vm.ProductId;
        entity.DiscountedPrice = vm.DiscountedPrice;
        entity.CountdownEndDate = vm.CountdownEndDate;
        entity.OrginalPrice = product.Price; 

        _repository.Update(entity);
        await _repository.SaveChangesAsync();

        product.Price = vm.DiscountedPrice;
        _productRepository.Update(product);
        await _productRepository.SaveChangesAsync();

    }

    public async Task<FeaturedProductEditVM> GetByIdForEditAsync(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Product));
        if (entity == null)
            throw new Exception("Featured Product tapılmadı.");

        var products = await _productRepository.GetAll().ToListAsync();

        var vm = new FeaturedProductEditVM
        {
            ProductId = entity.ProductId,
            DiscountedPrice = entity.DiscountedPrice,
            CountdownEndDate = entity.CountdownEndDate,
            Products = products.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList()
        };

        return vm;
    }

    public async Task CreateAsync(FeaturedProductCreateVM vm)
    {
        var product = await _productRepository.GetAsync(x => x.Id == vm.ProductId);
        if (product == null)
            throw new Exception("Product tapılmadı.");

        var exists = await _repository.GetAsync(x => x.ProductId == vm.ProductId);
        if (exists != null)
            throw new Exception("Bu məhsul artıq Featured Product olaraq əlavə edilib.");
        if (vm.DiscountedPrice <= 0 || vm.DiscountedPrice >= product.Price)
            throw new Exception("Endirimli qiymət 0-dan böyük və orijinal qiymətdən kiçik olmalıdır.");

        if (vm.CountdownEndDate <= DateTime.UtcNow)
            throw new Exception("Son tarix indiki tarixdən sonra olmalıdır.");

        var entity = new FeaturedProduct
        {
            ProductId = vm.ProductId,
            DiscountedPrice = vm.DiscountedPrice,
            CountdownEndDate = vm.CountdownEndDate,
            OrginalPrice = product.Price, 

        };

        await _repository.CreateAsync(entity);
        product.Price = vm.DiscountedPrice;

         _productRepository.Update(product);
      await  _productRepository.SaveChangesAsync();
    }

    public async Task<List<FeaturedProductVM>> FeaturedProductsAsync()
    {
        var models = _repository.GetAll( include : x=>x.Include(p=>p.Product));

        var featuredProductVMs = new List<FeaturedProductVM>();

        foreach (var model in models)
        {
            var vm = new FeaturedProductVM
            {
                Id = model.Id,
                ProductId = model.ProductId,
                ProductName = model.Product?.Name,
                OriginalPrice = model.OrginalPrice,
                DiscountedPrice = model.DiscountedPrice,
                CountdownEndDate = model.CountdownEndDate,
                ProductImageUrl = model.Product?.ImageUrl 
            };

            featuredProductVMs.Add(vm);
        }

        return featuredProductVMs;
    }
    

    public async Task Delete(int id)
    {
        var fetured = await _repository.GetAsync(id);
        if (fetured == null)
            throw new Exception("Featured Product tapılmadı.");
        var product = await _productRepository.GetAsync(x => x.Id == fetured.ProductId);
        if (product == null)
            throw new Exception("Belə bir məhsul mövcud deyil.");
        product.Price = fetured.OrginalPrice;
        _productRepository.Update(product);
        await _productRepository.SaveChangesAsync();
        await _repository.Delete(fetured);
    }


}
