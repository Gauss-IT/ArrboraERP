using System.Windows.Forms;
using Arrbora.Data.BussinessService;

namespace Arrbora.UI
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
            this.Show();
            var productService = new ProductService();
            productService.GetAllProducts();
        }
    }
}
