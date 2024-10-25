using Microsoft.AspNetCore.Mvc;
using BaiTap4.Repository;
namespace BaiTap4.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSP _loaiSp;

        public LoaiSpMenuViewComponent(ILoaiSP loaiSp)
        {
            _loaiSp = loaiSp;
        }

        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAll().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
