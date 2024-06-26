using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Cinema
{
    public partial class Form1 : Form
    {
        private readonly CinemaDbContext _dbContext;
        private int total = 0;

        public Form1()
        {
            InitializeComponent();
            _dbContext = new CinemaDbContext();

            InitializeSeats();
            ShowBookedSeats();
        }

        private void InitializeSeats()
        {
            var seats = _dbContext.Seats.ToList();

            foreach (var seat in seats)
            {
                Button seatButton = Controls.Find($"btn{seat.SeatNumber}", true)[0] as Button;
                seatButton.Text = $"GH {seat.Price} VND";
                seatButton.Tag = seat;
                seatButton.BackColor = seat.Status == "Đặt" ? Color.DeepPink : Color.Gray;
                seatButton.Click += SeatButton_Click;
            }
        }

        private void btnPopcorn_Click(object sender, EventArgs e)
        {
            var selectedSeats = GetSelectedSeats();

            foreach (var seat in selectedSeats)
            {
                seat.Popcorn++;
                total += 80000;
            }

            UpdateTotal(selectedSeats.Count, true, false); 
        }

        private void btnSoda_Click(object sender, EventArgs e)
        {
            var selectedSeats = GetSelectedSeats();

            foreach (var seat in selectedSeats)
            {
                seat.Soda++;
                total += 40000;
            }

            UpdateTotal(selectedSeats.Count, false, true); 
        }
        //update

        private void UpdateTotal(int seatCount, bool popcornSelected, bool sodaSelected)
        {
            if (popcornSelected && sodaSelected)
            {
                // Nếu cả bắp và nước đều được chọn
                if (seatCount >= 4)
                {
                    total -= seatCount * 120000; // Miễn phí bắp và nước ngọt
                }
            }
            else
            {
                // Nếu chỉ một trong hai hoặc không có bắp hoặc nước
                if (popcornSelected)
                {
                    // Trừ tiền bắp
                    total -= seatCount * 80000;
                }
                else if (sodaSelected)
                {
                    // Trừ tiền nước
                    total -= seatCount * 40000;
                }
            }

            lblTong.Text = total.ToString();
            SaveChangesAndRefresh();
        }

        private void SaveChangesAndRefresh()
        {
            try
            {
                _dbContext.SaveChanges();
                ShowBookedSeats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Seat> GetSelectedSeats()
        {
            List<Seat> selectedSeats = new List<Seat>();

            foreach (Control control in Controls)
            {
                if (control is Button && ((Button)control).BackColor == Color.DeepPink)
                {
                    var seat = (Seat)((Button)control).Tag;
                    selectedSeats.Add(seat);
                }
            }

            return selectedSeats;
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            var seat = (Seat)clickedButton.Tag;

            if (seat.Status == "Đặt")
            {
                seat.Status = "Trống";
                total -= seat.Price;
            }
            else if (seat.Status == "Trống")
            {
                seat.Status = "Đặt";
                total += seat.Price;
            }

            lblTong.Text = total.ToString();
            clickedButton.BackColor = seat.Status == "Đặt" ? Color.DeepPink : Color.Gray;

            SaveChangesAndRefresh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowBookedSeats()
        {
            listBox1.Items.Clear();

            var bookedSeats = _dbContext.Seats.Where(s => s.Status == "Đặt").ToList();

            foreach (var seat in bookedSeats)
            {
                listBox1.Items.Add($"Ghế số {seat.SeatNumber}, Giá: {seat.Price} VND");
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int selectedSeatCount = GetSelectedSeats().Count;

            var purchaseSuccessForm = new PurchaseSuccessForm(selectedSeatCount);
            purchaseSuccessForm.ShowDialog();

            foreach (var seat in GetSelectedSeats())
            {
                seat.Status = "Đặt";
            }

            SaveChangesAndRefresh();
        }
    }

    public class Seat
    {
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

        public int Popcorn { get; set; }
        public int Soda { get; set; }
    }

    public class CinemaDbContext : DbContext
    {
        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=cinemadb;Uid=root;Pwd=;", new MySqlServerVersion(new Version(8, 0, 26)));
        }
    }
}