using System.Windows.Forms;
using Arrbora.Data.DataModel;
using Arrbora.Data.BussinessService;
using Arrbora.UI.Interfaces;
using System;

namespace Arrbora.UI
{
    public partial class frmProduct : Form, IValidateInput
    {
        ProductDataModel _product;

        /// <summary>
        /// 
        /// </summary>
        private bool _isExistingProduct;
        ProductService _productService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="product">Reference to a product, that is handled in this form</param>
        public frmProduct(ProductDataModel product)
        {
            InitializeComponent();
            _product = product;
            _productService = new ProductService();

            //default value is true, if we initialize with no product, then false
            _isExistingProduct = true;
            if (product.ProductID == 0 && product.Brand == null) _isExistingProduct = false;      
        }

        public bool ValidateFormInput()
        {
            int number;
            var result = true;
            if(txtBrand.Text == string.Empty ||
               txtModel.Text == string.Empty ||
               !int.TryParse(txtVIN.Text, out number) ||
               txtEnteriorColour.Text == string.Empty ||
               !int.TryParse(txtDLPNetto.Text, out number) ||
               !int.TryParse(txtDLPBrutto.Text, out number) ||
               !int.TryParse(txtModelYear.Text, out number))
                result = false;

            return result;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (ValidateFormInput())
            {
                _product.Brand = txtBrand.Text;
                _product.Model = txtModel.Text;
                _product.VIN = Int32.Parse(txtVIN.Text);
                _product.EnteriourColour = txtEnteriorColour.Text;
                _product.ExteriourColour = txtExteriorColour.Text;
                _product.ModelYear = Int32.Parse(txtModelYear.Text);
                _product.DLPNetto = Int32.Parse(txtDLPNetto.Text);
                _product.DLPBrutto = Int32.Parse(txtDLPBrutto.Text);
                
                 if (!AddOrUpdateProduct())
                    MessageBox.Show("The record was not commited to the database", "Database Access Error");

            }
            else { MessageBox.Show("Please give correct input", "Input validation error"); }           
        }
        private bool AddOrUpdateProduct()
        {
            
            if (_isExistingProduct)
                return _productService.UpdateProduct(_product);
            else
            {
                ResetFields();
                return _productService.AddProduct(_product);
                
            }
        }
        private void ResetFields()
        {
            txtBrand.ResetText();
            txtModel.ResetText();
            txtVIN.ResetText();
            txtEnteriorColour.ResetText();
            txtExteriorColour.ResetText();
            txtModelYear.ResetText();
            txtDLPNetto.ResetText();
            txtDLPBrutto.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_isExistingProduct)
                _productService.DeleteProductByID(_product.ProductID);
            else
                MessageBox.Show("No product to delete", "Input validation error");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _isExistingProduct = false;
            _product = new ProductDataModel();
            ResetFields();
        }
    }
}
