using LaiHopThanhBinh_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaiHopThanhBinh_01.Controllers
{
    public class GioHangController : Controller
    {
        Models.RubikStore store = new Models.RubikStore();
        // GET: GioHang
        public List<GioHang> Laygiohang()
        {
            List<GioHang> list = Session["Giohang"] as List<GioHang>;
            if(list == null)
            {
                list = new List<GioHang>();
                Session["Giohang"] = list;
            }
            return list;

        }
        public ActionResult ThemGioHang(int id, string strURL)
        {
            List<GioHang> list = Laygiohang();
            GioHang sanpham = list.Find(n => n.id == id);
            if(sanpham == null)
            {
                sanpham = new GioHang(id);
                list.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> list = Session["Giohang"] as List<GioHang>;
            if(list != null)
            {
                tsl = list.Sum(n => n.iSoLuong);
            }
            return tsl;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> list = Session["Giohang"] as List<GioHang>;
            if(list!=null)
            {
                tsl = list.Count();
            }
            return tsl;
        }
        private double TongTien()
        {
            double t = 0;
            List<GioHang> list = Session["Giohang"] as List<GioHang>;
            if(list!=null )
            {
                t = list.Sum(n => n.dThanhtien);
            }
            return t;
        }
        public ActionResult GioHang()
        {
            List<GioHang> list = Session["Giohang"] as List<GioHang>;
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return View(list);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        {
            List<GioHang> list = Laygiohang();
            GioHang sanpham = list.SingleOrDefault(n => n.id == id);
            if(sanpham == null)
            {
                list.RemoveAll(n => n.id == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapNhatGioHang(int id, FormCollection collection)
        {
            List<GioHang> list = Laygiohang();
            GioHang sanpham = list.SingleOrDefault(n => n.id == id);
            if(sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> list = Laygiohang();
            list.Clear();
            return RedirectToAction("GioHang");
        }
    }
}