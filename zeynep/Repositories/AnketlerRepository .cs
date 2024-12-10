using zeynep.Models;

namespace zeynep.Repositories
{
    public class AnketlerRepository : Repository<Anketler>, IAnketlerReporsitory
    {
        private  AppDbContext _appDbContext;
        public AnketlerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Guncelle(Anketler anketler)
        {
            _appDbContext.Update(anketler);
        }
        public void Kaydet()
        {
            _appDbContext.SaveChanges();
        }

        public void Sil(object anketler)
        {
            throw new NotImplementedException();
        }
    }
}
