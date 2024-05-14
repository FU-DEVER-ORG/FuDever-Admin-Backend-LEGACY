namespace FuDever.WebApi.DTOs.Others;

/// <summary>
///     This class contains methods to implement
///     the data normalization on Dto.
/// </summary>
internal interface IDtoNormalization
{
    /// <summary>
    ///     Normalize all properties of this Dto object.
    /// </summary>
    void NormalizeAllProperties();
}
