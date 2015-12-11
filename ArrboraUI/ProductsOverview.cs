using Arrbora.Data.BussinessService;
using Arrbora.Data.DataModel;
using System.Windows.Forms;

namespace Arrbora.UI
{
    public partial class ProductsOverview : Form
    {
        public ProductsOverview()
        {
            InitializeComponent();
            this.Show();
            var productService = new ProductService();
            productService.GetAllProducts();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            var product = new ProductDataModel();
            var frm = new frmProduct(product);
            frm.Show();
        }
    }
}
