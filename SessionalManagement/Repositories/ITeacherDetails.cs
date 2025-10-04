namespace SessionalManagement.Repositories
{
    public interface ITeacherDetails
    {
        public ITeacherRepository Teacher { get; }
        public ISubjectRepository Subject { get; }
        public void Save();
    }
}
