

using zeynep.Models;

namespace zeynep.Repositories
{
    public interface IAnketlerReporsitory : IRepository<Anketler>
    {
        void Guncelle(Anketler anketler);
        void Kaydet();
        void Sil(object anketler);
    }
}
