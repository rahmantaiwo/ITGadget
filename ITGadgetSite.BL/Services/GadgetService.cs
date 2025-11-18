using ITGadgetSite.BL.DTOs;
using ITGadgetSite.Database.Interfaces;
using ITGadgetSite.Model.Entities;
using ITGadgetSite.Model.Models;
using Microsoft.Extensions.Logging;

namespace ITGadgetSite.BL.Services
{
    public class GadgetService(IGadgetRepository iGadgetRepo,
        ILogger<GadgetService> logger) : IGadgetService
    {
        public async Task<BaseResponse<GadgetDto>> CreateGadgetAsync(CreateGadgetDto request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Handling create gadget for gadget name: {GadgetName}", request.GadgetName);

                if (request.GadgetName == null)
                {
                    return BaseResponse<GadgetDto>.NotFound("Gadget name is required");
                }

                var existingName = await iGadgetRepo.GetByNameAsync(request.GadgetName, cancellationToken);
                if (existingName != null)
                {
                    return BaseResponse<GadgetDto>.FailureResponse("Gadget name already exist");
                }

                var inputRequest = new ITGadget
                {
                    GadgetName = request.GadgetName,
                    Description = request.Description,
                    Quantity = request.Quantity,
                    Price = request.Price,
                };

                var responseOutput = await iGadgetRepo.AddAsync(inputRequest, cancellationToken);

                var gadgetCreated = new GadgetDto
                {
                    Id = responseOutput.Id,
                    GadgetName = responseOutput.GadgetName,
                    Description = responseOutput.Description,
                    Quantity = responseOutput.Quantity,
                    Price= responseOutput.Price,
                    CreatedAt = responseOutput.CreatedAt,
                };

                return BaseResponse<GadgetDto>.SuccessResponse(gadgetCreated, "Gadget created successsfuly");
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error occured while creating product: {Message}", ex.Message);
                return BaseResponse<GadgetDto>.FailureResponse("Invalid data");
            }
        }

        public async Task<BaseResponse<GadgetDto>> DeleteGadgetAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Attempting to delete product with ID: {GadgetId}", id);

                var existingGadget = await iGadgetRepo.GetByIdAsync(id, cancellationToken);
                if (existingGadget == null)
                {
                    return BaseResponse<GadgetDto>.NotFound("Gadget ID is required");
                }

                await iGadgetRepo.DeleteAsync(existingGadget, cancellationToken);

                logger.LogInformation("Gadget deleted successfully: {GadgetId}", id);

                var gadgetList = new GadgetDto
                {
                    Id = existingGadget.Id,
                    GadgetName = existingGadget.GadgetName,
                    Description = existingGadget.Description,
                    Quantity = existingGadget.Quantity,
                    Price = existingGadget.Price,
                };
                return BaseResponse<GadgetDto>.SuccessResponse(gadgetList, "Gadget deleted successfully");
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error deleting Gadget with ID: {GadgetId}", id);
                return BaseResponse<GadgetDto>.FailureResponse("Failed to delete data");
            }
        }

        public async Task<BaseResponse<IEnumerable<GadgetDto>>> GetAllGadgetAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Fetching all gadgets.....");

                var gadgets = await iGadgetRepo.GetAllAsync(cancellationToken);

                if (gadgets == null || !gadgets.Any())
                {
                    return BaseResponse<IEnumerable<GadgetDto>>.NotFound("Gadgets not found");
                }

                var gadgetDto = gadgets.Select(g => new GadgetDto
                {
                    Id = g.Id,
                    GadgetName = g.GadgetName,
                    Description = g.Description,
                    Quantity = g.Quantity,
                    Price = g.Price,
                    CreatedAt = g.CreatedAt,
                }).ToList();

                return BaseResponse<IEnumerable<GadgetDto>>.SuccessResponse(gadgetDto, "Gadgets retrieved successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching gadgets.");
                return BaseResponse<IEnumerable<GadgetDto>>.FailureResponse("Error occured while fetching gadgets");
            }
        }

        public async Task<BaseResponse<GadgetDto>> GetGadgetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Get gadget ID: {GadgetId}", id);

                var product = await iGadgetRepo.GetByIdAsync(id, cancellationToken);
                
                if (product == null)
                {
                    return BaseResponse<GadgetDto>.NotFound("Gadget not found");
                }

                var gadgetDto = new GadgetDto
                {
                    Id = product.Id,
                    GadgetName = product.GadgetName,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CreatedAt = product.CreatedAt
                };

                return BaseResponse<GadgetDto>.SuccessResponse(gadgetDto, "Gadget retrieved successful");
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching gadget.");
                return BaseResponse<GadgetDto>.FailureResponse("Error occured while fetching gadget");
            }
        }

        public async Task<BaseResponse<GadgetDto>> UpdateGadgetAsync(Guid gadgetId, CreateGadgetDto request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Attempting to update gadget with ID: {GadgetId}", gadgetId);

                var existingGadget = await iGadgetRepo.GetByIdAsync(gadgetId, cancellationToken);

                if(existingGadget == null)
                {
                    return BaseResponse<GadgetDto>.NotFound("Gadget not found");
                }

                existingGadget.GadgetName = request.GadgetName;
                existingGadget.Description = request.Description;
                existingGadget.Quantity = request.Quantity;
                existingGadget.Price = request.Price;
                existingGadget.UpdatedAt = DateTime.UtcNow;

                await iGadgetRepo.UpdateAsync(existingGadget, cancellationToken);

                var updatedGadget = new GadgetDto
                {
                    Id = existingGadget.Id,
                    GadgetName = existingGadget.GadgetName,
                    Description = existingGadget.Description,
                    Quantity = existingGadget.Quantity,
                    Price = existingGadget.Price,
                    UpdatedAt =existingGadget.UpdatedAt,
                };

                logger.LogInformation("Product updated successfully: {GadgetId}", gadgetId);

                return BaseResponse<GadgetDto>.SuccessResponse(updatedGadget, "Gadget updated successfully");
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error updating gadget with ID: {gadgetId}", gadgetId);
                return BaseResponse<GadgetDto>.FailureResponse("An unexpected error occurred");
            }
        }
    }
}
