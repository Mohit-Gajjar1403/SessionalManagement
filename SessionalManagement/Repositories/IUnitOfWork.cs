namespace SessionalManagement.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository User { get; }
        public ITeacherDetails TeacherDetails { get; }
        public IMarkRepository Marks{ get; }
        public void Save();
    }
}
