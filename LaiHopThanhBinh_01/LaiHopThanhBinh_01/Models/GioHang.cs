using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaiHopThanhBinh_01.Models
{
    public class GioHang
    {
        Models.RubikStore store = new Models.RubikStore();
        public int id { get; set; }
        [Display(Name ="Tên")]
        public string ten { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }
        [Display(Name = "Giá Bán")]
        public Double gia { get; set; }
        [Display(Name = "Số lượng")]
        public int iSoLuong { get; set; }
        [Display(Name = "Thành Tiền")]
        public Double dThanhtien
        {
            get { return iSoLuong * gia; }
        }
        public GioHang(int id)
        {
            this.id = id;
            Rubik rubik = store.Rubiks.Single(n => n.id == id);
            ten= rubik.ten;
            hinh= rubik.hinh;
            gia= double.Parse(rubik.gia.ToString());
            iSoLuong = 1;
        }
    }
}