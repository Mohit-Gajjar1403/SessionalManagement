using SessionalManagement.Models;

namespace SessionalManagement.Repositories
{
    public class EFTeacherDetails:ITeacherDetails
    {
        private readonly AppDbContext _context;
        private ITeacherRepository _teacherRepository;
        private ISubjectRepository _subjectRepository;
        public EFTeacherDetails(AppDbContext context)
        {
            _context = context;
        }

        public ITeacherRepository Teacher
        {
            get => _teacherRepository ??= new EFTeacherRepository(_context);
        }

        public ISubjectRepository Subject
        {
            get => _subjectRepository ??= new EFSubjectRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
