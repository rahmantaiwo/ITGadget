using ITGadgetSite.BL.DTOs;
using ITGadgetSite.Model.Models;

namespace ITGadgetSite.BL
{
    public interface IGadgetService
    {
        Task<BaseResponse<GadgetDto>> CreateGadgetAsync(CreateGadgetDto request, CancellationToken cancellationToken);
        Task<BaseResponse<GadgetDto>> UpdateGadgetAsync(Guid gadgetId, CreateGadgetDto request, CancellationToken cancellationToken);
        Task<BaseResponse<GadgetDto>> DeleteGadgetAsync(Guid id, CancellationToken cancellationToken);
        Task<BaseResponse<IEnumerable<GadgetDto>>> GetAllGadgetAsync(CancellationToken cancellationToken);
        Task<BaseResponse<GadgetDto>> GetGadgetByIdAsync(Guid id, CancellationToken cancellationToken); 
    }
}
