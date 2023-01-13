namespace westcoast_education.web.Interfaces;

    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository {get;}
        IUserRepository UserRepository{get;}
        Task<bool> Complete();
    }
