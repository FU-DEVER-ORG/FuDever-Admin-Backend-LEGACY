using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.GetAllMajors;

/// <summary>
///     Get all majors request handler.
/// </summary>
internal sealed class GetAllMajorsRequestHandler
    : IRequestHandler<GetAllMajorsRequest, GetAllMajorsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMajorsRequestHandler(IUnitOfWork unitOfWork)
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
    ///     A task containing the response.
    /// </returns>
    public async Task<GetAllMajorsResponse> Handle(
        GetAllMajorsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed majors.
        var foundMajors =
            await _unitOfWork.MajorFeature.GetAllMajors.Query.GetAllNonTemporarilyRemovedMajorsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllMajorsResponseStatusCode.OPERATION_SUCCESS,
            FoundMajors = foundMajors.Select(selector: foundMajor =>
            {
                return new GetAllMajorsResponse.Major()
                {
                    MajorId = foundMajor.Id,
                    MajorName = foundMajor.Name
                };
            })
        };
    }
}
