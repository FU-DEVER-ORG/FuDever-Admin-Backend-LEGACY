using System;
using FuDever.Domain.Specifications.Entities.Cv;
using FuDever.Domain.Specifications.Entities.Cv.Manager;

namespace FuDever.SqlServer.Specifications.Entities.Cv.Manager;

/// <summary>
///     Represent implementation of cv specification manager.
/// </summary>
internal sealed class CvSpecificationManager : ICvSpecificationManager
{
    private ICvAsNoTrackingSpecification _cvAsNoTrackingSpecification;
    private ISelectFieldsFromCvSpecification _selectFieldsFromCvSpecification;

    public ICvAsNoTrackingSpecification CvAsNoTrackingSpecification
    {
        get
        {
            _cvAsNoTrackingSpecification ??= new CvAsNoTrackingSpecification();

            return _cvAsNoTrackingSpecification;
        }
    }

    public ISelectFieldsFromCvSpecification SelectFieldsFromCvSpecification
    {
        get
        {
            _selectFieldsFromCvSpecification ??= new SelectFieldsFromCvSpecification();

            return _selectFieldsFromCvSpecification;
        }
    }

    public ICvByEmailSpecification CvByEmailSpecification(string email)
    {
        return new CvByEmailSpecification(email: email);
    }

    public ICvByIdSpecification CvByIdSpecification(Guid cvId)
    {
        return new CvByIdSpecification(cvId: cvId);
    }

    public ICvByStudentIdSpecification CvByStudentIdSpecification(string studentId)
    {
        return new CvByStudentIdSpecification(studentId: studentId);
    }
}
