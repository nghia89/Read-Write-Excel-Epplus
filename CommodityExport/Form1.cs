using CommodityExport.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Newtonsoft.Json;
using System.Collections;

namespace CommodityExport
{
    public partial class Form1 : Form
    {
        public string _pathFile;
        public Form1(string pathFile)
        {
            InitializeComponent();
            this._pathFile = pathFile;
        }
        SaveFileDialog SaveFile;
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "xlsx files (*.xlsx)|*.xlsx", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    TxtProcess.Text = "Đang xử lý";
                    TextFileName.Text = ofd.SafeFileName;
                    this._pathFile = ofd.FileName;
                    this.ReadExcel(ofd.FileName);
                }
            }
        }
        private void ReadExcel(string fileName)
        {

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                FileInfo existingFile = new FileInfo(fileName);
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[2];
                    this.ShowListAddressDepot(worksheet);
                }

            }
            catch (Exception)
            {
                DialogResult d;
                d = MessageBox.Show("Vui lòng đóng File đang mở.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    Close();
                }
            }
            return;
        }

        public List<DataFieldModel> GenerateData(ExcelWorksheet workSheet)
        {
            if (workSheet == null) return null;
            var listData = new List<DataFieldModel>();

            var columnCount = workSheet.Dimension.Columns;
            for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
            {
                var dataFidle = new DataFieldModel();
                for (int ii = 0; ii < columnCount; ii++)
                {
                    var line = this.GenNumberToABC(ii);
                    var value = workSheet.Cells[$"{line}{i}"].Value;
                    if (workSheet.Cells[$"{line}1"] == null) continue;
                    switch (workSheet.Cells[$"{line}1"].Value.ToString())
                    {
                        case "ORDERID":
                            dataFidle.Orderid = value == null ? null : value.ToString();
                            break;
                        case "ORDERDATE":
                            dataFidle.OrderDate = value == null ? null : value.ToString();
                            break;
                        case "BARCODE":
                            dataFidle.BarCode = value == null ? null : value.ToString();
                            break;
                        case "PRODUCTNAME":
                            dataFidle.ProductName = value == null ? null : value.ToString();
                            break;
                        case "QUANTITY":
                            dataFidle.QuanTity = value == null ? null : value.ToString();
                            break;
                        case "PRICE":
                            dataFidle.Price = value == null ? null : value.ToString();
                            break;
                        case "AMOUNT":
                            dataFidle.Amount = value == null ? null : value.ToString();
                            break;
                        case "SHIPTOSTOREID":
                            dataFidle.ShipToStoreId = value == null ? 0 : Int64.Parse(value.ToString());
                            break;
                        case "SHIPTOSTORENAME":
                            dataFidle.ShipToStoreName = value == null ? null : value.ToString();
                            break;
                        case "SHIPTOSTOREADDRESS":
                            dataFidle.ShipToStoreAddress = value == null ? null : value.ToString();
                            break;
                        case "SHIPFROMDATE":
                            dataFidle.ShipFromDate = value == null ? null : value.ToString();
                            break;
                        case "SHIPTODATE":
                            dataFidle.ShipToDate = value == null ? null : value.ToString();
                            break;
                    }
                }
                if (dataFidle.Orderid != null)
                    listData.Add(dataFidle);
            }
            return listData;
        }

        public void ShowListAddressDepot(ExcelWorksheet workSheet)
        {
            if (workSheet == null) return;
            var listData = new List<AddressDepotsModel>();
            var columnCount = workSheet.Dimension.Columns;
            for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
            {
                var dataFidle = new AddressDepotsModel();
                for (int ii = 0; ii < columnCount; ii++)
                {
                    var line = this.GenNumberToABC(ii);
                    var value = workSheet.Cells[$"{line}{i}"].Value;

                    switch (workSheet.Cells[$"{line}1"].Value.ToString())
                    {
                        case "Code":
                            dataFidle.Code = value == null ? null : value.ToString();
                            break;
                        case "OtherName":
                            dataFidle.OtherName = value == null ? null : value.ToString();
                            break;
                        case "Province":
                            dataFidle.Province = value == null ? null : value.ToString();
                            break;
                    }
                }
                if (dataFidle.Code != null)
                    listData.Add(dataFidle);
            }

            foreach (var item in listData)
            {
                if (item.OtherName != null)
                    cbListAddresPepot.Items.Add(item.Code);
            }

        }

        public List<DepotsModel> GetListDepot(ExcelWorksheet workSheet)
        {
            if (workSheet == null) return null;
            var listData = new List<DepotsModel>();

            var columnCount = workSheet.Dimension.Columns;
            for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
            {
                var dataFidle = new DepotsModel();
                for (int ii = 0; ii < columnCount; ii++)
                {
                    var line = this.GenNumberToABC(ii);
                    var value = workSheet.Cells[$"{line}{i}"].Value;

                    switch (workSheet.Cells[$"{line}1"].Value.ToString())
                    {
                        case "Code":
                            dataFidle.Code = value == null ? 0 : Int64.Parse(value.ToString());
                            break;
                        case "Name":
                            dataFidle.Name = value == null ? null : value.ToString();
                            break;
                        case "Code_Depot":
                            dataFidle.Code_Depot = value == null ? null : value.ToString();
                            break;
                        case "Province":
                            dataFidle.Province = value == null ? null : value.ToString();
                            break;
                    }
                }
                if (dataFidle.Code != 0)
                    listData.Add(dataFidle);
            }
            return listData;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                FileInfo existingFile = new FileInfo(this._pathFile);
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet0 = package.Workbook.Worksheets[0];
                    ExcelWorksheet worksheet1 = package.Workbook.Worksheets[1];
                    var listDepot = this.GetListDepot(worksheet1);
                    var listData = this.GenerateData(worksheet0);
                    var result = false;
                    if (!string.IsNullOrEmpty(cbListAddresPepot.Text) && cbListAddresPepot.Text != "Chọn xuất theo kho")
                    {
                        var code = cbListAddresPepot.Text.ToLower().Trim();
                        var depotByCode = listDepot.Where(a => a.Code_Depot.ToLower().Trim() == code).ToList();
                        result = this.CreateExcel(listData.Where(a => depotByCode.Any(x => x.Code == a.ShipToStoreId)).ToList());
                    }
                    else
                    {
                        result = this.CreateExcel(listData);
                    }


                    TxtProcess.Text = "Xử lý thành công. đang xuất File";
                    if (result == true) TxtProcess.Text = "Xuất file thành công.";
                }

            }
            catch (Exception)
            {
                DialogResult d;
                d = MessageBox.Show("Vui lòng đóng File đang mở.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    Close();
                }
            }

        }

        public bool CreateExcel(List<DataFieldModel> listData)
        {
            var numberDay = 0;
            try
            {
                numberDay = string.IsNullOrEmpty(txtNumber.Text) ? 0 : Int32.Parse(txtNumber.Text);
            }
            catch (Exception)
            {
                DialogResult d;
                d = MessageBox.Show("Vui lòng Nhập ngày xuất kho là kiểu số", "Thông báo");
                if (d == DialogResult.OK) return false;
            }

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).Segments;
            var path = exeFile.Skip(1).Take(exeFile.Count() - 4).ToArray();
            string exeDir = Path.GetDirectoryName(string.Join("", path));
            string fullPath = Path.Combine(exeDir, "FileExport.xlsx");

            FileInfo existingFile = new FileInfo(fullPath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                var workbook = package.Workbook;
                ExcelWorksheet excelWorksheet = this.Copy(package.Workbook, "Sheet1", "NewSheet");

                var groupData = listData.OrderBy(a => a.ShipToStoreId).GroupBy(a => a.ShipToStoreId).Select(gr => gr.ToList()).ToList();
                var dataLength = groupData.Count();

                ExcelWorksheet sheetInfo = workbook.Worksheets.Add("Info Oder");
                sheetInfo.Cells["A1"].Value = "Tổng phiếu";
                sheetInfo.Cells["B1"].Value = dataLength;

                for (int i = 0; i < dataLength; i++)
                {
                    var data = groupData[i];
                    var dataItemCount = data.Count();
                    sheetInfo.Cells[$"D{i + 1}"].Value = $"Mã kho: {data[0].ShipToStoreId}";
                    sheetInfo.Cells[$"E{i + 1}"].Value = $"Tên Kho: {data[0].ShipToStoreName}";
                    sheetInfo.Cells[$"F{i + 1}"].Value = $"Số lượng: {dataItemCount}";
                }

                for (int i = 0; i < dataLength; i++)
                {
                    var newWorksheet = workbook.Worksheets.Add($"NewSheet_{i}", excelWorksheet);
                    var data = groupData[i];
                    var dataItemCount = data.Count();

                    var item = data[0];
                    var indexCurrent = 5;
                    var stt = 1;
                    for (int ii = 0; ii < dataItemCount; ii++)
                    {
                        newWorksheet.Cells["E1"].Value = item.ShipToStoreId.ToString();
                        newWorksheet.Cells["A3"].Value = item.ShipToStoreId.ToString();
                        newWorksheet.Cells["B3"].Value = item.ShipToStoreName.ToString();
                        newWorksheet.Cells["B2"].Value = DateTime.Now.AddDays(numberDay).ToString("dd/MM/YYYY");
                        newWorksheet.Cells["A3"].Value = item.ShipToStoreId.ToString();
                        newWorksheet.Cells[$"A{indexCurrent}"].Value = stt.ToString();
                        newWorksheet.Cells[$"B{indexCurrent}"].Value = data[ii].ProductName;
                        newWorksheet.Cells[$"C{indexCurrent}"].Value = "Khay";
                        newWorksheet.Cells[$"D{indexCurrent}"].Value = data[ii].QuanTity;

                        indexCurrent++;
                        stt++;
                    }
                }
                var worksheet1 = package.Workbook.Worksheets.SingleOrDefault(x => x.Name == "NewSheet");
                package.Workbook.Worksheets.Delete(worksheet1);
                var worksheet2 = package.Workbook.Worksheets.SingleOrDefault(x => x.Name == "Sheet1");
                package.Workbook.Worksheets.Delete(worksheet2);


                byte[] arrayData = package.GetAsByteArray();
                this.saveFile(arrayData);
            }
            return true;
        }

        public void saveFile(byte[] arrayData)
        {
            string newName = "ExcelSheet";
            if (!string.IsNullOrEmpty(cbListAddresPepot.Text) && cbListAddresPepot.Text != "Chọn xuất theo kho")
            {
                newName = cbListAddresPepot.Text.ToLower().Trim();

            }

            SaveFile = new SaveFileDialog();
            SaveFile.Title = "Save Excel sheet";
            SaveFile.Filter = "Excel files|*.xlsx|All files|*.*";
            SaveFile.FileName = $"{newName}_" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm") + ".xlsx";

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(SaveFile.FileName, arrayData);
            }
        }

        public ExcelWorksheet Copy(ExcelWorkbook workbook, string existingWorksheetName, string newWorksheetName)
        {
            ExcelWorksheet worksheet = workbook.Worksheets.Copy(existingWorksheetName, newWorksheetName);
            return worksheet;
        }

        public string GenNumberToABC(int number)
        {
            ArrayList caseNumber = new ArrayList(new ArrayList { "A", "B", "c", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A" });
            return caseNumber[number].ToString();
        }
    }
}

