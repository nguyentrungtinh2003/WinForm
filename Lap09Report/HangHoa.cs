using System;

namespace Lap09Report
{
    public class HangHoaMua
    {
        public int MaHH { get; set; }
        public string TenHH { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => DonGia * SoLuong;
    }
}
