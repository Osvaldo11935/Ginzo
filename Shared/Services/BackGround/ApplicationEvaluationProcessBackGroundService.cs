using Application.Common.Interfaces.IUnitOfWorks;
using Domain.Common.Aggregates;
using Domain.Common.ValueObjects;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Shared.Services.BackGround;

public class ApplicationEvaluationProcessBackGroundService : BackgroundService
{
    #region Properties and builders

    private readonly IServiceProvider _serviceProvider;

    public ApplicationEvaluationProcessBackGroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    #endregion


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int totalVacancyCourse = 0;
        int totalVacancyInstitution = 0;
        using var scope = _serviceProvider.CreateScope();

        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        var enrollmentRepository = unitOfWork.AsyncRepository<Enrollment>();

        while (!stoppingToken.IsCancellationRequested)  
        {
            var enrollments = enrollmentRepository.SelectAllAsync(e =>
                    e.EnrollmentStatusId == EnrollmentStatusValueObject.UnderAnalysisId &&
                    e.EnrollmentParameter!.IsActive)
                .Include(e => e.Student)
                .Include(e => e.EnrollmentParameter)
                .ThenInclude(e => e!.VacancyCourses)
                .Include(e => e.EnrollmentCourses);

            foreach (var enrollment in enrollments)
            {
                var enrollmentCourse = enrollment.EnrollmentCourses!
                    .OrderBy(e => e.CreatedAt).LastOrDefault(e => e.IsActive);
                
                if(enrollmentCourse == null) continue;
                
                var vacancyCourses = enrollment.EnrollmentParameter!.VacancyCourses!
                    .FirstOrDefault(e => e.IsActive && e.CourseId == enrollmentCourse.CourseId);
                
                if(vacancyCourses == null) continue;
                
                var age = UserAggregate.CalculateUserAge(enrollment.Student!.BirthDate!.Value);

                if (enrollment.FinalAverage >= enrollment.EnrollmentParameter!.FinalAverage
                    && age >= enrollment.EnrollmentParameter!.MinPriorityAge &&
                    age <= enrollment.EnrollmentParameter!.MaxPriorityAge &&
                    totalVacancyInstitution <= enrollment.EnrollmentParameter.FinalAverage)
                {
                    if (vacancyCourses.TotalVacancy >= totalVacancyCourse)
                    {
                        enrollment.EnrollmentStatusId = EnrollmentStatusValueObject.PreApprovedId;
                        totalVacancyCourse++;
                    }
                    totalVacancyInstitution++;
                }
            }

            await unitOfWork.SaveChangeAsync(stoppingToken);

            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }
}