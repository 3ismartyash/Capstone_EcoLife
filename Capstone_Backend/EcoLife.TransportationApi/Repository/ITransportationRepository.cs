using EcoLife.TransportationApi.Models;
using EcoLife.TransportationApi.Models.Dto;

namespace EcoLife.TransportationApi.Repository
{
    public interface ITransportationRepository
    {
        Task<IEnumerable<TransportationEntity>> GetTransportationEntities();

        Task<IEnumerable<TransportationEntity>> GetTransportationById(int userid);

        //Task<TransportationEntity> postTransportationEntity(int userid,TransportationDto entity);
        Task<TransportationEntity> postTransportationEntity(TransportationDto entity);

        Task<TransportationEntity> putTransportationEntity(int id, TransportationDto entity);

        Task<bool> DeleteTransportationEntity(int id);
        
    }
}
