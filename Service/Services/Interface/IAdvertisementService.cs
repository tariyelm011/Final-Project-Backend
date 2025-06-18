using Domain.Entity;
using Service.Dtos.Advertisement;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IAdvertisementService : ICrudService<Advertisement, AdvertisementCreateVM, AdvertisementEditVM, AdvertisementVM>
{
    Task<AdvertisementEditVM> AdvertisementsAsync(int id);

}
