using SessionalManagement.Models;

namespace SessionalManagement.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        private IMarkRepository _markRepository;
        private ITeacherDetails _teacherDetails;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IUserRepository User
        {
            get => _userRepository ??= new EFUserRepository(_context);
        }
        public IMarkRepository Marks
        {
            get => _markRepository ??= new EFMarkRepository(_context);
        }
        public ITeacherDetails TeacherDetails
        {
            get => _teacherDetails ??= new EFTeacherDetails(_context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
