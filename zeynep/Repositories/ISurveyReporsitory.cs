using zeynep.Models;

namespace zeynep.Repositories
{
    public interface ISurveyReporsitory : IRepository<Survey>
    {
        void Guncelle(Survey survey);
        void Kaydet();
        
    }
}
