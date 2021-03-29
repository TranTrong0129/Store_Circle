using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CIPO_app
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : UserControl
    {

        public Create()
        {
            InitializeComponent();
            loadItemsourceNhaSX();
            loadItemsourceLoaiSP();
            loadItemsourceSanPham();
            loadSP();
        }
        void loadSP()
        {
            var data = GetDao.get_SanPham();
            Dataspsx.ItemsSource = data;
            Total.data_Cipos = data;
            suadata.ItemsSource = data;

        }
        void loadItemsourceNhaSX()
        {
            var datasx = GetDao.get_NhaSX();
            NhaSX.ItemsSource = datasx;
            XoanhaSX.ItemsSource = datasx;
            SuanhaSX.ItemsSource = datasx;
        }

        void loadItemsourceSanPham()
        {
            var datasx = GetDao.get_NhaSX();
            var dataloai = GetDao.get_LoaiSp();
            suamaloai.ItemsSource = dataloai;
            suaNhaSX.ItemsSource = datasx;
        }

        void loadItemsourceLoaiSP()
        {
            var dataloai = GetDao.get_LoaiSp();

            maloai.ItemsSource = dataloai;
            xoamaloaisx.ItemsSource = dataloai;
            suamaloaisx.ItemsSource = dataloai;
        }


        private void Openfolder_1(object sender, RoutedEventArgs e)
        {
            
            var open = new OpenFileDialog();
            open.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (open.ShowDialog() == true)
            {
                var infor = new FileInfo(open.FileName);

                var newname = Guid.NewGuid() + infor.Extension;
                string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                var filename = currentFolder.Substring(0, currentFolder.Length - 10) + @"ImagesCake\";
                infor.CopyTo($"{filename + "//" + newname}");

                var m = (ToggleButton)e.OriginalSource;

                string name = m.Tag.ToString();
                if (name != "tag22")
                    AnhdaidienSp.Text = newname;
                else
                    suaAnhdaidienSp.Text = newname;
            }
        }
       
        private void Openfolder_2(object sender, RoutedEventArgs e)
        {
            string listimages = "";
            var open = new OpenFileDialog();
            open.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            open.Multiselect = true;
            if (open.ShowDialog() == true)
            {
                foreach (string nfile in open.FileNames)
                {
                    var infor = new FileInfo(nfile);
                    var newname = Guid.NewGuid() + infor.Extension;
                    string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    var filename = currentFolder.Substring(0, currentFolder.Length - 10) + @"ImagesCake\";
                    infor.CopyTo(filename + newname);
                    listimages += " - " + newname;
                }

                ToggleButton m = (ToggleButton)e.OriginalSource;
                string name = m.Tag.ToString();
                if (name != "tag22")
                    AnhSp.Text = listimages.Substring(3);
                else
                    suaAnhSp.Text = listimages.Substring(3);
            }
        }



        void TagItem(int tag)
        {
            switch (tag)
            {
                #region Sản phẩm
                case 11:
                    string tensp = TenSp.Text;
                    string anhdaidien = AnhdaidienSp.Text;
                    string anhsp = AnhSp.Text;
                    string slg = soluong.Text;
                    string g = gia.Text;
                    string maloaisp = maloai.SelectedItem == null ? 0 + "" : (maloai.SelectedItem as LoaiSP).id.ToString();
                    string masx = NhaSX.SelectedItem == null ? 0 + "" : (NhaSX.SelectedItem as NhaSX).id.ToString();
                    string diem = (diemdg.SelectedItem as ComboBoxItem).Content.ToString();
                    try
                    {
                        GetDao.insertSanPham(tensp, anhdaidien, anhsp, slg, g, maloaisp, masx, diem);
                        MessageBox.Show("Tạo sản phẩm thành công");
                        TenSp.Text = AnhdaidienSp.Text = AnhSp.Text = soluong.Text = gia.Text = null;
                        maloai.SelectedItem = NhaSX.SelectedItem = diemdg.SelectedItem = null;
                        loadSP();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nhập thông tin lỗi. Kiểm tra lại thông tin nhập đầy đủ và đúng yêu cầu chưa !!!");
                    }

                    break;

                case 12:
                    string xoaspp = xoasp.Text;
                    string rowsp = (Dataspsx.SelectedItem as SanPham).Masp.ToString();

                    if (xoaspp != "")
                    {
                        try
                        {
                            GetDao.deleteSanPham(xoaspp);
                            MessageBox.Show("Xóa sản phẩm thành công");
                            loadSP();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sản Phẩm có liên quan đến chi tiết hóa đơn, không thể xóa nhanh được," +
                                " Làm ơn thực hiện xóa CTHD trước khi xóa ", "Thông báo");
                        }
                    }
                    else if (Dataspsx.SelectedIndex != -1)
                    {
                        try
                        {
                            GetDao.deleteSanPham(rowsp);
                            MessageBox.Show("Xóa sản phẩm thành công");
                            loadSP();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sản Phẩm có liên quan đến chi tiết hóa đơn, không thể xóa nhanh được," +
                                " Làm ơn thực hiện xóa CTHD trước khi xóa ", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn hay nhập sản phẩm để xóa");
                    }
                    break;
                
                case 13:
                    string id = (suadata.SelectedValue as SanPham).Masp.ToString();
                    string suatensp = suaTenSp.Text;
                    var ads = GetDao.get_SanPham2();

                    string suaanhdaidien = suaAnhdaidienSp.Text != (suadata.SelectedValue as SanPham).Anhdaidien ? suaAnhdaidienSp.Text : ads.SingleOrDefault(p => p.Masp.ToString().Equals(id)).Anhdaidien;
                    
                    var getanhsp = string.Join(" - ", ads.SingleOrDefault(p => p.Masp.ToString().Equals(id)).Anhsp);
                    var getanhsptext = string.Join(" - ", (suadata.SelectedValue as SanPham).Anhsp);

                    string suaanhsp = suaAnhSp.Text != getanhsptext ? suaAnhSp.Text : getanhsp;
                    string suasoluongsp = suasoluong.Text;
                    string suagiasp = suagia.Text;
                    string suamaloaisp = (suamaloai.SelectedValue as LoaiSP).id+"";
                    string suanhasxsp = (suaNhaSX.SelectedValue as NhaSX).id+"";
                    string suadiemsp = (diemdgsp.SelectedValue as ComboBoxItem).Content.ToString();

                    try
                    {
                        GetDao.updateSanPham(id, suatensp, suaanhdaidien, suaanhsp, suasoluongsp, suagiasp, suamaloaisp, suanhasxsp, suadiemsp);
                        MessageBox.Show("Cập nhật sản phẩm thành công");
                        suaTenSp.Text = suaAnhdaidienSp.Text = suaAnhSp.Text = suasoluong.Text = suagia.Text = null;
                        suamaloai.SelectedItem = suaNhaSX.SelectedItem = diemdgsp.SelectedItem = null;
                        loadSP();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thay đổi thông tin lỗi. Kiểm tra lại thông tin đúng yêu cầu chưa !!!");
                    }

                    break;
                #endregion

                #region Nhà sản xuất
                case 21:
                    string tensx = tennhasx.Text;
                    try
                    {
                        GetDao.insertNhaSX(tensx);
                        MessageBox.Show("Tạo nhà sản xuất thành công");
                        loadItemsourceNhaSX();
                        tennhasx.Text = null;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nhập thông tin lỗi. Kiểm tra lại thông tin nhập đầy đủ và đúng yêu cầu chưa !!!");
                    }
                    break;
                case 22:
                    string masxs = (XoanhaSX.SelectedItem as NhaSX).id.ToString();
                    if (GetDao.checkNhaSX(masxs) == 0) 
                    {
                        GetDao.deleteNhaSX(masxs);
                        MessageBox.Show("Xóa nhà sản xuất thành công");
                        loadItemsourceNhaSX();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhà sản xuất vì còn tồn tại mặt hàng của nhà sản xuất này");
                    }
                    break;
                case 23:
                    string suatensx = suatennhasx.Text;
                    string idsx = (SuanhaSX.SelectedItem as NhaSX).id.ToString();
                    GetDao.updateNhaSX(idsx,suatensx);
                    MessageBox.Show("Cập nhật nhà sản xuất thành công");
                    loadItemsourceNhaSX();
                    suatennhasx.Text = null;
                    SuanhaSX.SelectedIndex = -1;
                    break;

                #endregion

                #region Loại sản phẩm
                case 31:
                    string Tenmasp = tenmasp.Text;
                    try
                    {
                        GetDao.insertLoaiSanPham(Tenmasp);
                        MessageBox.Show("Tạo loại sản phẩm thành công");
                        loadItemsourceLoaiSP();
                        tenmasp.Text = null;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nhập thông tin lỗi. Kiểm tra lại thông tin nhập đầy đủ và đúng yêu cầu chưa !!!");
                    }
                    break;
                case 32:
                    string maloaisps = (xoamaloaisx.SelectedItem as LoaiSP).id.ToString();
                    if (GetDao.checkLoaiSp(maloaisps) == 0)
                    {
                        GetDao.deleteLoaiSanPham(maloaisps);
                        MessageBox.Show("Xóa loại sản phẩm thành công");
                        loadItemsourceLoaiSP();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa loại sản phẩm vì còn tồn tại mặt hàng của loại sản phẩm này");
                    }
                    break;
                case 33:
                    string suaTenmasp = tenloaisx.Text;
                    string idmsp = (suamaloaisx.SelectedItem as LoaiSP).id.ToString();
                    GetDao.updateLoaiSanPham(idmsp, suaTenmasp);
                    MessageBox.Show("Cập nhật loại sản phẩm thành công");
                    loadItemsourceLoaiSP();
                    tenloaisx.Text = null;
                    suamaloaisx.SelectedIndex = -1;
                    break;
                    #endregion
            }
        }
        private void Delete_event(object sender, RoutedEventArgs e)
        {
            Button m = (Button)e.OriginalSource;
            int tag = int.Parse(m.Tag.ToString());
            TagItem(tag);
        }

        private void Update_event(object sender, RoutedEventArgs e)
        {
            Button m = (Button)e.OriginalSource;
            int tag = int.Parse(m.Tag.ToString());
            TagItem(tag);
        }

        private void Create_event(object sender, RoutedEventArgs e)
        {
            Button m = (Button)e.OriginalSource;
            int tag = int.Parse(m.Tag.ToString());
            TagItem(tag);
        }

        private void chage_item(object sender, SelectionChangedEventArgs e)
        {
            ComboBox m = (ComboBox)e.OriginalSource;
            string name = m.Name;

            if(name == "SuanhaSX")
                if (SuanhaSX.SelectedIndex != -1)
                    suatennhasx.Text = (SuanhaSX.SelectedItem as NhaSX).tennhasx;
            if(name == "suamaloaisx")
                if(suamaloaisx.SelectedIndex != -1)
                    tenloaisx.Text = (suamaloaisx.SelectedItem as LoaiSP).tenloai;
        }

        private void chage_dadagrid(object sender, SelectedCellsChangedEventArgs e)
        {
            var sp = suadata.SelectedItem as SanPham;
            if(sp != null)
            {
                suaTenSp.Text = sp.Tensp;
                suaAnhdaidienSp.Text = sp.Anhdaidien;
                string anh = string.Join(" - ", sp.Anhsp);
                suaAnhSp.Text = anh;
                suasoluong.Text = sp.Soluong.ToString();
                suagia.Text = sp.gia.ToString();

                suamaloai.SelectedIndex = getindex(suamaloai, sp.Maloai);
                suaNhaSX.SelectedIndex = getindex(suaNhaSX, sp.MaNhaSx);
                diemdgsp.SelectedIndex = sp.Danhgiasao - 1;
            }
        }

        int getindex(ComboBox combo, int value)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if(combo.Name == "suamaloai")
                {
                    var v = combo.Items[i] as LoaiSP;
                    if (v.id == value)
                        return i;
                }
                else if (combo.Name == "suaNhaSX")
                {
                    var v = combo.Items[i] as NhaSX;
                    if (v.id == value)
                        return i;
                }
            }
            return -1;
        }

        private void OnTabSelected(object sender, RoutedEventArgs e)
        {
            var tab = sender as TabItem;
            if (tab != null)
                loadItemsourceSanPham();
        }

    }
}
