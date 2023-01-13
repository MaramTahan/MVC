namespace westcoast_education.web.Interfaces;

    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository {get;}
        ITeacherUserRepository TeacherUserRepository{get;}
        IStudentUserRepository StudentUserRepository{get;}
        Task<bool> Complete();
    }
