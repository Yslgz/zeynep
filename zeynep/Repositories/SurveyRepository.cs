using zeynep.Models;

namespace zeynep.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyReporsitory
    {
        private  AppDbContext _appDbContext;
        public SurveyRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Guncelle(Survey survey)
        {
            _appDbContext.Update(survey);
        }
        public void Kaydet()
        {
            _appDbContext.SaveChanges();
        }

        
    }
}
