using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence.Context;

public class ApplicationDbContext: IdentityDbContext<User, Role, string,
    IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    #region Properties and builders
    public ApplicationDbContext() {}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    #endregion


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AcademicLevelConfiguration());
        builder.ApplyConfiguration(new AddressConfiguration());
        builder.ApplyConfiguration(new ClassConfiguration());
        builder.ApplyConfiguration(new CourseConfiguration());
        builder.ApplyConfiguration(new DisciplineConfiguration());
        builder.ApplyConfiguration(new DisciplineCourseConfiguration());
        builder.ApplyConfiguration(new EnrollmentConfiguration());
        builder.ApplyConfiguration(new EnrollmentCourseConfiguration());
        builder.ApplyConfiguration(new EnrollmentCourseDisciplineConfiguration());
        builder.ApplyConfiguration(new PersonalDataConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new ScheduleConfiguration());
        builder.ApplyConfiguration(new SchoolYearConfiguration());
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new EnrollmentParameterConfiguration());
        builder.ApplyConfiguration(new EnrollmentStatusConfiguration());
        builder.ApplyConfiguration(new UserRoleConfiguration());
        builder.ApplyConfiguration(new VacancyCourseConfiguration());
    }
}