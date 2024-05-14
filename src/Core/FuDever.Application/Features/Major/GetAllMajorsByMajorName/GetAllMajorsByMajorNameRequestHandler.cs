using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.GetAllMajorsByMajorName;

/// <summary>
///     Get all majors by major name request handler.
/// </summary>
internal sealed class GetAllMajorsByMajorNameRequestHandler
    : IRequestHandler<GetAllMajorsByMajorNameRequest, GetAllMajorsByMajorNameResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMajorsByMajorNameRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllMajorsByMajorNameResponse> Handle(
        GetAllMajorsByMajorNameRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all majors by major name.
        var foundMajors =
            await _unitOfWork.MajorFeature.GetAllMajorsByMajorName.Query.GetAllMajorsByMajorNameQueryAsync(
                majorName: request.MajorName,
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllMajorsByMajorNameResponseStatusCode.OPERATION_SUCCESS,
            FoundMajors = foundMajors.Select(selector: foundMajor =>
            {
                return new GetAllMajorsByMajorNameResponse.Major()
                {
                    MajorId = foundMajor.Id,
                    MajorName = foundMajor.Name
                };
            })
        };
    }
}
