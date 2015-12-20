/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arrbora.Data.DataModel;

namespace Arrbora.UI
{
    public partial class frmSalesManagement : Form
    {
        SalesManagementDataModel _salesManagement;
        public frmSalesManagement(SalesManagementDataModel salesManagementDataModel)
        {
            InitializeComponent();
        }
    }
}
