using System.Windows.Forms;
using Arrbora.Data.DataModel;
using Arrbora.Data.BussinessService;
using System;

namespace Arrbora.UI
{
    public partial class frmProduct : Form
    {
        ProductDataModel _product;
        public frmProduct(ProductDataModel product)
        {
            InitializeComponent();
            _product = product;       
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _product.Brand = txtBrand.Text;
            _product.Model = txtModel.Text;
            _product.VIN = Int32.Parse(txtVIN.Text);
            _product.EnteriourColour = txtEnteriorColour.Text;
            _product.ExteriourColour = txtExteriorColour.Text;
            _product.DLPNetto = Int32.Parse(txtDLPNetto.Text);
            _product.DLPBrutto = Int32.Parse(txtDLPBrutto.Text);
            _product.Seller = string.Empty;
            _product.Buyer = string.Empty;

            var productService = new ProductService();
            productService.AddProduct(_product);
        }
    }
}
