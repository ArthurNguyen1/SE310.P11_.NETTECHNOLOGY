using BaiTap4.Models;

namespace BaiTap4.Repository
{
    public interface ILoaiSP
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);

        TLoaiSp Delete(TLoaiSp loaiSp);

        TLoaiSp GetLoaiSp(String loaiSp);
        IEnumerable<TLoaiSp> GetAll();

    }
}
