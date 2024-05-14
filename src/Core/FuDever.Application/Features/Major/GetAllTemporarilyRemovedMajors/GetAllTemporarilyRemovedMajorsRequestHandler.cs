using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;

/// <summary>
///     Get all temporarily removed majors request handler.
/// </summary>
internal sealed class GetAllTemporarilyRemovedMajorsRequestHandler
    : IRequestHandler<GetAllTemporarilyRemovedMajorsRequest, GetAllTemporarilyRemovedMajorsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTemporarilyRemovedMajorsRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    ///     Entry of new request handler.
    /// </summary>
    /// <param name="request">
    ///     Request model.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the boolean result.
    /// </returns>
    public async Task<GetAllTemporarilyRemovedMajorsResponse> Handle(
        GetAllTemporarilyRemovedMajorsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed majors.
        var foundTemporarilyRemovedMajors =
            await _unitOfWork.MajorFeature.GetAllTemporarilyRemovedMajors.Query.GetAllTemporarilyRemovedMajorsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllTemporarilyRemovedMajorsResponseStatusCode.OPERATION_SUCCESS,
            FoundTemporarilyRemovedMajors = foundTemporarilyRemovedMajors.Select(
                selector: foundMajor =>
                {
                    return new GetAllTemporarilyRemovedMajorsResponse.Major()
                    {
                        MajorId = foundMajor.Id,
                        MajorName = foundMajor.Name,
                        MajorRemovedAt = foundMajor.RemovedAt,
                        MajorRemovedBy = foundMajor.RemovedBy
                    };
                }
            )
        };
    }
}
